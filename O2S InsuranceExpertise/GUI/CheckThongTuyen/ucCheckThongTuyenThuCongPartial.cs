using AutoMapper;
using DevExpress.XtraSplashScreen;
using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    public partial class ucCheckThongTuyenThuCong : UserControl
    {
        #region Tim kiem
        private void LayDSBenhNhanDangDieuTri_TheoKhoa(string _lstKhoaChonLayBC)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string getdsbenhnhan = "select row_number () over (order by degp.departmentgroupname,hsba.patientname) as stt, bh.bhytid, mrd.hosobenhanid, mrd.vienphiid, hsba.patientid, hsba.patientname, to_char(hsba.birthday, 'dd/MM/yyyy') as birthday, hsba.birthday_year, hsba.gioitinhcode, hsba.gioitinhname, bh.bhytcode, bh.macskcbbd, to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate, to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate, to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate, bh.bhyt_loaiid, bh.noisinhsong, bh.du5nam6thangluongcoban, bh.dtcbh_luyke6thang, to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt, mrd.departmentgroupid, degp.departmentgroupname, mrd.departmentid, de.departmentname, to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate, (case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') end) as hosobenhandate_ravien, to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba, (case when bh.bhytcheckstatus=1 and hsba.bhytcheckstatus=1 then 'Thẻ chính xác' end) as tenketqua from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 and departmentgroupid in (" + _lstKhoaChonLayBC + ") and thoigianvaovien between '" + tungay + "' and '" + denngay + "') mrd inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' and bhytdate between '" + tungay + "' and '" + denngay + "') bh on bh.bhytid=mrd.bhytid inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhanstatus=0 and hosobenhandate between '" + tungay + "' and '" + denngay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=mrd.departmentid group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,degp.departmentgroupname,mrd.departmentid,de.departmentname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate,bh.bhytcheckstatus,hsba.bhytcheckstatus; ";

                DataTable dataDSBenhNhan = condb.GetDataTable_HIS(getdsbenhnhan);
                if (dataDSBenhNhan != null && dataDSBenhNhan.Rows.Count > 0)
                {
                    gridControlDSBN.DataSource = dataDSBenhNhan;
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private void LayDanhSachBenhNhan_TheoDieuKien(Model.Models.FilterDSBNThuCongDTO _dieukientimkiem)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string getdsbenhnhan = "select row_number () over (order by degp.departmentgroupname,hsba.patientname) as stt, bh.bhytid, mrd.hosobenhanid, mrd.vienphiid, hsba.patientid, hsba.patientname, to_char(hsba.birthday, 'dd/MM/yyyy') as birthday, hsba.birthday_year, hsba.gioitinhcode, hsba.gioitinhname, bh.bhytcode, bh.macskcbbd, to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate, to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate, to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate, bh.bhyt_loaiid, bh.noisinhsong, bh.du5nam6thangluongcoban, bh.dtcbh_luyke6thang, to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt, mrd.departmentgroupid, degp.departmentgroupname, mrd.departmentid, de.departmentname, to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate, (case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') end) as hosobenhandate_ravien, to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba, (case when bh.bhytcheckstatus=1 and hsba.bhytcheckstatus=1 then 'Thẻ chính xác' end) as tenketqua from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 " + _dieukientimkiem.patientid + _dieukientimkiem.vienphiid + " and medicalrecordid_next=0) mrd inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' " + _dieukientimkiem.patientid + _dieukientimkiem.bhytcode + ") bh on bh.bhytid=mrd.bhytid inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate>'2014-01-01 00:00:00' " + _dieukientimkiem.patientid + ") hsba on hsba.hosobenhanid=mrd.hosobenhanid left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=mrd.departmentid group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,degp.departmentgroupname,mrd.departmentid,de.departmentname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate,bh.bhytcheckstatus,hsba.bhytcheckstatus; ";

                DataTable dataDSBenhNhan = condb.GetDataTable_HIS(getdsbenhnhan);
                if (dataDSBenhNhan != null && dataDSBenhNhan.Rows.Count > 0)
                {
                    gridControlDSBN.DataSource = dataDSBenhNhan;
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private void LayDSBenhNhanDaRaVien_TheoKhoa(string _lstKhoaChonLayBC, string _trangthai)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string getdsbenhnhan = "select row_number () over (order by degp.departmentgroupname,hsba.patientname) as stt, bh.bhytid, mrd.hosobenhanid, mrd.vienphiid, hsba.patientid, hsba.patientname, to_char(hsba.birthday, 'dd/MM/yyyy') as birthday, hsba.birthday_year, hsba.gioitinhcode, hsba.gioitinhname, bh.bhytcode, bh.macskcbbd, to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate, to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate, to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate, bh.bhyt_loaiid, bh.noisinhsong, bh.du5nam6thangluongcoban, bh.dtcbh_luyke6thang, to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt, mrd.departmentgroupid, degp.departmentgroupname, mrd.departmentid, de.departmentname, to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate, (case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') end) as hosobenhandate_ravien, to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba, (case when bh.bhytcheckstatus=1 and hsba.bhytcheckstatus=1 then 'Thẻ chính xác' end) as tenketqua from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from vienphi where " + _trangthai + " and doituongbenhnhanid=1 and departmentgroupid in (" + _lstKhoaChonLayBC + ") and vienphidate_ravien between '" + tungay + "' and '" + denngay + "') mrd inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' and bhytdate between '" + tungay + "' and '" + denngay + "') bh on bh.bhytid=mrd.bhytid inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate between '" + tungay + "' and '" + denngay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=mrd.departmentid group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,degp.departmentgroupname,mrd.departmentid,de.departmentname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate,bh.bhytcheckstatus,hsba.bhytcheckstatus; ";

                DataTable dataDSBenhNhan = condb.GetDataTable_HIS(getdsbenhnhan);
                if (dataDSBenhNhan != null && dataDSBenhNhan.Rows.Count > 0)
                {
                    gridControlDSBN.DataSource = dataDSBenhNhan;
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }
        #endregion

        #region Check thong tuyen
        private void CheckThongTuyenRowDangChon()
        {
            try
            {
                if (gridViewDSBN.RowCount > 0)
                {
                    List<KetQuaCheckThongTuyen_ExtendDTO> lstKetQuaCheckThongTuyen = new List<KetQuaCheckThongTuyen_ExtendDTO>();
                    List<TheBHYTCheckThongTuyen_ThuCongDTO> lstFilter_thebhyt = new List<TheBHYTCheckThongTuyen_ThuCongDTO>();

                    foreach (var item_index in gridViewDSBN.GetSelectedRows())
                    {
                        TheBHYTCheckThongTuyen_ThuCongDTO filter_thebhyt = new TheBHYTCheckThongTuyen_ThuCongDTO();
                        //Du lieu dau vao tren Cong BHYT
                        filter_thebhyt.maThe = gridViewDSBN.GetRowCellValue(item_index, "bhytcode").ToString();
                        filter_thebhyt.hoTen = gridViewDSBN.GetRowCellValue(item_index, "patientname").ToString();
                        filter_thebhyt.ngaySinh = gridViewDSBN.GetRowCellValue(item_index, "birthday").ToString();
                        if (gridViewDSBN.GetRowCellValue(item_index, "gioitinhcode").ToString() == "02")
                        {
                            filter_thebhyt.gioiTinh = 2;
                        }
                        else
                        {
                            filter_thebhyt.gioiTinh = 1;
                        }
                        filter_thebhyt.maCSKCB = gridViewDSBN.GetRowCellValue(item_index, "macskcbbd").ToString();
                        filter_thebhyt.ngayBD = gridViewDSBN.GetRowCellValue(item_index, "bhytfromdate").ToString();
                        filter_thebhyt.ngayKT = gridViewDSBN.GetRowCellValue(item_index, "bhytutildate").ToString();
                        //Du lieu bo sung de luu lai log check
                        filter_thebhyt.bhytid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "bhytid").ToString());
                        filter_thebhyt.hosobenhanid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "hosobenhanid").ToString());
                        filter_thebhyt.vienphiid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "vienphiid").ToString());
                        filter_thebhyt.patientid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "patientid").ToString());
                        filter_thebhyt.birthday_year = gridViewDSBN.GetRowCellValue(item_index, "birthday_year").ToString();
                        filter_thebhyt.gioitinhname = gridViewDSBN.GetRowCellValue(item_index, "gioitinhname").ToString();
                        filter_thebhyt.bhytdate = gridViewDSBN.GetRowCellValue(item_index, "bhytdate").ToString();
                        filter_thebhyt.bhyt_loaiid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "bhyt_loaiid").ToString());
                        filter_thebhyt.noisinhsong = gridViewDSBN.GetRowCellValue(item_index, "noisinhsong").ToString();
                        filter_thebhyt.du5nam6thangluongcoban = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "du5nam6thangluongcoban").ToString());
                        filter_thebhyt.dtcbh_luyke6thang = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "dtcbh_luyke6thang").ToString());
                        filter_thebhyt.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "departmentgroupid").ToString());
                        filter_thebhyt.departmentid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(item_index, "departmentid").ToString());
                        filter_thebhyt.hosobenhandate = gridViewDSBN.GetRowCellValue(item_index, "hosobenhandate").ToString();
                        filter_thebhyt.hosobenhandate_ravien = gridViewDSBN.GetRowCellValue(item_index, "hosobenhandate_ravien").ToString();
                        filter_thebhyt.lastupdatedate_hsba = gridViewDSBN.GetRowCellValue(item_index, "lastupdatedate_hsba").ToString();
                        filter_thebhyt.lastupdatedate_bhyt = gridViewDSBN.GetRowCellValue(item_index, "lastupdatedate_bhyt").ToString();
                        lstFilter_thebhyt.Add(filter_thebhyt);
                    }

                    GoiServerYeuCauCheckThongTuyenProcess yeucaucheck = new GoiServerYeuCauCheckThongTuyenProcess();
                    lstKetQuaCheckThongTuyen = yeucaucheck.YeuCauCheckThongTuyen_List(lstFilter_thebhyt);

                    gridControlDSDotDieuTri.DataSource = lstKetQuaCheckThongTuyen;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void CheckThongTuyenTatCaRowDangChon()
        {
            try
            {
                if (gridViewDSBN.RowCount > 0)
                {
                    List<KetQuaCheckThongTuyen_ExtendDTO> lstKetQuaCheckThongTuyen = new List<KetQuaCheckThongTuyen_ExtendDTO>();
                    List<TheBHYTCheckThongTuyen_ThuCongDTO> lstFilter_thebhyt = new List<TheBHYTCheckThongTuyen_ThuCongDTO>();

                    for (int i = 0; i < gridViewDSBN.RowCount; i++)
                    {
                        Model.Models.TheBHYTCheckThongTuyen_ThuCongDTO filter_thebhyt = new Model.Models.TheBHYTCheckThongTuyen_ThuCongDTO();
                        //Du lieu dau vao tren Cong BHYT
                        filter_thebhyt.maThe = gridViewDSBN.GetRowCellValue(i, "bhytcode").ToString();
                        filter_thebhyt.hoTen = gridViewDSBN.GetRowCellValue(i, "patientname").ToString();
                        filter_thebhyt.ngaySinh = gridViewDSBN.GetRowCellValue(i, "birthday").ToString();
                        if (gridViewDSBN.GetRowCellValue(i, "gioitinhcode").ToString() == "02")
                        {
                            filter_thebhyt.gioiTinh = 2;
                        }
                        else
                        {
                            filter_thebhyt.gioiTinh = 1;
                        }
                        filter_thebhyt.maCSKCB = gridViewDSBN.GetRowCellValue(i, "macskcbbd").ToString();
                        filter_thebhyt.ngayBD = gridViewDSBN.GetRowCellValue(i, "bhytfromdate").ToString();
                        filter_thebhyt.ngayKT = gridViewDSBN.GetRowCellValue(i, "bhytutildate").ToString();
                        //Du lieu bo sung de luu lau log check
                        filter_thebhyt.bhytid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "bhytid").ToString());
                        filter_thebhyt.hosobenhanid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "hosobenhanid").ToString());
                        filter_thebhyt.vienphiid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "vienphiid").ToString());
                        filter_thebhyt.patientid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "patientid").ToString());
                        filter_thebhyt.birthday_year = gridViewDSBN.GetRowCellValue(i, "birthday_year").ToString();
                        filter_thebhyt.gioitinhname = gridViewDSBN.GetRowCellValue(i, "gioitinhname").ToString();
                        filter_thebhyt.bhytdate = gridViewDSBN.GetRowCellValue(i, "bhytdate").ToString();
                        filter_thebhyt.bhyt_loaiid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "bhyt_loaiid").ToString());
                        filter_thebhyt.noisinhsong = gridViewDSBN.GetRowCellValue(i, "noisinhsong").ToString();
                        filter_thebhyt.du5nam6thangluongcoban = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "du5nam6thangluongcoban").ToString());
                        filter_thebhyt.dtcbh_luyke6thang = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "dtcbh_luyke6thang").ToString());
                        filter_thebhyt.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "departmentgroupid").ToString());
                        filter_thebhyt.departmentid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBN.GetRowCellValue(i, "departmentid").ToString());
                        filter_thebhyt.hosobenhandate = gridViewDSBN.GetRowCellValue(i, "hosobenhandate").ToString();
                        filter_thebhyt.hosobenhandate_ravien = gridViewDSBN.GetRowCellValue(i, "hosobenhandate_ravien").ToString();
                        filter_thebhyt.lastupdatedate_hsba = gridViewDSBN.GetRowCellValue(i, "lastupdatedate_hsba").ToString();
                        filter_thebhyt.lastupdatedate_bhyt = gridViewDSBN.GetRowCellValue(i, "lastupdatedate_bhyt").ToString();

                        lstFilter_thebhyt.Add(filter_thebhyt);
                    }
                    GoiServerYeuCauCheckThongTuyenProcess yeucaucheck = new GoiServerYeuCauCheckThongTuyenProcess();
                    lstKetQuaCheckThongTuyen = yeucaucheck.YeuCauCheckThongTuyen_List(lstFilter_thebhyt);
                    gridControlDSDotDieuTri.DataSource = lstKetQuaCheckThongTuyen;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        private void Custom_GridDisplayLichSuKCB(bool _hienthi)
        {
            try
            {
                gridColumn_bhytcode.Visible = !_hienthi;
                gridColumn_tenKetQua.Visible = !_hienthi;
                gridColumn_mahoso.Visible = _hienthi;
                gridColumn_macskcb.Visible = _hienthi;
                gridColumn_tencskcb.Visible = _hienthi;
                gridColumn_ngayvaovien.Visible = _hienthi;
                gridColumn_ngayravien.Visible = _hienthi;
                gridColumn_tenbenh.Visible = _hienthi;
                gridColumn_tinhtrangten.Visible = _hienthi;
                gridColumn_kqdieutri_ten.Visible = _hienthi;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
