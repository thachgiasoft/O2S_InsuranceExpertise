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

        #endregion

        [Route("GetCheckListHosobenhan")]
        [HttpPost]
        public HttpResponseMessage GetCheckListHosobenhan(HttpRequestMessage request, TieuChiCheckDTO filter)
        {
            try
            {
                List<LichSuKhamChuaBenhDTO> results = new List<LichSuKhamChuaBenhDTO>();
                CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                //Lay thong tin
                checkthongtuyen.LayThongTinVeTaiKhoan_CongBHYT();
                checkthongtuyen.LayToken_CongBHYT();
                results = checkthongtuyen.LayDSHosobenhanDaCheckThongTuyen(filter);
                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [Route("GetDSBN")]
        [HttpGet]
        public HttpResponseMessage GetDSBN(HttpRequestMessage request)
        {
            try
            {
                TieuChiCheckDTO filter = new TieuChiCheckDTO();
                filter.tuNgay = DateTime.Now;
                filter.denNgay = DateTime.Now;
                filter.departmentgroupid = 3;

                List<LichSuKhamChuaBenhDTO> results = new List<LichSuKhamChuaBenhDTO>();
                //todo
                CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                //Lay thong tin
                checkthongtuyen.LayThongTinVeTaiKhoan_CongBHYT();
                checkthongtuyen.LayToken_CongBHYT();
                results = checkthongtuyen.LayDSHosobenhanDaCheckThongTuyen(filter);

                //LichSuKhamChuaBenhDTO lichsu = new LichSuKhamChuaBenhDTO();
                //lichsu.maKetQua = "00";
                //lichsu.tenKetQua = "Chinh xac";
                //IEBhytCheckDTO _thongTinHoSo = new IEBhytCheckDTO();
                //List<LichSuKCBDTO> _dsLichSuKCB = new List<LichSuKCBDTO>();

                ////lichsu.thongTinHoSo = _thongTinHoSo;
                //lichsu.dsLichSuKCB = _dsLichSuKCB;
                //results.Add(lichsu);

                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
