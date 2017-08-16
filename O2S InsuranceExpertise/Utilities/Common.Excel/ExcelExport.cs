﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.IO;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.Utilities.Common.Excel
{
    public class ExcelExport
    {
        #region Process_TMP
        private DataTable InsertOrders(List<Model.Models.reportExcelDTO> thongTinThem)
        {
            DataTable orderTable = new DataTable("DATA");
            try
            {
                if (thongTinThem != null && thongTinThem.Count > 0)
                {
                    foreach (var item_name in thongTinThem)
                    {
                        orderTable.Columns.Add(item_name.name, typeof(string));
                    }
                    orderTable.Columns.Add("CURRENTDATETIME", typeof(string));

                    DataRow newRow = orderTable.NewRow();
                    foreach (var item_value in thongTinThem)
                    {
                        newRow[item_value.name] = item_value.value;
                    }
                    newRow["CURRENTDATETIME"] = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    orderTable.Columns.Add("SOYTE", typeof(string));
                    newRow["SOYTE"] = GlobalStore.SoYTe_String;

                    orderTable.Columns.Add("TENBENHVIEN", typeof(string));
                    newRow["TENBENHVIEN"] = GlobalStore.TenBenhVien_String;

                    orderTable.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
            }
            return orderTable;
        }

        #endregion


        public void ExportExcelTemplate(string pv_sErr, string fileNameTemplate, List<Model.Models.reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            try
            {
                DataSet dataExportExcel = new DataSet();
                dataExportExcel.Tables.Add(InsertOrders(thongTinThem));

                DataTable dataTableCopy = dataTable.Copy();
                dataExportExcel.Tables.Add(dataTableCopy);

                string fileTemplatePath = Environment.CurrentDirectory + "\\Templates\\" + fileNameTemplate;
                WorkbookDesigner designer;
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel 2010 (.xlsx)|*.xlsx |Excel 2003 (.xls)|*.xls|Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        if (File.Exists(fileTemplatePath))
                        {
                            designer = new WorkbookDesigner();
                            string strRoot = Environment.CurrentDirectory + "\\Library\\";
                            Aspose.Cells.License l = new Aspose.Cells.License();
                            string strLicense = strRoot + "Aspose.Cells.lic";
                            l.SetLicense(strLicense);
                            designer.Open(fileTemplatePath);
                            if (dataExportExcel.Tables.Count > 0)
                            {
                                dataExportExcel.Tables[0].TableName = "DATA";
                                for (int i = 1; i < dataExportExcel.Tables.Count; i++)
                                {
                                    dataExportExcel.Tables[i].TableName = "DATA" + i;
                                }
                                designer.SetDataSource(dataExportExcel);
                                designer.Process();
                                designer.Workbook.CalculateFormula();
                                switch (fileExtenstion)
                                {
                                    case ".xls":
                                        designer.Workbook.Save(exportFilePath, new XlsSaveOptions(SaveFormat.Excel97To2003));
                                        break;
                                    case ".xlsx":
                                        designer.Workbook.Save(exportFilePath, new XlsSaveOptions(SaveFormat.Xlsx));
                                        break;
                                    case ".pdf":
                                        designer.Workbook.Save(exportFilePath, new XlsSaveOptions(SaveFormat.Pdf));
                                        break;
                                    case ".html":
                                        designer.Workbook.Save(exportFilePath, new XlsSaveOptions(SaveFormat.Html));
                                        break;
                                    default:
                                        designer.Workbook.Save(exportFilePath, new XlsSaveOptions(SaveFormat.Excel97To2003));
                                        break;
                                }
                                O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.EXPORT_DU_LIEU_THANH_CONG);
                                frmthongbao.Show();
                            }
                        }
                        else
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.KHONG_TIM_THAY_TEMPLATE_BAO_CAO);
                            frmthongbao.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
                MessageBox.Show("Export dữ liệu thất bại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportDataGridViewToFile(DevExpress.XtraGrid.GridControl gridControlData, DevExpress.XtraGrid.Views.Grid.GridView gridViewData)
        {
            if (gridViewData.RowCount > 0)
            {
                try
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Excel 2003 (.xls)|*.xls|Excel 2010 (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                        if (saveDialog.ShowDialog() != DialogResult.Cancel)
                        {
                            string exportFilePath = saveDialog.FileName;
                            string fileExtenstion = new FileInfo(exportFilePath).Extension;

                            switch (fileExtenstion)
                            {
                                case ".xls":
                                    gridControlData.ExportToXls(exportFilePath);
                                    break;
                                case ".xlsx":
                                    gridControlData.ExportToXlsx(exportFilePath);
                                    break;
                                case ".rtf":
                                    gridControlData.ExportToRtf(exportFilePath);
                                    break;
                                case ".pdf":
                                    gridControlData.ExportToPdf(exportFilePath);
                                    break;
                                case ".html":
                                    gridControlData.ExportToHtml(exportFilePath);
                                    break;
                                case ".mht":
                                    gridControlData.ExportToMht(exportFilePath);
                                    break;
                                default:
                                    break;
                            }
                            MessageBox.Show("Export dữ liệu thành công!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
                    MessageBox.Show("Export dữ liệu thất bại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public MemoryStream ExportExcelTemplate_ToStream(string pv_sErr, string fileNameTemplate, List<Model.Models.reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            MemoryStream result = new MemoryStream();
            try
            {
                DataSet dataExportExcel = new DataSet();
                dataExportExcel.Tables.Add(InsertOrders(thongTinThem));

                DataTable dataTableCopy = dataTable.Copy();
                dataExportExcel.Tables.Add(dataTableCopy);

                string fileTemplatePath = Environment.CurrentDirectory + "\\Templates\\" + fileNameTemplate;
                WorkbookDesigner designer;

                if (File.Exists(fileTemplatePath))
                {
                    designer = new WorkbookDesigner();
                    string strRoot = Environment.CurrentDirectory + "\\Library\\";
                    Aspose.Cells.License l = new Aspose.Cells.License();
                    string strLicense = strRoot + "Aspose.Cells.lic";
                    l.SetLicense(strLicense);
                    designer.Open(fileTemplatePath);
                    if (dataExportExcel.Tables.Count > 0)
                    {
                        dataExportExcel.Tables[0].TableName = "DATA";
                        for (int i = 1; i < dataExportExcel.Tables.Count; i++)
                        {
                            dataExportExcel.Tables[i].TableName = "DATA" + i;
                        }
                        designer.SetDataSource(dataExportExcel);
                        designer.Process();
                        designer.Workbook.CalculateFormula();
                        designer.Workbook.Save(result, new XlsSaveOptions(SaveFormat.Xlsx));
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }


    }
}
