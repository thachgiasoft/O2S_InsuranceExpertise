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
    public partial class ucCauHinhTheXML_XML : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private int loaihoso { get; set; }
        private List<Model.Models.TheFileXMLDTO> lstTheFileXML { get; set; }
        public ucCauHinhTheXML_XML()
        {
            InitializeComponent();
        }
        public ucCauHinhTheXML_XML(int _loaihoso)
        {
            InitializeComponent();
            this.loaihoso = _loaihoso;
        }

        #region Load
        private void ucCauHinhTheXML_XML1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNoiDungTheXML();
                EnableAndDisableControl();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadNoiDungTheXML()
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                gridControlTheXML.DataSource = null;
                string sql_thehoso = "";
                switch (this.loaihoso)
                {
                    case 1:
                        {
                            sql_thehoso = "select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml1;";
                            break;
                        }
                    case 2:
                        {
                            sql_thehoso = " select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml2;";
                            break;
                        }
                    case 3:
                        {
                            sql_thehoso = " select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml3;";
                            break;
                        }
                    case 4:
                        {
                            sql_thehoso = " select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml4;";
                            break;
                        }
                    case 5:
                        {
                            sql_thehoso = " select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml5;";
                            break;
                        }
                    default:
                        break;
                }

                DataTable dataDMDV = condb.GetDataTable_HSBA(sql_thehoso);
                this.lstTheFileXML = new List<Model.Models.TheFileXMLDTO>();
                if (dataDMDV != null && dataDMDV.Rows.Count > 0)
                {
                    foreach (DataRow row in dataDMDV.Rows)
                    {
                        Model.Models.TheFileXMLDTO _thefileXml = new Model.Models.TheFileXMLDTO();
                        _thefileXml.thefilexmlid = Common.TypeConvert.TypeConvertParse.ToInt64(row["thefilexmlid"].ToString());
                        _thefileXml.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["stt"].ToString());
                        _thefileXml.MA_THE = row["ma_the"].ToString();
                        _thefileXml.TEN_THE = row["ten_the"].ToString();
                        _thefileXml.KIEU_DU_LIEU = row["kieu_du_lieu"].ToString();
                        _thefileXml.KT_TOIDA = Common.TypeConvert.TypeConvertParse.ToInt64(row["kt_toida"].ToString());
                        _thefileXml.BAT_BUOC = Common.TypeConvert.TypeConvertParse.ToInt16(row["bat_buoc"].ToString());
                        _thefileXml.DIEN_GIAI = row["dien_giai"].ToString();
                        _thefileXml.GHI_CHU = row["ghi_chu"].ToString();
                        this.lstTheFileXML.Add(_thefileXml);
                    }
                }
                gridControlTheXML.DataSource = this.lstTheFileXML;
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
                    this.lstTheFileXML = new List<Model.Models.TheFileXMLDTO>();
                    gridControlTheXML.DataSource = null;
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[0];
                    switch (this.loaihoso)
                    {
                        case 1:
                            {
                                worksheet = workbook.Worksheets[0];
                                break;
                            }
                        case 2:
                            {
                                worksheet = workbook.Worksheets[1];
                                break;
                            }
                        case 3:
                            {
                                worksheet = workbook.Worksheets[2];
                                break;
                            }
                        case 4:
                            {
                                worksheet = workbook.Worksheets[3];
                                break;
                            }
                        case 5:
                            {
                                worksheet = workbook.Worksheets[4];
                                break;
                            }
                        default:
                            break;
                    }
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow + 1, worksheet.Cells.MaxDataColumn + 1, true);
                    data_Excel.TableName = "DATA";
                    if (data_Excel != null)
                    {
                        foreach (DataRow row in data_Excel.Rows)
                        {
                            Model.Models.TheFileXMLDTO _thefileXml = new Model.Models.TheFileXMLDTO();
                            _thefileXml.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                            _thefileXml.MA_THE = row["MA_THE"].ToString();
                            _thefileXml.TEN_THE = row["TEN_THE"].ToString();
                            _thefileXml.KIEU_DU_LIEU = row["KIEU_DU_LIEU"].ToString();
                            if (row["KT_TOIDA"].ToString() != "")
                            {
                                _thefileXml.KT_TOIDA = Common.TypeConvert.TypeConvertParse.ToInt64(row["KT_TOIDA"].ToString());
                            }
                            if (row["BAT_BUOC"].ToString() != "")
                            {
                                _thefileXml.BAT_BUOC = 1;
                            }                           
                            _thefileXml.DIEN_GIAI = row["DIEN_GIAI"].ToString();
                            _thefileXml.GHI_CHU = row["GHI_CHU"].ToString();
                            this.lstTheFileXML.Add(_thefileXml);
                        }
                        gridControlTheXML.DataSource = this.lstTheFileXML;
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
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                int insert_count = 0;
                foreach (var item_dv in this.lstTheFileXML)
                {
                    try
                    {
                        string _tabletheFileXML = "";
                        switch (this.loaihoso)
                        {
                            case 1:
                                {
                                    _tabletheFileXML = " ie_thefile_xml1";
                                    break;
                                }
                            case 2:
                                {
                                    _tabletheFileXML = " ie_thefile_xml2";
                                    break;
                                }
                            case 3:
                                {
                                    _tabletheFileXML = " ie_thefile_xml3";
                                    break;
                                }
                            case 4:
                                {
                                    _tabletheFileXML = " ie_thefile_xml4";
                                    break;
                                }
                            case 5:
                                {
                                    _tabletheFileXML = " ie_thefile_xml5";
                                    break;
                                }
                            default:
                                break;
                        }
                        string sql_insert = "INSERT INTO " + _tabletheFileXML + "(stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu, is_look, version) VALUES ('" + item_dv.STT + "', '" + item_dv.MA_THE + "', '" + item_dv.TEN_THE + "', '" + item_dv.KIEU_DU_LIEU + "', '" + item_dv.KT_TOIDA + "', '" + item_dv.BAT_BUOC + "', '" + item_dv.DIEN_GIAI + "', '" + item_dv.GHI_CHU + "', '0', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                        if (condb.ExecuteNonQuery_HSBA(sql_insert))
                        {
                            insert_count += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error("Loi insert ie_thefile_xml??? " + ex.ToString());
                        continue;
                    }
                }
                MessageBox.Show("Thêm mới [" + insert_count + "/" + this.lstTheFileXML.Count + "] thẻ file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            ucCauHinhTheXML_XML1_Load(null, null);
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
                        DXMenuItem itemKiemTraDaChon = new DXMenuItem("Xóa thẻ file XML đã chọn"); // caption menu
                        itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                        itemKiemTraDaChon.Click += new EventHandler(XoaTheFileXMLDaChon_Click);// thêm sự kiện click
                        e.Menu.Items.Add(itemKiemTraDaChon);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void XoaTheFileXMLDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewTheXML.RowCount > 0)
                {
                    string sql_deleteDV = "";
                    string _tabletheFileXML = "";
                    switch (this.loaihoso)
                    {
                        case 1:
                            {
                                _tabletheFileXML = " ie_thefile_xml1";
                                break;
                            }
                        case 2:
                            {
                                _tabletheFileXML = " ie_thefile_xml2";
                                break;
                            }
                        case 3:
                            {
                                _tabletheFileXML = " ie_thefile_xml3";
                                break;
                            }
                        case 4:
                            {
                                _tabletheFileXML = " ie_thefile_xml4";
                                break;
                            }
                        case 5:
                            {
                                _tabletheFileXML = " ie_thefile_xml5";
                                break;
                            }
                        default:
                            break;
                    }

                    foreach (var item_index in gridViewTheXML.GetSelectedRows())
                    {
                        string _thefilexmlid = gridViewTheXML.GetRowCellValue(item_index, "thefilexmlid").ToString();
                        sql_deleteDV += "DELETE FROM " + _tabletheFileXML + " where thefilexmlid='" + _thefilexmlid + "'; ";
                    }
                    condb.ExecuteNonQuery_HSBA(sql_deleteDV);
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                    frmthongbao.Show();
                    ucCauHinhTheXML_XML1_Load(null, null);
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
