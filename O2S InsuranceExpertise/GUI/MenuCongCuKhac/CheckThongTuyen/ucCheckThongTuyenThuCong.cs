using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.MenuCongCuKhac
{
    public partial class ucCheckThongTuyenThuCong : UserControl
    {
        #region Khai bao
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();


        #endregion
        public ucCheckThongTuyenThuCong()
        {
            InitializeComponent();
        }

        #region Load
        private void ucCheckThongTuyenThuCong_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LoadDanhSachKhoa();
                XoaBoBanGhiThua_LichSuKCB();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDanhSachKhoa()
        {
            try
            {
                //linq groupby
                var lstDSKhoa = Base.SessionLogin.SessionlstPhanQuyen_KhoaPhong.Where(o => o.departmentgrouptype == 1 || o.departmentgrouptype == 4 || o.departmentgrouptype == 11).ToList().GroupBy(o => o.departmentgroupid).Select(n => n.First()).ToList();
                if (lstDSKhoa != null && lstDSKhoa.Count > 0)
                {
                    chkcomboListDSKhoa.Properties.DataSource = lstDSKhoa;
                    chkcomboListDSKhoa.Properties.DisplayMember = "departmentgroupname";
                    chkcomboListDSKhoa.Properties.ValueMember = "departmentgroupid";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void XoaBoBanGhiThua_LichSuKCB()
        {
            try
            {
                //Xóa bỏ bản ghi thừa tại bảng Lưu Lịch sử KCB
                string sql_xoarowthua = "DELETE FROM ie_lichsukcb_check WHERE lichsukcbcheckid IN (select lichsukcbcheckid from (SELECT ROW_NUMBER() Over(PARTITION BY mahoso) As RowNumber, lichsukcbcheckid FROM ie_lichsukcb_check ) A where RowNumber>1 );";
                condb.ExecuteNonQuery_HSBA(sql_xoarowthua);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Grid Danh sách bệnh nhân
        private void gridViewDSBN_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {

                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    //GridView view = sender as GridView;
                    e.Menu.Items.Clear();
                    DXMenuItem itemKiemTraDaChon = new DXMenuItem("Kiểm tra thông tuyến bệnh nhân đã chọn"); // caption menu
                    itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                    itemKiemTraDaChon.Click += new EventHandler(KiemTraDaChon_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraDaChon);

                    DXMenuItem itemKiemTraTatCa = new DXMenuItem("Kiểm tra thông tuyến tất cả"); // caption menu
                    itemKiemTraTatCa.Image = imageCollectionDSBN.Images[1]; // icon cho menu
                    itemKiemTraTatCa.Click += new EventHandler(KiemTraTatCa_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraTatCa);
                    itemKiemTraTatCa.BeginGroup = true;

                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void KiemTraDaChon_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                CheckThongTuyenRowDangChon();
                Custom_GridDisplayLichSuKCB(false);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            btnTimKiem_Click(null, null);
        }
        private void KiemTraTatCa_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                CheckThongTuyenTatCaRowDangChon();
                Custom_GridDisplayLichSuKCB(false);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            btnTimKiem_Click(null, null);
        }
        #endregion

        #region Custom
        private void gridViewDSBN_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void txtBhytCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBhytCode.Text.Trim() != "")
                {
                    txtPatientId.ResetText();
                    txtVienPhiId.ResetText();
                    txtBhytCode.Text = txtBhytCode.Text.ToUpper().Trim();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtPatientId_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientId.Text.Trim() != "")
                {
                    txtBhytCode.ResetText();
                    txtVienPhiId.ResetText();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtVienPhiId_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVienPhiId.Text.Trim() != "")
                {
                    txtBhytCode.ResetText();
                    txtPatientId.ResetText();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPatientId.Text != "")
                {
                    btnTimKiem.PerformClick();
                }
            }
        }

        private void txtVienPhiId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtVienPhiId.Text != "")
                {
                    btnTimKiem.PerformClick();
                }
            }
        }

        private void txtBhytCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBhytCode.Text != "")
                {
                    btnTimKiem.PerformClick();
                }
            }
        }
        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBhytCode.Text.Trim() == "" && txtPatientId.Text.Trim() == "" && txtVienPhiId.Text.Trim() == "")
                {
                    string lstKhoaChonLayBC = "";
                    List<Object> lstKhoaCheck = chkcomboListDSKhoa.Properties.Items.GetCheckedValues();
                    if (lstKhoaCheck.Count > 0)
                    {
                        for (int i = 0; i < lstKhoaCheck.Count - 1; i++)
                        {
                            lstKhoaChonLayBC += lstKhoaCheck[i] + ",";
                        }
                        lstKhoaChonLayBC += lstKhoaCheck[lstKhoaCheck.Count - 1];
                    }
                    if (lstKhoaChonLayBC == "")
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CHUA_CHON_KHOA_PHONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        gridControlDSBN.DataSource = null;
                        if (cboTrangThai.Text == "Đang điều trị")
                        {
                            LayDSBenhNhanDangDieuTri_TheoKhoa(lstKhoaChonLayBC);
                        }
                        else if (cboTrangThai.Text == "Ra viện chưa thanh toán")
                        {
                            LayDSBenhNhanDaRaVien_TheoKhoa(lstKhoaChonLayBC, " vienphistatus<>0 and COALESCE(vienphistatus_vp,0)=0 ");
                        }
                        else if (cboTrangThai.Text == "Đã thanh toán")
                        {
                            LayDSBenhNhanDaRaVien_TheoKhoa(lstKhoaChonLayBC, " vienphistatus <> 0 and vienphistatus_vp = 1 ");
                        }



                    }
                }
                else
                {
                    Model.Models.FilterDSBNThuCongDTO dieukientimkiem = new Model.Models.FilterDSBNThuCongDTO();
                    if (txtBhytCode.Text.Trim() != "")
                    {
                        dieukientimkiem.bhytcode = " and bhytcode='" + txtBhytCode.Text.Trim().ToUpper() + "' ";
                        dieukientimkiem.patientid = "";
                        dieukientimkiem.vienphiid = "";
                    }
                    else if (txtPatientId.Text.Trim() != "")
                    {
                        dieukientimkiem.patientid = " and patientid='" + txtPatientId.Text.Trim() + "' ";
                        dieukientimkiem.bhytcode = "";
                        dieukientimkiem.vienphiid = "";
                    }
                    if (txtVienPhiId.Text.Trim() != "")
                    {
                        dieukientimkiem.vienphiid = " and vienphiid='" + txtVienPhiId.Text.Trim() + "' ";
                        dieukientimkiem.bhytcode = "";
                        dieukientimkiem.patientid = "";
                    }
                    gridControlDSBN.DataSource = null;
                    LayDanhSachBenhNhan_TheoDieuKien(dieukientimkiem);
                }

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Click chon row
        private void repositoryItemButton_Check_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                CheckThongTuyenRowDangChon();
                Custom_GridDisplayLichSuKCB(false);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            btnTimKiem_Click(null, null);
        }
        #endregion
        //Tùy chọn View con của View hiển thị
        private void gridControlDSDotDieuTri_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            try
            {
                (e.View as GridView).ColumnPanelRowHeight = 25;
                (e.View as GridView).RowHeight = 25;
                (e.View as GridView).OptionsView.ShowIndicator = false;

                (e.View as GridView).Columns["stt_lichsu"].Caption = "STT";
                (e.View as GridView).Columns["maHoSo"].Caption = "Mã hồ sơ";
                (e.View as GridView).Columns["maCSKCB"].Caption = "Mã CSKCB";
                (e.View as GridView).Columns["tuNgay"].Caption = "Ngày vào viện";
                (e.View as GridView).Columns["denNgay"].Caption = "Ngày ra viện";
                (e.View as GridView).Columns["tenBenh"].Caption = "Tên bệnh";
                (e.View as GridView).Columns["tinhTrang"].Caption = "Mã tình trạng";
                (e.View as GridView).Columns["tinhTrang_Ten"].Caption = "Tình trạng";
                (e.View as GridView).Columns["kqDieuTri"].Caption = "Mã kết quả ĐT";
                (e.View as GridView).Columns["kqDieuTri_Ten"].Caption = "Kết quả điều trị";

                (e.View as GridView).Columns["tinhTrang"].Visible = false;
                (e.View as GridView).Columns["kqDieuTri"].Visible = false;

                (e.View as GridView).Columns["stt_lichsu"].Width = 35;
                (e.View as GridView).Columns["maHoSo"].Width = 80;
                (e.View as GridView).Columns["maCSKCB"].Width = 70;
                (e.View as GridView).Columns["tuNgay"].Width = 90;
                (e.View as GridView).Columns["denNgay"].Width = 90;
                (e.View as GridView).Columns["tenBenh"].Width = 200;
                (e.View as GridView).Columns["tinhTrang_Ten"].Width = 100;
                (e.View as GridView).Columns["kqDieuTri_Ten"].Width = 100;

                (e.View as GridView).Columns["stt_lichsu"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["maHoSo"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["maCSKCB"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tuNgay"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["denNgay"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tenBenh"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tinhTrang_Ten"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["kqDieuTri_Ten"].OptionsColumn.AllowEdit = false;

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSBN_Click(object sender, EventArgs e)
        {
            try
            {
                Custom_GridDisplayLichSuKCB(true);
                var rowHandle = gridViewDSBN.FocusedRowHandle;
                string sql_lskcb = " SELECT row_number () over (order by lsc.ngayvaovien) as stt, lsc.patientid, lsc.patientname, lsc.mahoso, lsc.macskcb, bv.benhvienname as tencskcb, lsc.ngayvaovien, lsc.ngayravien, lsc.tenbenh, lsc.tinhtrangcode, lsc.tinhtrangten, lsc.kqdieutricode, lsc.kqdieutri_ten FROM ie_lichsukcb_check lsc inner join (select benhvienkcbbd,benhvienname from ie_benhvien) bv on bv.benhvienkcbbd=lsc.macskcb WHERE patientid='" + gridViewDSBN.GetRowCellValue(rowHandle, "patientid").ToString() + "' GROUP BY lsc.patientid,lsc.patientname,lsc.mahoso,lsc.macskcb,bv.benhvienname,lsc.ngayvaovien,lsc.ngayravien,lsc.tenbenh,lsc.tinhtrangcode,lsc.tinhtrangten,lsc.kqdieutricode,lsc.kqdieutri_ten; ";
                DataTable dataLichSuKCB = condb.GetDataTable_HSBA(sql_lskcb);
                if (dataLichSuKCB != null && dataLichSuKCB.Rows.Count > 0)
                {
                    gridControlDSDotDieuTri.DataSource = dataLichSuKCB;
                }
                else
                {
                    gridControlDSDotDieuTri.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
