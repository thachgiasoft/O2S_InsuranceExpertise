using O2S_InsuranceExpertise.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.BUS
{
    public class LoadDataSystems
    {
        static O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();

        #region LoadData Phan Mem
        public static void LoadTaiKhoanCongBHYT()
        {
            try
            {
                string sql_getdulieu = "SELECT usergdbhyt,passgdbhyt,urlfullserver FROM ie_config WHERE configtype=1;";
                DataTable dt_CauHinh = condb.GetDataTable_HSBA(sql_getdulieu);
                if (dt_CauHinh != null && dt_CauHinh.Rows.Count > 0)
                {
                    Base.SessionLogin.UserName_GDBHYT = dt_CauHinh.Rows[0]["usergdbhyt"].ToString();
                    Base.SessionLogin.Password_GDBHYT = dt_CauHinh.Rows[0]["passgdbhyt"].ToString();
                    Base.SessionLogin.Password_GDBHYT_MD5 = Base.EncryptAndDecrypt.CalculateMD5Hash(Base.SessionLogin.Password_GDBHYT);
                    Base.SessionLogin.UrlFullServer = dt_CauHinh.Rows[0]["urlfullserver"].ToString();
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        //public static void Load_MrdHsbaTemplate()
        //{
        //    try
        //    {
        //        GlobalStore.GlobalLst_MrdHsbaTemplate = new List<DTO.MrdHsbaTemplateDTO>();
        //        string sqlLayDanhMuc = "select ROW_NUMBER() OVER (ORDER BY ie_hsbatemname) as stt, ie_hsbatemid, ie_hsbatemcode, ie_hsbatemname, ie_hsbatemtypeid, ie_hsbatemnamepath from ie_hsba_template; ";
        //        DataView dv_DanhMucDichVu = new DataView(condb.GetDataTable_HSBA(sqlLayDanhMuc));
        //        if (dv_DanhMucDichVu.Count > 0)
        //        {
        //            for (int i = 0; i < dv_DanhMucDichVu.Count; i++)
        //            {
        //                MrdHsbaTemplateDTO dmDichVu = new MrdHsbaTemplateDTO();
        //                dmDichVu.ie_hsbatemid = Common.TypeConvert.TypeConvertParse.ToInt64(dv_DanhMucDichVu[i]["ie_hsbatemid"].ToString());
        //                dmDichVu.ie_hsbatemcode = dv_DanhMucDichVu[i]["ie_hsbatemcode"].ToString();
        //                dmDichVu.ie_hsbatemname = dv_DanhMucDichVu[i]["ie_hsbatemname"].ToString();
        //                dmDichVu.ie_hsbatemtypeid = Common.TypeConvert.TypeConvertParse.ToInt64(dv_DanhMucDichVu[i]["ie_hsbatemtypeid"].ToString());
        //                dmDichVu.ie_hsbatemnamepath = dv_DanhMucDichVu[i]["ie_hsbatemnamepath"].ToString();

        //                GlobalStore.GlobalLst_MrdHsbaTemplate.Add(dmDichVu);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        O2S_InsuranceExpertise.Base.Logging.Warn(ex);
        //    }
        //}
        #endregion
    }
}
