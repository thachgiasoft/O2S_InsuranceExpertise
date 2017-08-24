using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Server.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2S_InsuranceExpertise.Server.Controllers
{
    [RoutePrefix("api/GiamDinhHoSoPorttal")]
    public class GiamDinhHoSoPorttalController : ApiController
    {
        [Route("GuiHoSoGiamDinh")]
        [HttpPost]
        public HttpResponseMessage GuiHoSoGiamDinh(HttpRequestMessage request, byte[] buffer)
        {
            try
            {
                //FileInfo f = new FileInfo("C:\\Users\\HongNhat\\Desktop\\XML324 15.8\\6204_BN000690292_NGUYEN_VAN_BINH_947437.xml");
                //byte[] buffer = null;
                //using (FileStream fs = f.OpenRead())
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        fs.CopyTo(memoryStream);
                //        buffer = memoryStream.ToArray();
                //    }
                //}
                    //Lay thong tin                
                    LayThongTinChoPortal laythongtin = new LayThongTinChoPortal();
                laythongtin.GetTaiKhoanvaTokenPortal();
                GiamDinhHoSoPorttalProcess giamdinhHS = new GiamDinhHoSoPorttalProcess();
                // guiHoSoGiamDinh để lấy Mã giao dịch
                KQGuiHoSoGiamDinhPortalDTO _kqGuiHSGD = giamdinhHS.GuiHoSoGiamDinh(buffer);
                NhanChiTietLoiHoSoPortalDTO _chiTietLoi = new NhanChiTietLoiHoSoPortalDTO();
                _chiTietLoi = giamdinhHS.NhanChiTietLoiHS(_kqGuiHSGD.maGiaoDich);

                var response = request.CreateResponse(HttpStatusCode.OK, _chiTietLoi);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API GuiHoSoGiamDinh " + ex.ToString());
                return null;
            }
        }
    }
}
