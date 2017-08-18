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
    public partial class ucCauHinhDM_Thuoc : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        //private string worksheetName = "Sheet";
        private List<Model.Models.DanhMucDichVu_ThuocDTO> lstDichVuImport { get; set; }
        public ucCauHinhDM_Thuoc()
        {
            InitializeComponent();
        }

        #region Load
        private void ucCauHinhDM_Thuoc_Load(object sender, EventArgs e)
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
                string sql_getdmdv = "SELECT danhmucthuocid, stt, ma_hoat_chat, ma_ax, hoat_chat, hoatchat_ax, ma_duong_dung, ma_duongdung_ax, duong_dung, duongdung_ax, ham_luong, hamluong_ax, ten_thuoc, tenthuoc_ax, so_dang_ky, sodangky_ax, dong_goi, don_vi_tinh, don_gia, don_gia_tt, so_luong, ma_cskcb, hang_sx, nuoc_sx, nha_thau, quyet_dinh, cong_bo, ma_thuoc_bv, loai_thuoc, loai_thau, nhom_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look FROM ie_danhmuc_thuoc order by stt; ";
                DataTable dataDMDV = condb.GetDataTable_HSBA(sql_getdmdv);
                this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_ThuocDTO>();
                if (dataDMDV != null && dataDMDV.Rows.Count > 0)
                {
                    foreach (DataRow row in dataDMDV.Rows)
                    {
                        Model.Models.DanhMucDichVu_ThuocDTO dichVu = new Model.Models.DanhMucDichVu_ThuocDTO();
                        dichVu.danhmucthuocid = Common.TypeConvert.TypeConvertParse.ToInt64(row["danhmucthuocid"].ToString());
                        dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                        dichVu.MA_HOAT_CHAT = row["MA_HOAT_CHAT"].ToString();
                        dichVu.MA_AX = row["MA_AX"].ToString();
                        dichVu.HOAT_CHAT = row["HOAT_CHAT"].ToString();
                        dichVu.HOATCHAT_AX = row["HOATCHAT_AX"].ToString();
                        dichVu.MA_DUONG_DUNG = row["MA_DUONG_DUNG"].ToString();
                        dichVu.MA_DUONGDUNG_AX = row["MA_DUONGDUNG_AX"].ToString();
                        dichVu.DUONG_DUNG = row["DUONG_DUNG"].ToString();
                        dichVu.DUONGDUNG_AX = row["DUONGDUNG_AX"].ToString();
                        dichVu.HAM_LUONG = row["HAM_LUONG"].ToString();
                        dichVu.HAMLUONG_AX = row["HAMLUONG_AX"].ToString();
                        dichVu.TEN_THUOC = row["TEN_THUOC"].ToString();
                        dichVu.TENTHUOC_AX = row["TENTHUOC_AX"].ToString();
                        dichVu.SO_DANG_KY = row["SO_DANG_KY"].ToString();
                        dichVu.SODANGKY_AX = row["SODANGKY_AX"].ToString();
                        dichVu.DONG_GOI = row["DONG_GOI"].ToString();
                        dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                        dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                        dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
                        dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
                        dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
                        dichVu.HANG_SX = row["HANG_SX"].ToString();
                        dichVu.NUOC_SX = row["NUOC_SX"].ToString();
                        dichVu.NHA_THAU = row["NHA_THAU"].ToString();
                        dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                        dichVu.CONG_BO = row["CONG_BO"].ToString();
                        dichVu.MA_THUOC_BV = row["MA_THUOC_BV"].ToString();
                        dichVu.LOAI_THUOC = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THUOC"].ToString());
                        dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
                        dichVu.NHOM_THAU = row["NHOM_THAU"].ToString();
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
                    SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                    this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_ThuocDTO>();
                    gridControlDichVu.DataSource = null;
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[0];
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow + 1, worksheet.Cells.MaxDataColumn + 1, true);
                    data_Excel.TableName = "DATA";
                    if (data_Excel != null)
                    {
                        foreach (DataRow row in data_Excel.Rows)
                        {
                            Model.Models.DanhMucDichVu_ThuocDTO dichVu = new Model.Models.DanhMucDichVu_ThuocDTO();
                            dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                            dichVu.MA_HOAT_CHAT = row["MA_HOAT_CHAT"].ToString();
                            dichVu.MA_AX = row["MA_AX"].ToString();
                            dichVu.HOAT_CHAT = row["HOAT_CHAT"].ToString();
                            dichVu.HOATCHAT_AX = row["HOATCHAT_AX"].ToString();
                            dichVu.MA_DUONG_DUNG = row["MA_DUONG_DUNG"].ToString();
                            dichVu.MA_DUONGDUNG_AX = row["MA_DUONGDUNG_AX"].ToString();
                            dichVu.DUONG_DUNG = row["DUONG_DUNG"].ToString();
                            dichVu.DUONGDUNG_AX = row["DUONGDUNG_AX"].ToString();
                            dichVu.HAM_LUONG = row["HAM_LUONG"].ToString();
                            dichVu.HAMLUONG_AX = row["HAMLUONG_AX"].ToString();
                            dichVu.TEN_THUOC = row["TEN_THUOC"].ToString();
                            dichVu.TENTHUOC_AX = row["TENTHUOC_AX"].ToString();
                            dichVu.SO_DANG_KY = row["SO_DANG_KY"].ToString();
                            dichVu.SODANGKY_AX = row["SODANGKY_AX"].ToString();
                            dichVu.DONG_GOI = row["DONG_GOI"].ToString();
                            dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
                            dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                            dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
                            dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
                            dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
                            dichVu.HANG_SX = row["HANG_SX"].ToString();
                            dichVu.NUOC_SX = row["NUOC_SX"].ToString();
                            dichVu.NHA_THAU = row["NHA_THAU"].ToString();
                            dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                            dichVu.CONG_BO = row["CONG_BO"].ToString();
                            dichVu.MA_THUOC_BV = row["MA_THUOC_BV"].ToString();
                            dichVu.LOAI_THUOC = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THUOC"].ToString());
                            dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
                            dichVu.NHOM_THAU = row["NHOM_THAU"].ToString();
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
                        string sql_insert = "INSERT INTO ie_danhmuc_thuoc(stt, ma_hoat_chat, ma_ax, hoat_chat, hoatchat_ax, ma_duong_dung, ma_duongdung_ax, duong_dung, duongdung_ax, ham_luong, hamluong_ax, ten_thuoc, tenthuoc_ax, so_dang_ky, sodangky_ax, dong_goi, don_vi_tinh, don_gia, don_gia_tt, so_luong, ma_cskcb, hang_sx, nuoc_sx, nha_thau, quyet_dinh, cong_bo, ma_thuoc_bv, loai_thuoc, loai_thau, nhom_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look, version) VALUES ('" + item_dv.STT + "', '" + item_dv.MA_HOAT_CHAT + "', '" + item_dv.MA_AX + "', '" + item_dv.HOAT_CHAT.Replace("'", "''") + "', '" + item_dv.HOATCHAT_AX.Replace("'", "''") + "', '" + item_dv.MA_DUONG_DUNG + "', '" + item_dv.MA_DUONGDUNG_AX + "', '" + item_dv.DUONG_DUNG + "', '" + item_dv.DUONGDUNG_AX + "', '" + item_dv.HAM_LUONG + "', '" + item_dv.HAMLUONG_AX + "', '" + item_dv.TEN_THUOC.Replace("'", "''") + "', '" + item_dv.TENTHUOC_AX.Replace("'", "''") + "', '" + item_dv.SO_DANG_KY + "', '" + item_dv.SODANGKY_AX + "', '" + item_dv.DONG_GOI + "', '" + item_dv.DON_VI_TINH + "', '" + item_dv.DON_GIA.ToString().Replace(",", ".") + "', '" + item_dv.DON_GIA_TT.ToString().Replace(",", ".") + "', '" + item_dv.SO_LUONG + "', '" + item_dv.MA_CSKCB + "', '" + item_dv.HANG_SX.Replace("'", "''") + "', '" + item_dv.NUOC_SX.Replace("'", "''") + "', '" + item_dv.NHA_THAU.Replace("'", "''") + "', '" + item_dv.QUYET_DINH + "', '" + item_dv.CONG_BO + "', '" + item_dv.MA_THUOC_BV + "', '" + item_dv.LOAI_THUOC + "', '" + item_dv.LOAI_THAU + "', '" + item_dv.NHOM_THAU + "', '" + item_dv.MANHOM_9324 + "', '" + item_dv.HIEULUC_ID + "', '" + item_dv.HIEULUC + "', '" + item_dv.KETQUA_ID + "', '" + item_dv.KETQUA + "', '" + item_dv.LYDOTUCHOI + "','0','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ); ";
                        if (condb.ExecuteNonQuery_HSBA(sql_insert))
                        {
                            insert_count += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error("Loi insert ie_danhmuc_thuoc " + ex.ToString());
                        continue;
                    }
                }
                MessageBox.Show("Thêm mới [" + insert_count + "/" + this.lstDichVuImport.Count + "] thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            ucCauHinhDM_Thuoc_Load(null, null);
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
                        DXMenuItem itemKiemTraDaChon = new DXMenuItem("Xóa thuốc đã chọn"); // caption menu
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
                        string danhmucthuocid = gridViewDichVu.GetRowCellValue(item_index, "danhmucthuocid").ToString();
                        sql_deleteDV += "DELETE FROM ie_danhmuc_thuoc where danhmucthuocid='" + danhmucthuocid + "'; ";
                    }
                    condb.ExecuteNonQuery_HSBA(sql_deleteDV);
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                    frmthongbao.Show();
                    ucCauHinhDM_Thuoc_Load(null, null);
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
