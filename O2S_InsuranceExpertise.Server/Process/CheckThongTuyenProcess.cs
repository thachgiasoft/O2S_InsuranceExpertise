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
    public class CheckThongTuyenProcess
    {
        #region Khai bao
        Base.ConnectDatabase condb = new Base.ConnectDatabase();
        static HttpClient client = new HttpClient();
        private HttpClient client_1 = new HttpClient();



        #endregion

        #region Lay thong tin phuc vu check API cong BHYT
        internal void LayThongTinVeTaiKhoan_CongBHYT()
        {
            try
            {
                if (GlobalStore.UserName_GDBHYT == null)
                {
                    string sql_getThongTin = "select usergdbhyt,passgdbhyt,urlfullserver from ie_config where configtype=1;";
                    DataTable dataTaiKhoan = condb.GetDataTable_HSBA(sql_getThongTin);
                    if (dataTaiKhoan != null && dataTaiKhoan.Rows.Count > 0)
                    {
                        GlobalStore.UserName_GDBHYT = dataTaiKhoan.Rows[0]["usergdbhyt"].ToString();
                        GlobalStore.Password_GDBHYT = dataTaiKhoan.Rows[0]["passgdbhyt"].ToString();
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

        internal List<KetQuaCheckThongTuyen_ExtendDTO> LayDSHosobenhanDaCheckThongTuyen(TieuChiCheckThongTuyenDTO filter)
        {
            List<KetQuaCheckThongTuyen_ExtendDTO> results = new List<KetQuaCheckThongTuyen_ExtendDTO>();
            string sqldsthebhyt_chuacheck = "";
            try
            {
                //Lay danh sach nhung BN can check the BHYT
                string date_tungay = filter.tuNgay.ToString("yyyy-MM-dd HH:mm:ss");
                string date_denngay = filter.denNgay.ToString("yyyy-MM-dd HH:mm:ss");

                sqldsthebhyt_chuacheck = " select bh.bhytid, mrd.hosobenhanid, mrd.vienphiid, hsba.patientid, hsba.patientname, to_char(hsba.birthday, 'dd/MM/yyyy') as birthday, hsba.birthday_year, hsba.gioitinhcode, hsba.gioitinhname, bh.bhytcode, bh.macskcbbd, to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate, to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate, to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate, bh.bhyt_loaiid, bh.noisinhsong, bh.du5nam6thangluongcoban, bh.dtcbh_luyke6thang, mrd.departmentgroupid, mrd.departmentid, to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate, to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate_ravien, to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba, to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 and medicalrecordstatus<>99 and departmentgroupid=" + filter.departmentgroupid + " and thoigianvaovien between '" + filter.tuNgay + "' and '" + filter.denNgay + "') mrd inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' and bhytdate between '" + filter.tuNgay + "' and '" + filter.denNgay + "') bh on bh.bhytid=mrd.bhytid inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate between '" + filter.tuNgay + "' and '" + filter.denNgay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid where (coalesce(bh.bhytcheckstatus,0)=0 or coalesce(hsba.bhytcheckstatus,0)=0) group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,mrd.departmentid,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate order by hsba.patientname; ";

                DataTable dataTheChuaCheck = condb.GetDataTable_HIS(sqldsthebhyt_chuacheck);
                if (dataTheChuaCheck != null && dataTheChuaCheck.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTheChuaCheck.Rows.Count; i++)
                    {
                        //Goi len cong BHYT de check tung the
                        TheBHYTCheckThongTuyenDTO form_data = new TheBHYTCheckThongTuyenDTO();
                        form_data.maThe = dataTheChuaCheck.Rows[i]["bhytcode"].ToString();
                        form_data.hoTen = dataTheChuaCheck.Rows[i]["patientname"].ToString();
                        form_data.ngaySinh = dataTheChuaCheck.Rows[i]["birthday"].ToString();
                        if (dataTheChuaCheck.Rows[i]["gioitinhcode"].ToString() == "02")
                        {
                            form_data.gioiTinh = 2;
                        }
                        else
                        {
                            form_data.gioiTinh = 1;
                        }
                        form_data.ngayBD = dataTheChuaCheck.Rows[i]["bhytfromdate"].ToString();
                        form_data.ngayKT = dataTheChuaCheck.Rows[i]["bhytutildate"].ToString();
                        form_data.maCSKCB = dataTheChuaCheck.Rows[i]["macskcbbd"].ToString();
                        form_data.username = GlobalStore.UserName_GDBHYT;
                        form_data.password = GlobalStore.Password_GDBHYT;
                        form_data.token = GlobalStore.tokenSession.APIKey.access_token;
                        form_data.id_token = GlobalStore.tokenSession.APIKey.id_token;

                        KetQuaCheckThongTuyen_ExtendDTO lichsuKCB = new KetQuaCheckThongTuyen_ExtendDTO();
                        lichsuKCB = CheckTungTheBHYT_CongBHYT(form_data);

                        lichsuKCB.stt = i + 1;
                        lichsuKCB.bhytid = Common.TypeConvert.TypeConvertParse.ToInt64(dataTheChuaCheck.Rows[i]["bhytid"].ToString());
                        lichsuKCB.hosobenhanid = Common.TypeConvert.TypeConvertParse.ToInt64(dataTheChuaCheck.Rows[i]["hosobenhanid"].ToString());
                        lichsuKCB.vienphiid = Common.TypeConvert.TypeConvertParse.ToInt64(dataTheChuaCheck.Rows[i]["vienphiid"].ToString());
                        lichsuKCB.patientid = Common.TypeConvert.TypeConvertParse.ToInt64(dataTheChuaCheck.Rows[i]["patientid"].ToString());
                        lichsuKCB.patientname = dataTheChuaCheck.Rows[i]["patientname"].ToString();
                        lichsuKCB.birthday = dataTheChuaCheck.Rows[i]["birthday"].ToString();
                        lichsuKCB.birthday_year = dataTheChuaCheck.Rows[i]["birthday_year"].ToString();
                        lichsuKCB.gioitinhcode = dataTheChuaCheck.Rows[i]["gioitinhcode"].ToString();
                        lichsuKCB.gioitinhname = dataTheChuaCheck.Rows[i]["gioitinhname"].ToString();
                        lichsuKCB.bhytcode = dataTheChuaCheck.Rows[i]["bhytcode"].ToString();
                        lichsuKCB.macskcbbd = dataTheChuaCheck.Rows[i]["macskcbbd"].ToString();
                        lichsuKCB.bhytdate = dataTheChuaCheck.Rows[i]["bhytdate"].ToString();
                        lichsuKCB.bhytfromdate = dataTheChuaCheck.Rows[i]["bhytfromdate"].ToString();
                        lichsuKCB.bhytutildate = dataTheChuaCheck.Rows[i]["bhytutildate"].ToString();
                        lichsuKCB.bhyt_loaiid = Common.TypeConvert.TypeConvertParse.ToInt16(dataTheChuaCheck.Rows[i]["bhyt_loaiid"].ToString());
                        lichsuKCB.noisinhsong = dataTheChuaCheck.Rows[i]["noisinhsong"].ToString();
                        lichsuKCB.du5nam6thangluongcoban = Common.TypeConvert.TypeConvertParse.ToInt16(dataTheChuaCheck.Rows[i]["du5nam6thangluongcoban"].ToString());
                        lichsuKCB.dtcbh_luyke6thang = Common.TypeConvert.TypeConvertParse.ToInt16(dataTheChuaCheck.Rows[i]["dtcbh_luyke6thang"].ToString());
                        lichsuKCB.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt16(dataTheChuaCheck.Rows[i]["departmentgroupid"].ToString());
                        lichsuKCB.departmentid = Common.TypeConvert.TypeConvertParse.ToInt16(dataTheChuaCheck.Rows[i]["departmentid"].ToString());
                        lichsuKCB.hosobenhandate = dataTheChuaCheck.Rows[i]["hosobenhandate"].ToString();
                        lichsuKCB.hosobenhandate_ravien = dataTheChuaCheck.Rows[i]["hosobenhandate_ravien"].ToString();
                        lichsuKCB.lastupdatedate_hsba = dataTheChuaCheck.Rows[i]["lastupdatedate_hsba"].ToString();
                        lichsuKCB.lastupdatedate_bhyt = dataTheChuaCheck.Rows[i]["lastupdatedate_bhyt"].ToString();
                        results.Add(lichsuKCB);

                        //Lưu lại lịch sử Check thông tuyến lên DB Giám định
                        LuuKetQuaCheckThongTuyen_DBGiamDinh(lichsuKCB);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi lay danh sach the can check " + ex.ToString());
                Common.Logging.LogSystem.Info("Cau truy van lay danh sach the can check " + sqldsthebhyt_chuacheck);
            }
            return results;
        }

        internal KetQuaCheckThongTuyen_ExtendDTO CheckTungTheBHYT_CongBHYT(TheBHYTCheckThongTuyenDTO form_data)
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
                                lsKhamChuaBenh.bhytcheckstatus = 2;
                                break;
                            }
                        case "02":
                            {
                                lsKhamChuaBenh.tenKetQua = "KCB khi chưa đến hạn";
                                lsKhamChuaBenh.bhytcheckstatus = 3;
                                break;
                            }
                        case "03":
                            {
                                lsKhamChuaBenh.tenKetQua = "Hết hạn thẻ khi chưa ra viện";
                                lsKhamChuaBenh.bhytcheckstatus = 4;
                                break;
                            }
                        case "04":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ có giá trị khi đang nằm viện";
                                lsKhamChuaBenh.bhytcheckstatus = 5;
                                break;
                            }
                        case "05":
                            {
                                lsKhamChuaBenh.tenKetQua = "Mã thẻ không có trong dữ liệu thẻ";
                                lsKhamChuaBenh.bhytcheckstatus = 6;
                                break;
                            }
                        case "06":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai họ tên";
                                lsKhamChuaBenh.bhytcheckstatus = 7;
                                break;
                            }
                        case "07":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai ngày sinh";
                                lsKhamChuaBenh.bhytcheckstatus = 8;
                                break;
                            }
                        case "08":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai giới tính";
                                lsKhamChuaBenh.bhytcheckstatus = 9;
                                break;
                            }
                        case "09":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai nơi đăng ký KCB ban đầu";
                                lsKhamChuaBenh.bhytcheckstatus = 10;
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
        internal void LuuKetQuaCheckThongTuyen_DBGiamDinh(KetQuaCheckThongTuyen_ExtendDTO datalichsuKCB)
        {
            try
            {
                string birthday = DateTime.ParseExact(datalichsuKCB.birthday.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //string bhytdate = DateTime.ParseExact(datalichsuKCB.bhytdate.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string bhytfromdate = DateTime.ParseExact(datalichsuKCB.bhytfromdate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string bhytutildate = DateTime.ParseExact(datalichsuKCB.bhytutildate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //string hosobenhandate = DateTime.ParseExact(datalichsuKCB.hosobenhandate.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //string hosobenhandate_ravien = DateTime.ParseExact(datalichsuKCB.hosobenhandate_ravien.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //string lastupdatedate_hsba = DateTime.ParseExact(datalichsuKCB.lastupdatedate_hsba.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //string lastupdatedate_bhyt = DateTime.ParseExact(datalichsuKCB.lastupdatedate_bhyt.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string sql_insert = "INSERT INTO ie_bhyt_check(bhytid, hosobenhanid, vienphiid, patientid, patientname, birthday, birthday_year, gioitinhcode, gioitinhname, bhytcode, macskcbbd, bhytdate, bhytfromdate, bhytutildate, bhyt_loaiid, noisinhsong, du5nam6thangluongcoban, dtcbh_luyke6thang, bhytcheckstatus, bhytchecksdate, departmentgroupid, departmentid, hosobenhandate, hosobenhandate_ravien, lastupdatedate_hsba, lastupdatedate_bhyt, bhytchecknote) VALUES ('" + datalichsuKCB.bhytid + "', '" + datalichsuKCB.hosobenhanid + "', '" + datalichsuKCB.vienphiid + "', '" + datalichsuKCB.patientid + "', '" + datalichsuKCB.patientname + "', '" + birthday + "', '" + datalichsuKCB.birthday_year + "', '" + datalichsuKCB.gioitinhcode + "', '" + datalichsuKCB.gioitinhname + "', '" + datalichsuKCB.bhytcode + "', '" + datalichsuKCB.macskcbbd + "', '" + datalichsuKCB.bhytdate + "', '" + bhytfromdate + "', '" + bhytutildate + "', '" + datalichsuKCB.bhyt_loaiid + "', '" + datalichsuKCB.noisinhsong + "', '" + datalichsuKCB.du5nam6thangluongcoban + "', '" + datalichsuKCB.dtcbh_luyke6thang + "', '" + datalichsuKCB.bhytcheckstatus + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + datalichsuKCB.departmentgroupid + "', '" + datalichsuKCB.departmentid + "', '" + datalichsuKCB.hosobenhandate + "', '" + datalichsuKCB.hosobenhandate_ravien + "', '" + datalichsuKCB.lastupdatedate_hsba + "', '" + datalichsuKCB.lastupdatedate_bhyt + "', '" + datalichsuKCB.tenKetQua + "') ; ";

                string sql_updateBHYTstt = "UPDATE bhyt SET bhytcheckstatus='" + datalichsuKCB.bhytcheckstatus + "' where bhytid=" + datalichsuKCB.bhytid + "; ";
                string sql_updateHSBAstt = "UPDATE hosobenhan SET bhytcheckstatus='" + datalichsuKCB.bhytcheckstatus + "' where hosobenhanid=" + datalichsuKCB.hosobenhanid + ";";

                condb.ExecuteNonQuery_HSBA(sql_insert);
                condb.ExecuteNonQuery_HIS(sql_updateBHYTstt);
                condb.ExecuteNonQuery_HIS(sql_updateHSBAstt);

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi luu lai lich su check thong tuyen " + ex.ToString());
                Common.Logging.LogSystem.Error("datalichsuKCB.birthday.ToString()" + datalichsuKCB.birthday.ToString());
            }
        }


    }
}