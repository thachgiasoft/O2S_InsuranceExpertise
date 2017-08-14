---Lay danh sach BN check BHYT ngay 13/8

--Check theo Khoa ngay 14/8
select row_number () over (order by degp.departmentgroupname,hsba.patientname) as stt,
		bh.bhytid, 
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
		to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt, 
		mrd.departmentgroupid,
		degp.departmentgroupname,
		mrd.departmentid,
		de.departmentname,
		to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate,
		(case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') end) as hosobenhandate_ravien,
		to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba,
		(case when bh.bhytcheckstatus=1 and hsba.bhytcheckstatus=1 then 'Thẻ chính xác' end) as tenketqua
		
from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 and departmentgroupid in (" + _lstKhoaChonLayBC + ") and thoigianvaovien between '" + tungay + "' and '" + denngay + "') mrd 
	inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' and bhytdate between '" + tungay + "' and '" + denngay + "') bh on bh.bhytid=mrd.bhytid 
	inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate between '" + tungay + "' and '" + denngay + "') hsba on hsba.hosobenhanid=mrd.hosobenhanid 
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid 
	left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=mrd.departmentid 
group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,degp.departmentgroupname,mrd.departmentid,de.departmentname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate,bh.bhytcheckstatus,hsba.bhytcheckstatus;



----Check theo ma the bhyt, ma BN, ma VP ngay 13/8

select row_number () over (order by degp.departmentgroupname,hsba.patientname) as stt,
		bh.bhytid, 
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
		to_char(bh.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_bhyt, 
		mrd.departmentgroupid,
		degp.departmentgroupname,
		mrd.departmentid,
		de.departmentname,
		to_char(hsba.hosobenhandate, 'yyyy-MM-dd HH:mm:ss') as hosobenhandate,
		(case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then to_char(hsba.hosobenhandate_ravien, 'yyyy-MM-dd HH:mm:ss') end) as hosobenhandate_ravien,
		to_char(hsba.lastaccessdate, 'yyyy-MM-dd HH:mm:ss') as lastupdatedate_hsba,
		(case when bh.bhytcheckstatus=1 and hsba.bhytcheckstatus=1 then 'Thẻ chính xác' end) as tenketqua
		
from (select hosobenhanid,vienphiid,departmentgroupid,departmentid,bhytid from medicalrecord where doituongbenhnhanid=1 "+_dieukientimkiem.patientid+ _dieukientimkiem.vienphiid+" and medicalrecordid_next=0) mrd
	inner join (select bhytid,bhytcode,macskcbbd,bhytdate,bhytfromdate,bhytutildate,bhyt_loaiid,noisinhsong,du5nam6thangluongcoban,dtcbh_luyke6thang,lastaccessdate,bhytcheckstatus from bhyt where bhytcode<>'' "+_dieukientimkiem.patientid + _dieukientimkiem.bhytcode+") bh on bh.bhytid=mrd.bhytid
	inner join (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,birthday,birthday_year,gioitinhcode,gioitinhname,lastaccessdate,bhytcheckstatus from hosobenhan where hosobenhandate>'2014-01-01 00:00:00' "+_dieukientimkiem.patientid+") hsba on hsba.hosobenhanid=mrd.hosobenhanid
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid
	left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=mrd.departmentid
group by bh.bhytid,mrd.hosobenhanid,mrd.vienphiid,hsba.patientid,hsba.patientname,hsba.birthday,hsba.birthday_year,hsba.gioitinhcode,hsba.gioitinhname,bh.bhytcode,bh.macskcbbd,bh.bhytdate,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,bh.dtcbh_luyke6thang,mrd.departmentgroupid,degp.departmentgroupname,mrd.departmentid,de.departmentname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,hsba.lastaccessdate,bh.lastaccessdate,bh.bhytcheckstatus,hsba.bhytcheckstatus;


