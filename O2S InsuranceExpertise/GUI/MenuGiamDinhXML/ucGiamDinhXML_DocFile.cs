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
using System.Configuration;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML
{
    public partial class ucGiamDinhXML_DocFile : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        public ucGiamDinhXML_DocFile()
        {
            InitializeComponent();
        }

        #region Load
        private void ucGiamDinhXML_DocFile_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFileXMLThuMucCauHinhSan();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadFileXMLThuMucCauHinhSan()
        {
            try
            {
                if (ConfigurationManager.AppSettings["DuongDanDocFileXML"].ToString() != "")
                {
                    string[] filePahts = System.IO.Directory.GetFiles(ConfigurationManager.AppSettings["DuongDanDocFileXML"].ToString(), "*.xml");
                    foreach (var item in filePahts)
                    {
                        //toto Read file XML

                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

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

        private void btnMoFileXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    Model.Models.Xml_917.XML_GIAMDINHHS _giamDinhHS = new Model.Models.Xml_917.XML_GIAMDINHHS();
                    _giamDinhHS = Common.Xml.ObjectXMLSerializer<Model.Models.Xml_917.XML_GIAMDINHHS>.Load(openFileDialogSelect.FileName);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void chkGhiNhoDuongDan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkGhiNhoDuongDan.Checked)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["DuongDanDocFileXML"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["DuongDanDocFileXML"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
