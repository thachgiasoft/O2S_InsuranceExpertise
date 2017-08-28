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
        public HttpResponseMessage GetCheckListHosobenhan(HttpRequestMessage request, TieuChiCheckThongTuyenDTO filter)
        {
            try
            {
                List<KetQuaCheckThongTuyen_ExtendDTO> results = new List<KetQuaCheckThongTuyen_ExtendDTO>();
                //Lay thong tin                
                LayThongTinChoPortal laythongtin = new LayThongTinChoPortal();
                laythongtin.GetTaiKhoanvaTokenPortal();
                if (GlobalStore.tokenSession == null)
                {
                    KetQuaCheckThongTuyen_ExtendDTO _checkLoi = new KetQuaCheckThongTuyen_ExtendDTO();
                    _checkLoi.maLoi_CongGDBHYT = "500";
                    _checkLoi.tenLoi_CongGDBHYT = "Không thể kết nối đến Cổng giám định BHYT.";
                    results.Add(_checkLoi);
                }
                else
                {
                    CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                    results = checkthongtuyen.LayDSHosobenhanDaCheckThongTuyen(filter);
                }
                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API GetCheckListHosobenhan " + ex.ToString());
                return null;
            }
        }

        [Route("GetCheckDSTheBHYT")]
        [HttpPost]
        public HttpResponseMessage GetCheckDSTheBHYT(HttpRequestMessage request, List<TheBHYTCheckThongTuyen_ThuCongDTO> _lstFilter_thebhyt)
        {
            try
            {
                //Lay thong tin                
                LayThongTinChoPortal laythongtin = new LayThongTinChoPortal();
                laythongtin.GetTaiKhoanvaTokenPortal();

                List<KetQuaCheckThongTuyen_ExtendDTO> results = new List<KetQuaCheckThongTuyen_ExtendDTO>();
                CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                int stt_dem = 1;
                if (GlobalStore.tokenSession == null)
                {
                    KetQuaCheckThongTuyen_ExtendDTO _checkLoi = new KetQuaCheckThongTuyen_ExtendDTO();
                    _checkLoi.maLoi_CongGDBHYT = "500";
                    _checkLoi.tenLoi_CongGDBHYT = "Không thể kết nối đến Cổng giám định BHYT.";
                    results.Add(_checkLoi);
                }
                else
                {
                    foreach (var item in _lstFilter_thebhyt)
                    {
                        //Du lieu dau vao gui Check giam dinh
                        TheBHYTCheckThongTuyenDTO form_data = new TheBHYTCheckThongTuyenDTO();
                        form_data.maThe = item.maThe;
                        form_data.hoTen = item.hoTen;
                        form_data.ngaySinh = item.ngaySinh;
                        form_data.gioiTinh = item.gioiTinh;
                        form_data.ngayBD = item.ngayBD;
                        form_data.ngayKT = item.ngayKT;
                        form_data.maCSKCB = item.maCSKCB;
                        form_data.username = GlobalStore.UserName_GDBHYT;
                        form_data.password = GlobalStore.Password_GDBHYT;
                        form_data.token = GlobalStore.tokenSession.APIKey.access_token;
                        form_data.id_token = GlobalStore.tokenSession.APIKey.id_token;
                        KetQuaCheckThongTuyen_ExtendDTO ketquaCheck = new KetQuaCheckThongTuyen_ExtendDTO();


                        ketquaCheck = checkthongtuyen.CheckTungTheBHYT_CongBHYT(form_data);

                        //Lay du lieu de luu lai DB Log
                        ketquaCheck.stt = stt_dem;
                        ketquaCheck.bhytid = item.bhytid;
                        ketquaCheck.hosobenhanid = item.hosobenhanid;
                        ketquaCheck.vienphiid = item.vienphiid;
                        ketquaCheck.patientid = item.patientid;
                        ketquaCheck.patientname = item.hoTen;
                        ketquaCheck.birthday = item.ngaySinh;
                        ketquaCheck.birthday_year = item.birthday_year;
                        ketquaCheck.gioitinhcode = item.gioiTinh.ToString();
                        ketquaCheck.gioitinhname = item.gioitinhname;
                        ketquaCheck.bhytcode = item.maThe;
                        ketquaCheck.macskcbbd = item.maCSKCB;
                        ketquaCheck.bhytdate = item.bhytdate;
                        ketquaCheck.bhytfromdate = item.ngayBD;
                        ketquaCheck.bhytutildate = item.ngayKT;
                        ketquaCheck.bhyt_loaiid = item.bhyt_loaiid;
                        ketquaCheck.noisinhsong = item.noisinhsong;
                        ketquaCheck.du5nam6thangluongcoban = item.du5nam6thangluongcoban;
                        ketquaCheck.dtcbh_luyke6thang = item.dtcbh_luyke6thang;
                        ketquaCheck.departmentgroupid = item.departmentgroupid;
                        ketquaCheck.departmentid = item.departmentid;
                        ketquaCheck.hosobenhandate = item.hosobenhandate;
                        if (item.hosobenhandate_ravien != null && item.hosobenhandate_ravien.ToString() != "")
                        {
                            ketquaCheck.hosobenhandate_ravien = item.hosobenhandate_ravien;
                        }
                        else
                        {
                            ketquaCheck.hosobenhandate_ravien = "0001-01-01 00:00:00";
                        }
                        ketquaCheck.lastupdatedate_hsba = item.lastupdatedate_hsba;
                        ketquaCheck.lastupdatedate_bhyt = item.lastupdatedate_bhyt;
                        ketquaCheck.usercheck = item.usercheck;

                        results.Add(ketquaCheck);

                        //Luu lai ket qua Check
                        CheckThongTuyenProcess luuketqua = new CheckThongTuyenProcess();
                        luuketqua.LuuKetQuaCheckThongTuyen_DBGiamDinh(ketquaCheck);
                        //
                        stt_dem++;
                    }
                }
                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API GetCheckDSTheBHYT " + ex.ToString());
                return null;
            }
        }

        [Route("CheckThongTuyenDebug")]
        [HttpGet]
        public HttpResponseMessage CheckThongTuyenDebug(HttpRequestMessage request)
        {
            try
            {
                //Lay thong tin                
                LayThongTinChoPortal laythongtin = new LayThongTinChoPortal();
                laythongtin.GetTaiKhoanvaTokenPortal();

                KetQuaCheckThongTuyen_ExtendDTO results = new KetQuaCheckThongTuyen_ExtendDTO();
                CheckThongTuyenDebugProcess checkthongtuyen = new CheckThongTuyenDebugProcess();
                CheckThongTuyenProcess checkthongtuyen_token = new CheckThongTuyenProcess();

                //Goi len cong BHYT de check tung the
                TheBHYTCheckThongTuyenDTO form_data = new TheBHYTCheckThongTuyenDTO();
                form_data.maThe = "GD4310109119966";
                form_data.hoTen = "VŨ TRUNG";
                form_data.ngaySinh = "09/09/1961";
                form_data.gioiTinh = 1;
                form_data.ngayBD = "01/06/2017";
                form_data.ngayKT = "31/05/2018";
                form_data.maCSKCB = "31004";
                form_data.username = GlobalStore.UserName_GDBHYT;
                form_data.password = GlobalStore.Password_GDBHYT;
                form_data.token = GlobalStore.tokenSession.APIKey.access_token;
                form_data.id_token = GlobalStore.tokenSession.APIKey.id_token;

                results = checkthongtuyen.CheckTungTheBHYT_Debug(form_data);

                var response = request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API GetDSBN " + ex.ToString());
                return null;
            }
        }

    }
}
