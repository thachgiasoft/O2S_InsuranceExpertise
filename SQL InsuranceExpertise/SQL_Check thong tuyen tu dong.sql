---Check thông tuyến ngày 12/8

--Lấy danh sách viện phí của khoa chưa check ok
http://gdbhyt.baohiemxahoi.gov.vn/

31153_BV
viettiep31153


select bh.bhytid, 
		mrd.hosobenhanid, 
		mrd.vienphiid, 
		hsba.patientid,
		hsba.patientname,
		to_char(hsba.birthday, 'dd/MM/yyyy') as birthday,
		hsba.birthday_year,
		hsba.gioitinhcode,
		hsba.gioitinhname,
		bh.bhytcode,
		bh.macskcbbd,
		to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate,
		to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate,
		to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate,
		bh.bhyt_loaiid,
		bh.noisinhsong,
		bh.du5nam6thangluongcoban,
		bh.dtcbh_luyke6thang,
		mrd.departmentgroupid,
		mrd.departmentid,
		to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate,
		to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate_ravien,
		to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba,
		to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt
from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 and medicalrecordstatus<>99 and departmentgroupid=" + filter.departmentgroupid + " and thoigianvaovien between '" + filter.tuNgay + "' and '" + filter.denNgay + "') mrd
	inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' and bhytdate between '" + filter.tuNgay + "' and '" + filter.denNgay + "') bh on bh.bhytid=mrd.bhytid
	inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate between '" + filter.tuNgay + "' and '" + filter.denNgay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid
where (coalesce(bh.bhytcheckstatus,0)=0 or coalesce(hsba.bhytcheckstatus,0)=0)
group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,mrd.departmentid,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate
order by hsba.patientname;
















--So sanh voi bang Luu tru ben GIam Dinh
select bh.bhytid, 
		mrd.hosobenhanid, 
		mrd.vienphiid, 
		hsba.patientid,
		hsba.patientname,
		to_char(hsba.birthday, 'dd/MM/yyyy') as birthday,
		hsba.birthday_year,
		hsba.gioitinhcode,
		hsba.gioitinhname,
		bh.bhytcode,
		bh.macskcbbd,
		to_char(bh.bhytdate, 'yyyy-MM-dd HH:mm:ss') as bhytdate,
		to_char(bh.bhytfromdate, 'dd/MM/yyyy') as bhytfromdate,
		to_char(bh.bhytutildate, 'dd/MM/yyyy') as bhytutildate,
		bh.bhyt_loaiid,
		bh.noisinhsong,
		bh.du5nam6thangluongcoban,
		bh.dtcbh_luyke6thang,
		mrd.departmentgroupid,
		mrd.departmentid,
		to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate,
		to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate_ravien,
		to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba,
		to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt
from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 /*and medicalrecordstatus<>99*/ and departmentgroupid=3 and thoigianvaovien between '" + filter.tuNgay + "' and '" + filter.denNgay + "') mrd
	inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate from bhyt where bhytcode<>'' and bhytdate between '" + filter.tuNgay + "' and '" + filter.denNgay + "' and bhytid not in (select IE_bhyt.bhytid
from dblink('myconn_ie','SELECT bhytid FROM IE_bhyt_check where bhytcheckstatus=1 and hosobenhandate between ''" + filter.tuNgay + "'' and ''" + filter.denNgay + "''') AS IE_bhyt(bhytid integer)) ) bh on bh.bhytid=mrd.bhytid
	inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate from hosobenhan where /*hosobenhanstatus=0 and */hosobenhandate between '" + filter.tuNgay + "' and '" + filter.denNgay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid
group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,mrd.departmentid,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate
order by hsba.patientname;








