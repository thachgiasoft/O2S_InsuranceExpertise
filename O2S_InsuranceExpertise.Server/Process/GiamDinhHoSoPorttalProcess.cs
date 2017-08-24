using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace O2S_InsuranceExpertise.Server.Process
{
    public class GiamDinhHoSoPorttalProcess
    {
        private HttpClient clientPush = new HttpClient();

        public KQGuiHoSoGiamDinhPortalDTO GuiHoSoGiamDinh(byte[] _buffer)
        {
            KQGuiHoSoGiamDinhPortalDTO _kqGuiHSGD = new KQGuiHoSoGiamDinhPortalDTO();
            try
            {
                clientPush = new HttpClient();
                clientPush.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                clientPush.DefaultRequestHeaders.Accept.Clear();
                clientPush.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                clientPush.MaxResponseContentBufferSize = 2000005000;
                //HTTT POST
                string data2 = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}", GlobalStore.tokenSession.APIKey.access_token, GlobalStore.tokenSession.APIKey.id_token, GlobalStore.UserName_GDBHYT, GlobalStore.Password_GDBHYT_MD5, "3", GlobalStore.MaTinh, GlobalStore.MaCSKCB);
                HttpResponseMessage response = clientPush.PostAsJsonAsync("api/egw/guiHoSoGiamDinh?" + data2, _buffer).Result;

                if (response.IsSuccessStatusCode)
                {
                    _kqGuiHSGD = response.Content.ReadAsAsync<KQGuiHoSoGiamDinhPortalDTO>().Result;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi goi API len Portal BHYT guiHoSoGiamDinh" + ex.ToString());
            }
            return _kqGuiHSGD;
        }

        public NhanChiTietLoiHoSoPortalDTO NhanChiTietLoiHS(string _maGiaoDich)
        {
            NhanChiTietLoiHoSoPortalDTO result = new NhanChiTietLoiHoSoPortalDTO();
            try
            {
                clientPush = new HttpClient();
                clientPush.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                clientPush.DefaultRequestHeaders.Accept.Clear();
                clientPush.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTT POST
                string data2 = string.Format("token={0}&id_token={1}&username={2}&password={3}&maCSKCB={4}&maGiaoDich={5}", GlobalStore.tokenSession.APIKey.access_token, GlobalStore.tokenSession.APIKey.id_token, GlobalStore.UserName_GDBHYT, GlobalStore.Password_GDBHYT_MD5, GlobalStore.MaCSKCB, _maGiaoDich);

                HttpResponseMessage response = clientPush.PostAsync("api/egw/nhanChiTietLoiHS?" + data2, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<NhanChiTietLoiHoSoPortalDTO>().Result;
                    //if (result.dsLoi.Count == 0)
                    //{
                    //}
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi goi API len Portal BHYT nhanChiTietLoiHS" + ex.ToString());
            }
            return result;
        }


    }
}