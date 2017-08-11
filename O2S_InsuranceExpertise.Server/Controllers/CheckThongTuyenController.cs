using O2S_InsuranceExpertise.Server.Models;
using O2S_InsuranceExpertise.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2S_InsuranceExpertise.Server.APICore;
using O2S_InsuranceExpertise.Server.Process;
using O2S_InsuranceExpertise.Model.Models;

namespace O2S_InsuranceExpertise.Server.Controllers
{
    [RoutePrefix("api/CheckThongTuyen")]
    public class CheckThongTuyenController : ApiController
    {
        #region Initialize
        //private ICheckThongTuyen _checkThongTuyenService;

        #endregion

        [Route("GetCheckListHosobenhan")]
        [HttpPost]
        public HttpResponseMessage GetCheckListHosobenhan(HttpRequestMessage request, TieuChiCheckDTO filter)
        {
            try
            {
                List<LichSuKhamChuaBenhDTO> results = new List<LichSuKhamChuaBenhDTO>();
                //todo
                CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                    
                results = checkthongtuyen.LayDSHosobenhanDaCheckThongTuyen(filter);
                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
            //return CreateHttpResponse(request, () =>
            //{
            //    var model = _productService.GetById(id);

            //    var responseData = Mapper.Map<Product, ProductViewModel>(model);

            //    var response = request.CreateResponse(HttpStatusCode.OK, responseData);

            //    return response;k
            //});
        }




    }
}
