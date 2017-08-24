using Newtonsoft.Json;
using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace O2S_InsuranceExpertise.Server.Process
{
    public class LayThongTinChoPortal
    {
        private Base.ConnectDatabase condb = new Base.ConnectDatabase();
        private HttpClient client = new HttpClient();


        public void GetTaiKhoanvaTokenPortal()
        {
            try
            {
                LayThongTinVeTaiKhoan_CongBHYT();
                LayToken_CongBHYT();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Lay thong tin phuc vu check API cong BHYT
        internal void LayThongTinVeTaiKhoan_CongBHYT()
        {
            try
            {
                if (GlobalStore.UserName_GDBHYT == null)
                {
                    string sql_getThongTin = "select usergdbhyt,passgdbhyt,urlfullserver,matinh,macskcb from ie_config where configtype=1;";
                    DataTable dataTaiKhoan = condb.GetDataTable_HSBA(sql_getThongTin);
                    if (dataTaiKhoan != null && dataTaiKhoan.Rows.Count > 0)
                    {
                        GlobalStore.UserName_GDBHYT = dataTaiKhoan.Rows[0]["usergdbhyt"].ToString();
                        GlobalStore.Password_GDBHYT = dataTaiKhoan.Rows[0]["passgdbhyt"].ToString();
                        GlobalStore.MaTinh = dataTaiKhoan.Rows[0]["matinh"].ToString();
                        GlobalStore.MaCSKCB = dataTaiKhoan.Rows[0]["macskcb"].ToString();
                        GlobalStore.Password_GDBHYT_MD5 = Common.EncryptAndDecrypt.EncryptAndDecrypt.CalculateMD5Hash(GlobalStore.Password_GDBHYT);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi lay thong tin tai khoan tu DB Giam dinh " + ex.ToString());
            }
        }
        internal void LayToken_CongBHYT()
        {
            try
            {
                //if (GlobalStore.tokenSession == null)
                //{
                client = new HttpClient();
                client.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string username = GlobalStore.UserName_GDBHYT;
                string password = GlobalStore.Password_GDBHYT_MD5;
                //HTTP POST
                ApiTokenDTO input = new ApiTokenDTO { username = username, password = password };
                var values = new Dictionary<string, string>
                {
                    { "username",username},
                    { "password",password}
                };
                var content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = client.PostAsync("api/token/take", content).Result;

                GlobalStore.tokenSession = new TokenDTO();
                if (response.IsSuccessStatusCode)
                {
                    GlobalStore.tokenSession = response.Content.ReadAsAsync<TokenDTO>().Result;
                }
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi lay token tu cong BHYT " + ex.ToString());
            }
        }
        #endregion
    }
}