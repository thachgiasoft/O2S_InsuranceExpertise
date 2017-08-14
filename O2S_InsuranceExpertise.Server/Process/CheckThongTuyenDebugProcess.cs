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
    public class CheckThongTuyenDebugProcess
    {
        #region Khai bao
        Base.ConnectDatabase condb = new Base.ConnectDatabase();
        static HttpClient client = new HttpClient();
        private HttpClient client_1 = new HttpClient();



        #endregion

        internal KetQuaCheckThongTuyen_ExtendDTO CheckTungTheBHYT_Debug(TheBHYTCheckThongTuyenDTO form_data)
        {
            KetQuaCheckThongTuyen_ExtendDTO result = new KetQuaCheckThongTuyen_ExtendDTO();
            try
            {
                client_1 = new HttpClient();
                client_1.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP POST
                string param_data = string.Format("token={0}&id_token={1}&username={2}&password={3}", GlobalStore.tokenSession.APIKey.access_token, GlobalStore.tokenSession.APIKey.id_token, GlobalStore.UserName_GDBHYT, GlobalStore.Password_GDBHYT_MD5);

                var content = new StringContent(JsonConvert.SerializeObject(form_data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/egw/nhanLichSuKCB?" + param_data, content).Result;

                KetQuaCheckThongTuyen_ExtendDTO lsKhamChuaBenh = new KetQuaCheckThongTuyen_ExtendDTO();
                if (response.IsSuccessStatusCode)
                {
                    KetQuaCheckThongTuyenDTO ketQuaCheck = response.Content.ReadAsAsync<KetQuaCheckThongTuyenDTO>().Result;
                    lsKhamChuaBenh.maKetQua = ketQuaCheck.maKetQua;
                    lsKhamChuaBenh.dsLichSuKCB = ketQuaCheck.dsLichSuKCB;
                    //
                    switch (lsKhamChuaBenh.maKetQua)
                    {
                        case "00":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thông tin thẻ chính xác";
                                lsKhamChuaBenh.bhytcheckstatus = 1;
                                break;
                            }
                        case "01":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ hết giá trị sử dụng";
                                break;
                            }
                        case "02":
                            {
                                lsKhamChuaBenh.tenKetQua = "KCB khi chưa đến hạn";
                                break;
                            }
                        case "03":
                            {
                                lsKhamChuaBenh.tenKetQua = "Hết hạn thẻ khi chưa ra viện";
                                break;
                            }
                        case "04":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ có giá trị khi đang nằm viện";
                                break;
                            }
                        case "05":
                            {
                                lsKhamChuaBenh.tenKetQua = "Mã thẻ không có trong dữ liệu thẻ";
                                break;
                            }
                        case "06":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai họ tên";
                                break;
                            }
                        case "07":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai ngày sinh";
                                break;
                            }
                        case "08":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai giới tính";
                                break;
                            }
                        case "09":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai nơi đăng ký KCB ban đầu";
                                break;
                            }
                        default:
                            break;
                    }
                    if (lsKhamChuaBenh.dsLichSuKCB != null && lsKhamChuaBenh.dsLichSuKCB.Count > 0)
                    {
                        for (int i = 0; i < lsKhamChuaBenh.dsLichSuKCB.Count; i++)
                        {
                            lsKhamChuaBenh.dsLichSuKCB[i].stt_lichsu = i + 1;
                            //Tình trạng ra viện
                            switch (lsKhamChuaBenh.dsLichSuKCB[i].tinhTrang)
                            {
                                case "1":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].tinhTrang_Ten = "Ra viện";
                                        break;
                                    }
                                case "2":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].tinhTrang_Ten = "Chuyển viện";
                                        break;
                                    }
                                case "3":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].tinhTrang_Ten = "Trốn viện";
                                        break;
                                    }
                                case "4":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].tinhTrang_Ten = "Xin ra viện";
                                        break;
                                    }
                                default:
                                    break;
                            }
                            //Kết quả điều trị
                            switch (lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri)
                            {
                                case "1":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri_Ten = "Khỏi";
                                        break;
                                    }
                                case "2":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri_Ten = "Đỡ";
                                        break;
                                    }
                                case "3":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri_Ten = "Không thay đổi";
                                        break;
                                    }
                                case "4":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri_Ten = "Nặng hơn";
                                        break;
                                    }
                                case "5":
                                    {
                                        lsKhamChuaBenh.dsLichSuKCB[i].kqDieuTri_Ten = "Tử vong";
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.
                    lsKhamChuaBenh.maLoi_CongGDBHYT = response.StatusCode.ToString();
                }
                result = lsKhamChuaBenh;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API len cong check the " + ex.ToString());
                Common.Logging.LogSystem.Info("DTO gui len cong de check the " + form_data);
                result.maLoi_CongGDBHYT = "500";
            }
            return result;
        }

        //Lưu lại lịch sử Check thông tuyến lên DB Giám định


    }
}