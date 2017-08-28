using DevExpress.XtraSplashScreen;
using Newtonsoft.Json;
using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Model.Models.GiamDinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML
{
    public partial class ucKiemTraGiamDinh_ChiTiet : UserControl
    {
        private HttpClient client_1 = new HttpClient();

        private void GoiKiemTraGiamDinh_Server()
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                GiamDinhLoiDTO _loiHoSO = new GiamDinhLoiDTO();
                client_1.BaseAddress = new Uri(Base.SessionLogin.UrlFullServer);
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(this.XMLHoSo_KiemTra), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/GiamDinhTheoTieuChi/GiamDinhHoSoXML", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    _loiHoSO = response.Content.ReadAsAsync<GiamDinhLoiDTO>().Result;
                    List<GiamDinhLoi_XML1DTO> _lstGiamDinhLoiXML1 = new List<GiamDinhLoi_XML1DTO>();
                    List<GiamDinhLoi_DVKTDTO> _lstGiamDinhLoiDVKT = new List<GiamDinhLoi_DVKTDTO>();

                    _lstGiamDinhLoiXML1 = _loiHoSO.lstGiamDinhLoiXML1;
                    _lstGiamDinhLoiDVKT = _loiHoSO.lstGiamDinhLoiDVKT;
                    gridControlDSLoi_TongHop.DataSource = _lstGiamDinhLoiXML1;

                    //Dat lai STT va hien thi len man hinh
                    //for (int )

                    gridControlDSLoi_DVKT.DataSource = _lstGiamDinhLoiDVKT;
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("Lỗi(" + (int)response.StatusCode + ")!");
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("Có lỗi xảy ra khi kết nối đến server!");
                frmthongbao.Show();
            }
            SplashScreenManager.CloseForm();
        }


    }
}
