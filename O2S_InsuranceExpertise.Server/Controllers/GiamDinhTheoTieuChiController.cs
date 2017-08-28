using O2S_InsuranceExpertise.Model.Models.GiamDinh;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using O2S_InsuranceExpertise.Server.Process;
using O2S_InsuranceExpertise.Server.Process.TieuChiProcess_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2S_InsuranceExpertise.Server.Controllers
{
    [RoutePrefix("api/GiamDinhTheoTieuChi")]
    public class GiamDinhTheoTieuChiController : ApiController
    {
        [Route("GiamDinhHoSoXML")]
        [HttpPost]
        public HttpResponseMessage GiamDinhHoSoXML(HttpRequestMessage request, XML_HOSODTO _XMLHoSo_KiemTra)
        {
            try
            {
                //Lay thong tin phuc vu giam dinh
                LayThongTinChoGDTheoTieuChi.LayTheFileXML1();
                LayThongTinChoGDTheoTieuChi.LayDanhSachDVKTPheDuyet();
                LayThongTinChoGDTheoTieuChi.LayDanhSachThuocPheDuyet();
                LayThongTinChoGDTheoTieuChi.LayDanhSachVatTuPheDuyet();
                LayThongTinChoGDTheoTieuChi.LayDanhSachGiuongPheDuyet();
                LayThongTinChoGDTheoTieuChi.GopDanhMucDVKTVaGiuong();

                TieuChiProcess _process = new TieuChiProcess();
                GiamDinhLoiDTO _loiHoSO = _process.TieuChiProcess_HSBA(_XMLHoSo_KiemTra);

                var response = request.CreateResponse(HttpStatusCode.OK, _loiHoSO);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API GiamDinhTheoTieuChi/GiamDinhHoSoXML " + ex.ToString());
                return null;
            }
        }
    }
}
