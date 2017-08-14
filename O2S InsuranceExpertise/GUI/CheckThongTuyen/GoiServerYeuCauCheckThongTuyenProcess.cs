using DevExpress.XtraSplashScreen;
using Newtonsoft.Json;
using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    internal class GoiServerYeuCauCheckThongTuyenProcess
    {
        private HttpClient client_1 = new HttpClient();



        internal List<KetQuaCheckThongTuyen_ExtendDTO> YeuCauCheckThongTuyen_List(List<TheBHYTCheckThongTuyen_ThuCongDTO> _lstFilter_thebhyt)
        {
            List<KetQuaCheckThongTuyen_ExtendDTO> result = new List<KetQuaCheckThongTuyen_ExtendDTO>();
            try
            {
                client_1.BaseAddress = new Uri(Base.SessionLogin.UrlFullServer);
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(_lstFilter_thebhyt), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/CheckThongTuyen/GetCheckDSTheBHYT", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<List<KetQuaCheckThongTuyen_ExtendDTO>>().Result;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

    }
}
