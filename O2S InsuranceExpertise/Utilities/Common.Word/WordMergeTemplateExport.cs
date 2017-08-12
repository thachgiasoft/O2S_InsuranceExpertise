﻿using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O2S_InsuranceExpertise.Utilities.Common.Word
{
    public class WordMergeTemplateExport
    {
        public static void ExportWordMailMerge(string filePath, string saveFile, DataTable dt)
        {
            try
            {
                string strRoot = Environment.CurrentDirectory;

                Aspose.Words.License l = new Aspose.Words.License();
                string strLicense = strRoot + "Library\\Aspose.Words.lic";
                l.SetLicense(strLicense);

                string path = strRoot + filePath;

                Aspose.Words.Document doc = new Aspose.Words.Document(path);
                doc.MailMerge.Execute(dt);
                doc.Save(saveFile, SaveFormat.Docx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Aspose.Words.Document ExportWordMailMerge(string fileFullPath, DataTable dt, string filetempname)
        {
            Aspose.Words.Document doc = new Document();
            try
            {
                string strRoot = Environment.CurrentDirectory;
                // Aspose.Words.License l = new Aspose.Words.License();
                //string strLicense = strRoot + "\\Library\\Aspose.Words.lic";
                // l.SetLicense(strLicense);
                Aspose.Words.Document docccc = new Aspose.Words.Document(fileFullPath);
                doc = docccc.Clone();
                doc.MailMerge.Execute(dt);
                doc.Save(strRoot + "\\Templates\\ReportTemps\\" + filetempname, SaveFormat.Docx);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Warn(ex);
            }
            return doc;
        }

        public static Aspose.Words.Document ExportWordMailMergeFormat(string fileFullPath, DataTable dt, string filetempname, SaveFormat format)
        {
            Aspose.Words.Document doc = new Document();
            try
            {
                string strRoot = Environment.CurrentDirectory;
                Aspose.Words.License l = new Aspose.Words.License();
                string strLicense = strRoot + "\\Library\\Aspose.Words.lic";
                l.SetLicense(strLicense);
                Aspose.Words.Document docccc = new Aspose.Words.Document(fileFullPath);
                doc = docccc.Clone();
                doc.MailMerge.Execute(dt);
                doc.Save(strRoot + "\\Templates\\ReportTemps\\" + filetempname, format);
                //doc.Print();
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Warn(ex);
            }
            return doc;
        }

        public static MemoryStream ExportWordMailMerge_ToStream(string fileFullPath, DataTable dt)
        {
            MemoryStream result = new MemoryStream();
            try
            {
                Aspose.Words.Document doc = new Document();
                string strRoot = Environment.CurrentDirectory;
                // Aspose.Words.License l = new Aspose.Words.License();
                //string strLicense = strRoot + "\\Library\\Aspose.Words.lic";
                // l.SetLicense(strLicense);
                Aspose.Words.Document docccc = new Aspose.Words.Document(fileFullPath);
                doc = docccc.Clone();
                doc.MailMerge.Execute(dt);
                doc.Save(result, SaveFormat.Docx);
                // doc.Save(strRoot + "\\Templates\\ReportTemps\\" + filetempname, SaveFormat.Docx);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

    }
}
