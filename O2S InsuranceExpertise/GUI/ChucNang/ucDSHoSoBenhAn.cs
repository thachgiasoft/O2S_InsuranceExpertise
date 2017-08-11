﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using O2S_InsuranceExpertise.Utilities.ThongBao;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using O2S_InsuranceExpertise.DTO;
using O2S_InsuranceExpertise.Utilities.GUIGridView;
using DevExpress.Utils.Menu;
using O2S_InsuranceExpertise.GUI.ChucNang.HSBA_BenhAn;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.ChucNang
{
    public partial class ucDSHoSoBenhAn : UserControl
    {
        #region Khai bao
        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;
        //lay thong tin ve benh nhan sang UC khac
        //   public delegate void GetStringThongTinBenhNhan(InsuranceExpertiseDTO deInsuranceExpertise);
        //  public GetStringThongTinBenhNhan MyGetDataInsuranceExpertise;
        private InsuranceExpertiseDTO SelectRowInsuranceExpertise { get; set; }
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        private int tabload_thongtinbenhan = 0, tabload_benhan = 0, tabload_pttt = 0, tabload_hoichan = 0;
        private bool highlight_tabBenhAn { get; set; }
        #endregion

        public ucDSHoSoBenhAn()
        {
            InitializeComponent();
        }

        #region Load
        private void ucDanhSachHoSoBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataDefault();
                LoadTabChucNangVaPhanQuyen();
                LoadDanhSachKhoa();
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void LoadDataDefault()
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

                xtraTabThongTinChung.PageVisible = false;
                xtraTabBenhAn.PageVisible = false;
                xtraTabHoiChan.PageVisible = false;
                xtraTabPTTT.PageVisible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void LoadTabChucNangVaPhanQuyen()
        {
            try
            {
                if (O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_01")) //Thong tin chung
                {
                    xtraTabThongTinChung.PageVisible = true;
                }

                if (O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_01")) //Ho so benh an
                {
                    xtraTabBenhAn.PageVisible = true;
                }

                if (O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_03")) //Hoi chan
                {
                    xtraTabHoiChan.PageVisible = true;
                }

                if (O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_04")) //PTTT
                {
                    xtraTabPTTT.PageVisible = true;
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
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
                    cboKhoa.Properties.DataSource = lstDSKhoa;
                    cboKhoa.Properties.DisplayMember = "departmentgroupname";
                    cboKhoa.Properties.ValueMember = "departmentgroupid";
                }
                if (lstDSKhoa.Count == 1)
                {
                    cboKhoa.ItemIndex = 0;
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(O2S_InsuranceExpertise.Utilities.ThongBao.WaitForm1));
            try
            {
                if (cboKhoa.EditValue == null || cboPhong.EditValue == null)
                {
                    frmThongBao frmthongbao = new frmThongBao(Base.ThongBaoLable.CHUA_CHON_KHOA_PHONG);
                    frmthongbao.Show();
                }
                else
                {
                    gridControlDSHSBA.DataSource = null;

                    string thoiGianTu = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    string thoiGianDen = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    string InsuranceExpertisestatus = "";
                    if (cboTrangThai.Text == "Chưa tiếp nhận")
                    {
                        InsuranceExpertisestatus = " and mrd.InsuranceExpertisestatus=0";
                    }
                    else if (cboTrangThai.Text == "Đang điều trị")
                    {
                        InsuranceExpertisestatus = " and mrd.InsuranceExpertisestatus=2";
                    }
                    else if (cboTrangThai.Text == "Đã đóng bệnh án")
                    {
                        InsuranceExpertisestatus = " and mrd.InsuranceExpertisestatus=99";
                    }

                    string getdsbenhnhan = "SELECT ROW_NUMBER () OVER (ORDER BY InsuranceExpertisestatus, mrd.thoigianvaovien desc) as stt, hsba.patientid, hsba.patientcode, hsba.patientname, mrd.InsuranceExpertiseid, mrd.InsuranceExpertisecode, hsba.bhytcode, mrd.thoigianvaovien, mrd.InsuranceExpertisestatus, hsba.hosobenhanid, hsba.hosobenhanstatus, mrd.departmentgroupid, mrd.departmentid, mrd.vienphiid, mrd.chandoanbandau FROM InsuranceExpertise mrd inner join hosobenhan hsba on mrd.hosobenhanid=hsba.hosobenhanid WHERE mrd.thoigianvaovien>='" + thoiGianTu + "' and mrd.thoigianvaovien<='" + thoiGianDen + "'" + InsuranceExpertisestatus + " and mrd.departmentid='" + cboPhong.EditValue.ToString() + "'; ";
                    gridControlDSHSBA.DataSource = condb.GetDataTable_HIS(getdsbenhnhan);
                    if (gridViewDSHSBA.RowCount > 0)
                    {
                        gridViewDSHSBA.FocusedRowHandle = 0;
                        gridControlDSHSBA_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void xtraTabTTHSBA_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (this.SelectRowInsuranceExpertise != null)
                {
                    if (e.Page.Name == xtraTabThongTinChung.Name)
                    {
                        if (tabload_thongtinbenhan == 0)
                        {
                            ucDSHoSoBenhAn_ThongTinChung_Load(this.SelectRowInsuranceExpertise);
                            tabload_thongtinbenhan = 1;
                        }
                    }
                    else if (e.Page.Name == xtraTabBenhAn.Name)
                    {
                        if (tabload_benhan == 0)
                        {
                            ucDSHoSoBenhAn_BenhAn_Load(this.SelectRowInsuranceExpertise);
                            tabload_benhan = 1;
                        }
                    }
                    else if (e.Page.Name == xtraTabPTTT.Name)
                    {
                        if (tabload_pttt == 0)
                        {
                            ucDSHoSoBenhAn_PTTT_Load(this.SelectRowInsuranceExpertise);
                            tabload_pttt = 1;
                        }
                    }
                    else if (e.Page.Name == xtraTabHoiChan.Name)
                    {
                        if (tabload_hoichan == 0)
                        {
                            ucDSHoSoBenhAn_HoiChan_Load(this.SelectRowInsuranceExpertise);
                            tabload_hoichan = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void gridViewDSHSBA_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                //if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                //{
                //    e.Menu.Items.Clear();
                //    DXMenuItem itemXoaPhieuChiDinh = new DXMenuItem("Nhập hồ sơ bệnh án");
                //    itemXoaPhieuChiDinh.Image = imMenu.Images[0];
                //    //itemXoaToanBA.Shortcut = Shortcut.F6;
                //    itemXoaPhieuChiDinh.Click += new EventHandler(ItemNhapHoSoBenhAn_Click);
                //    e.Menu.Items.Add(itemXoaPhieuChiDinh);
                //}
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        void ItemNhapHoSoBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy giá trị tại dòng click chuột
                var rowHandle = gridViewDSHSBA.FocusedRowHandle;
                InsuranceExpertiseDTO filterDTO = new InsuranceExpertiseDTO();
                filterDTO.InsuranceExpertiseid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "InsuranceExpertiseid").ToString());
                filterDTO.hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "hosobenhanid").ToString());
                filterDTO.InsuranceExpertisestatus = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "InsuranceExpertisestatus").ToString());
                filterDTO.departmentid = Utilities.Util_TypeConvertParse.ToInt64(cboPhong.EditValue.ToString());

                if (filterDTO.InsuranceExpertisestatus == 0)
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.BENH_NHAN_CHUA_DUOC_TIEP_NHAN_VAO_PHONG);
                    frmthongbao.Show();
                }
                else if (filterDTO.InsuranceExpertisestatus == 2)
                {
                    frmChonLoaiBenhAn frmChon = new frmChonLoaiBenhAn(filterDTO);
                    frmChon.ShowDialog();
                }
                else
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.BENH_AN_DA_KET_THUC);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        #region Click row Benh Nhan
        private void gridControlDSHSBA_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSHSBA.FocusedRowHandle;
                SelectRowInsuranceExpertise = new InsuranceExpertiseDTO();
                SelectRowInsuranceExpertise.InsuranceExpertiseid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "InsuranceExpertiseid").ToString());
                SelectRowInsuranceExpertise.hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "hosobenhanid").ToString());
                SelectRowInsuranceExpertise.InsuranceExpertisestatus = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "InsuranceExpertisestatus").ToString());
                SelectRowInsuranceExpertise.departmentid = Utilities.Util_TypeConvertParse.ToInt64(cboPhong.EditValue.ToString());
                SelectRowInsuranceExpertise.hosobenhanstatus = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "hosobenhanstatus").ToString());
                SelectRowInsuranceExpertise.patientid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "patientid").ToString());
                SelectRowInsuranceExpertise.vienphiid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "vienphiid").ToString());
                SelectRowInsuranceExpertise.departmentgroupid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "departmentgroupid").ToString());
                SelectRowInsuranceExpertise.departmentid = Utilities.Util_TypeConvertParse.ToInt64(gridViewDSHSBA.GetRowCellValue(rowHandle, "departmentid").ToString());
                SelectRowInsuranceExpertise.chandoanbandau = gridViewDSHSBA.GetRowCellValue(rowHandle, "chandoanbandau").ToString();

                LoadDataTabChucNangClickRow(this.SelectRowInsuranceExpertise);
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void LoadDataTabChucNangClickRow(InsuranceExpertiseDTO filterDTO)
        {
            try
            {
                tabload_thongtinbenhan = 0;
                tabload_benhan = 0;
                tabload_pttt = 0;
                tabload_hoichan = 0;

                if (xtraTabDSHSBA.SelectedTabPage.Name == xtraTabThongTinChung.Name)
                {
                    ucDSHoSoBenhAn_ThongTinChung_Load(filterDTO);
                    tabload_thongtinbenhan = 1;

                    BenhAn_LoadBenhAnCuaBenhNhan(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_PT(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_Thuoc(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_CV(filterDTO);
                }
                else if (xtraTabDSHSBA.SelectedTabPage.Name == xtraTabBenhAn.Name)
                {
                    ucDSHoSoBenhAn_BenhAn_Load(filterDTO);
                    tabload_benhan = 1;

                    HoiChan_KiemTraTaoPhieuHoiChan_PT(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_Thuoc(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_CV(filterDTO);
                }
                else if (xtraTabDSHSBA.SelectedTabPage.Name == xtraTabPTTT.Name)
                {
                    ucDSHoSoBenhAn_PTTT_Load(filterDTO);
                    tabload_pttt = 1;

                    BenhAn_LoadBenhAnCuaBenhNhan(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_PT(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_Thuoc(filterDTO);
                    HoiChan_KiemTraTaoPhieuHoiChan_CV(filterDTO);
                }
                else if (xtraTabDSHSBA.SelectedTabPage.Name == xtraTabHoiChan.Name)
                {
                    ucDSHoSoBenhAn_HoiChan_Load(filterDTO);
                    tabload_hoichan = 1;

                    BenhAn_LoadBenhAnCuaBenhNhan(filterDTO);
                }
                KiemTraHienThiHighLightTab();
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }


        #endregion

        #region Custom
        private void cboPhong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void dateTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.EditValue != null || cboPhong.EditValue != null)
                {
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void dateDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.EditValue != null || cboPhong.EditValue != null)
                {
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void gridViewDSHSBA_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridViewDSHSBA_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "status_img")
                {
                    string val = Convert.ToString(gridViewDSHSBA.GetRowCellValue(e.RowHandle, "InsuranceExpertisestatus"));
                    if (val == "2")
                    {
                        e.Handled = true;
                        Point pos = Util_GUIGridView.CalcPosition(e, imageListstatus.Images[0]);
                        e.Graphics.DrawImage(imageListstatus.Images[0], pos);
                    }
                    else if (val == "99")
                    {
                        e.Handled = true;
                        Point pos = Util_GUIGridView.CalcPosition(e, imageListstatus.Images[1]);
                        e.Graphics.DrawImage(imageListstatus.Images[1], pos);
                    }

                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void cboKhoa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.EditValue != null)
                {
                    //Load danh muc phong thuoc khoa
                    var lstDSPhong = Base.SessionLogin.SessionlstPhanQuyen_KhoaPhong.Where(o => o.departmentgroupid == Utilities.Util_TypeConvertParse.ToInt64(cboKhoa.EditValue.ToString())).OrderBy(o => o.departmentname).ToList();
                    if (lstDSPhong != null && lstDSPhong.Count > 0)
                    {
                        cboPhong.Properties.DataSource = lstDSPhong;
                        cboPhong.Properties.DisplayMember = "departmentname";
                        cboPhong.Properties.ValueMember = "departmentid";
                    }
                    if (lstDSPhong.Count == 1)
                    {
                        cboPhong.ItemIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void KiemTraHienThiHighLightTab()
        {
            try
            {
                //Tab Benh an
                if (this.highlight_tabBenhAn)
                {
                    xtraTabBenhAn.Appearance.Header.BackColor = System.Drawing.Color.Tomato; //set mau sac cho tab
                }
                else
                {
                    xtraTabBenhAn.Appearance.Header.BackColor = System.Drawing.Color.Transparent;
                }

                //Tab Hoi chan
                if (btnHoiChan_PhauThuat.Enabled == false && btnHoiChan_Thuoc.Enabled == false && btnHoiChan_ChuyenVien.Enabled == false)
                {
                    xtraTabHoiChan.Appearance.Header.BackColor = System.Drawing.Color.Transparent;
                }
                else
                {
                    xtraTabHoiChan.Appearance.Header.BackColor = System.Drawing.Color.Tomato; //set mau sac cho tab
                }


            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        private bool KiemTraHighLightTab_PTTT()
        {
            bool result = false;
            try
            {
                string sqlKiemtra = "";
                DataTable dataPTTT = condb.GetDataTable_Dblink(sqlKiemtra);
                if (dataPTTT != null && dataPTTT.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
            return result;
        }

        #endregion















    }
}
