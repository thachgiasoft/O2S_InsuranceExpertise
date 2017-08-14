using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Utilities.PrintPreview
{
    public static class PrintPreview_ExcelFileTemplate
    {
        public static void ShowPrintPreview_UsingExcelTemplate(string fileNameTemplate, List<Model.Models.reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            try
            {
                Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                MemoryStream streammemory = export.ExportExcelTemplate_ToStream("", fileNameTemplate, thongTinThem, dataTable);

                DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
                spreadsheetControl.AllowDrop = false;
                spreadsheetControl.LoadDocument(streammemory, DevExpress.Spreadsheet.DocumentFormat.OpenXml);
                DevExpress.Spreadsheet.IWorkbook workbook = spreadsheetControl.Document;
                spreadsheetControl.ShowRibbonPrintPreview();
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
