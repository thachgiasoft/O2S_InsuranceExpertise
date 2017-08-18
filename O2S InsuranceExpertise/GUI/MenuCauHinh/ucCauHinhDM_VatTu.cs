using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Aspose.Cells;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace O2S_InsuranceExpertise.GUI.MenuCauHinh
{
    public partial class ucCauHinhDM_VatTu : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        //private string worksheetName = "Sheet";
        private List<Model.Models.DanhMucDichVu_VatTuDTO> lstDichVuImport { get; set; }
        public ucCauHinhDM_VatTu()
        {
            InitializeComponent();
        }

        #region Load
        private void ucCauHinhDM_VatTu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhMucDichVu();
                EnableAndDisableControl();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhMucDichVu()
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                gridControlDichVu.DataSource = null;
                string sql_getdmdv = "SELECT danhmucvattuid, stt, ma_nhom_vtyt, ma_nhom_ax, ten_nhom_vtyt, ten_nhom_ax, ma_hieu, ma_vtyt_bv, ten_vtyt_bv, quy_cach, nuoc_sx, hang_sx, don_vi_tinh, don_gia, don_gia_tt, nha_thau, quyet_dinh, cong_bo, dinh_muc, so_luong, ma_cskcb, loai_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look, version FROM ie_danhmuc_vattu order by stt;  ";
                DataTable dataDMDV = condb.GetDataTable_HSBA(sql_getdmdv);
                this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_VatTuDTO>();
                if (dataDMDV != null && dataDMDV.Rows.Count > 0)
                {
                    foreach (DataRow row in dataDMDV.Rows)
                    {
                        Model.Models.DanhMucDichVu_VatTuDTO dichVu = new Model.Models.DanhMucDichVu_VatTuDTO();
                        dichVu.danhmucvattuid = Common.TypeConvert.TypeConvertParse.ToInt64(row["danhmucvattuid"].ToString());
                        dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                        dichVu.MA_NHOM_VTYT = row["MA_NHOM_VTYT"].ToString();
                        dichVu.MA_NHOM_AX = row["MA_NHOM_AX"].ToString();
                        dichVu.TEN_NHOM_VTYT = row["TEN_NHOM_VTYT"].ToString();
                        dichVu.TEN_NHOM_AX = row["TEN_NHOM_AX"].ToString();
                        dichVu.MA_HIEU = row["MA_HIEU"].ToString();
                        dichVu.MA_VTYT_BV = row["MA_VTYT_BV"].ToString();
                        dichVu.TEN_VTYT_BV = row["TEN_VTYT_BV"].ToString();
                        dichVu.QUY_CACH = row["QUY_CACH"].ToString();
                        dichVu.NUOC_SX = row["NUOC_SX"].ToString();
                        dichVu.HANG_SX = row["HANG_SX"].ToString();
                        dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                        dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                        dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
                        dichVu.NHA_THAU = row["NHA_THAU"].ToString();
                        dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                        dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
                        dichVu.DINH_MUC = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DINH_MUC"].ToString());
                        dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
                        dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
                        dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
                        dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
                        dichVu.HIEULUC = row["HIEULUC"].ToString();
                        dichVu.KETQUA = row["KETQUA"].ToString();
                        dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

                        if (dichVu.HIEULUC.ToLower() == "có")
                        {
                            dichVu.HIEULUC_ID = 1;
                        }
                        if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
                        {
                            dichVu.KETQUA_ID = 1;
                        }

                        this.lstDichVuImport.Add(dichVu);
                    }
                }
                gridControlDichVu.DataSource = this.lstDichVuImport;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void EnableAndDisableControl()
        {
            try
            {
                btnLuuLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        private void btnNhapTuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_VatTuDTO>();
                    gridControlDichVu.DataSource = null;
                    SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[0];
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow + 1, worksheet.Cells.MaxDataColumn + 1, true);
                    data_Excel.TableName = "DATA";
                    if (data_Excel != null)
                    {
                        foreach (DataRow row in data_Excel.Rows)
                        {
                            Model.Models.DanhMucDichVu_VatTuDTO dichVu = new Model.Models.DanhMucDichVu_VatTuDTO();
                            dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                            dichVu.MA_NHOM_VTYT = row["MA_NHOM_VTYT"].ToString();
                            dichVu.MA_NHOM_AX = row["MA_NHOM_AX"].ToString();
                            dichVu.TEN_NHOM_VTYT = row["TEN_NHOM_VTYT"].ToString();
                            dichVu.TEN_NHOM_AX = row["TEN_NHOM_AX"].ToString();
                            dichVu.MA_HIEU = row["MA_HIEU"].ToString();
                            dichVu.MA_VTYT_BV = row["MA_VTYT_BV"].ToString();
                            dichVu.TEN_VTYT_BV = row["TEN_VTYT_BV"].ToString();
                            dichVu.QUY_CACH = row["QUY_CACH"].ToString();
                            dichVu.NUOC_SX = row["NUOC_SX"].ToString();
                            dichVu.HANG_SX = row["HANG_SX"].ToString();
                            dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                            dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                            dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
                            dichVu.NHA_THAU = row["NHA_THAU"].ToString();
                            dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                            dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
                            dichVu.DINH_MUC = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DINH_MUC"].ToString());
                            dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
                            dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
                            dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
                            dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
                            dichVu.HIEULUC = row["HIEULUC"].ToString();
                            dichVu.KETQUA = row["KETQUA"].ToString();
                            dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

                            if (dichVu.HIEULUC.ToLower() == "có")
                            {
                                dichVu.HIEULUC_ID = 1;
                            }
                            if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
                            {
                                dichVu.KETQUA_ID = 1;
                            }

                            this.lstDichVuImport.Add(dichVu);
                        }
                        gridControlDichVu.DataSource = this.lstDichVuImport;
                        btnLuuLai.Enabled = true;
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("File excel sai định dạng cấu trúc!");
                        frmthongbao.Show();
                        btnLuuLai.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                //SplashScreenManager.CloseForm();
            }
            SplashScreenManager.CloseForm();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                int insert_count = 0;
                foreach (var item_dv in this.lstDichVuImport)
                {
                    try
                    {
                        string sql_insert = "INSERT INTO ie_danhmuc_vattu(stt, ma_nhom_vtyt, ma_nhom_ax, ten_nhom_vtyt, ten_nhom_ax, ma_hieu, ma_vtyt_bv, ten_vtyt_bv, quy_cach, nuoc_sx, hang_sx, don_vi_tinh, don_gia, don_gia_tt, nha_thau, quyet_dinh, cong_bo, dinh_muc, so_luong, ma_cskcb, loai_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look, version) VALUES ('" + item_dv.STT + "', '" + item_dv.MA_NHOM_VTYT + "', '" + item_dv.MA_NHOM_AX + "', '" + item_dv.TEN_NHOM_VTYT.Replace("'","''") + "', '" + item_dv.TEN_NHOM_AX.Replace("'", "''") + "', '" + item_dv.MA_HIEU + "', '" + item_dv.MA_VTYT_BV.Replace("'", "''") + "', '" + item_dv.TEN_VTYT_BV.Replace("'", "''") + "', '" + item_dv.QUY_CACH.Replace("'", "''") + "', '" + item_dv.NUOC_SX.Replace("'", "''") + "', '" + item_dv.HANG_SX.Replace("'", "''") + "', '" + item_dv.DON_VI_TINH + "', '" + item_dv.DON_GIA.ToString().Replace(",", ".") + "', '" + item_dv.DON_GIA_TT.ToString().Replace(",", ".") + "', '" + item_dv.NHA_THAU.Replace("'", "''") + "', '" + item_dv.QUYET_DINH.Replace("'", "''") + "', '" + item_dv.CONG_BO + "', '" + item_dv.DINH_MUC + "', '" + item_dv.SO_LUONG.ToString().Replace(",", ".") + "', '" + item_dv.MA_CSKCB + "', '" + item_dv.LOAI_THAU + "', '" + item_dv.MANHOM_9324 + "', '" + item_dv.HIEULUC_ID + "', '" + item_dv.HIEULUC + "', '" + item_dv.KETQUA_ID + "', '" + item_dv.KETQUA + "', '" + item_dv.LYDOTUCHOI + "', '0', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');  ";
                        if (condb.ExecuteNonQuery_HSBA(sql_insert))
                        {
                            insert_count += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error("Loi insert ie_danhmuc_vattu " + ex.ToString());
                        continue;
                    }
                }
                MessageBox.Show("Thêm mới [" + insert_count + "/" + this.lstDichVuImport.Count + "] vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            ucCauHinhDM_VatTu_Load(null, null);
        }

        #region Custom
        private void gridViewDichVu_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Delete Row
        private void gridViewDichVu_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (!btnLuuLai.Enabled)
                {
                    if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                    {
                        //GridView view = sender as GridView;
                        e.Menu.Items.Clear();
                        DXMenuItem itemKiemTraDaChon = new DXMenuItem("Xóa vật tư đã chọn"); // caption menu
                        itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                        itemKiemTraDaChon.Click += new EventHandler(XoaDichVuDaChon_Click);// thêm sự kiện click
                        e.Menu.Items.Add(itemKiemTraDaChon);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void XoaDichVuDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDichVu.RowCount > 0)
                {
                    string sql_deleteDV = "";
                    foreach (var item_index in gridViewDichVu.GetSelectedRows())
                    {
                        string danhmucvattuid = gridViewDichVu.GetRowCellValue(item_index, "danhmucvattuid").ToString();
                        sql_deleteDV += "DELETE FROM ie_danhmuc_vattu where danhmucvattuid='" + danhmucvattuid + "'; ";
                    }
                    condb.ExecuteNonQuery_HSBA(sql_deleteDV);
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                    frmthongbao.Show();
                    ucCauHinhDM_VatTu_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion



    }
}
