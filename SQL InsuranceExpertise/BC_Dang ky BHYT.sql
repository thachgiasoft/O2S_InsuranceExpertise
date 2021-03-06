﻿---bao cao Dang ky the BHYT ngay 15/8
--Nội trú

SELECT row_number () over (order by "+orderby+") as stt,
	hsba.patientid, 
	log.vienphiid, 
	hsba.sovaovien, 
	'' as sodkbhyt,
	hsba.patientname,
	bh.bhytcode,
	bh.macskcbbd,
	bh.bhytfromdate,
	bh.bhytutildate,
	(case bh.bhyt_loaiid
			when 1 then 'Đúng tuyến'
			when 2 then 'Đúng tuyến (giới thiệu)'
			when 3 then 'Đúng tuyến (cấp cứu)'
			when 4 then 'Trái tuyến'
			else '' end) as bhyt_loaiid,
	bh.noisinhsong,
	(case when bh.du5nam6thangluongcoban=1 then 'OK' end) as du5nam6thangluongcoban,			
	degp.departmentgroupname,
	(mrd.noigioithieucode || '-' || ncd.benhvienname) as noichuyenden,
	hsba.hosobenhandate,
	(case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hsba.hosobenhandate_ravien end) as hosobenhandate_ravien,
	log.logtime,
	(log.loguser || ' - ' || ndk.username )as nguoidangky,	
	'' as bhytchecknote,
	'' as nguoihuydangky,
	log.logeventcontent
FROM (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien from hosobenhan "+tieuchi_hsba+") hsba 
	inner join (select logeventid,hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype=1 "+tieuchi_log+") log on log.hosobenhanid=hsba.hosobenhanid
	inner join (select medicalrecordid,departmentgroupid,departmentid,bhytid,chandoanbandau,noigioithieucode,xutrikhambenhid,nextdepartmentid from medicalrecord where loaibenhanid<>24 and departmentgroupid in ("+lstKhoaChonLayBC+")) mrd on mrd.medicalrecordid=log.medicalrecordid
	inner join (select bhytid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid from bhyt where bhytcode<>'') bh on bh.bhytid=mrd.bhytid
	left join (select userhisid,usercode,username from nhompersonnel) ndk on ndk.usercode=log.loguser
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid
	left join (select ie_benhvien.benhvienkcbbd,ie_benhvien,benhvienname from dblink('myconn_ie','SELECT benhvienkcbbd,benhvienname FROM ie_benhvien') AS ie_benhvien(benhvienkcbbd text,benhvienname text)) ncd on ncd.benhvienkcbbd=mrd.noigioithieucode
where log.logeventcontent like '%' || bh.bhytcode || '%';	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
FROM (select hosobenhanid,patientid,sovaovien,patientname,hosobenhandate,hosobenhandate_ravien from hosobenhan "+tieuchi_hsba+") hsba 
	inner join (select hosobenhanid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid from bhyt where bhytcode<>'' "+tieuchi_bhyt+") bh on hsba.hosobenhanid=bh.hosobenhanid
	left join (select hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype in (1,8) "+tieuchi_log+") log on log.hosobenhanid=hsba.hosobenhanid and log.logeventcontent like '%' || bh.bhytcode || '%'
	left join (select medicalrecordid,departmentgroupid,departmentid from medicalrecord where departmentgroupid in ("+lstKhoaChonLayBC+")) mrd on mrd.medicalrecordid=log.medicalrecordid
	left join (select userhisid,usercode,username from nhompersonnel) nv on nv.usercode=log.loguser
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid
GROUP BY hsba.patientid,log.vienphiid,hsba.sovaovien,hsba.patientname,bh.bhytcode,bh.macskcbbd,bh.bhytfromdate,bh.bhytutildate,log.logeventcontent,bh.noisinhsong,bh.du5nam6thangluongcoban,degp.departmentgroupname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,log.logform,log.loguser,nv.username,bh.bhyt_loaiid,log.logeventtype,log.logtime;
	

	
	
--------
Theo ngày vào viện
where hsba.hosobenhandate between '2017-03-01 00:00:00' and '2017-03-15 23:59:59'
Theo ngày ra viện
where hsba.hosobenhandate_ravien between '2017-03-01 00:00:00' and '2017-03-15 23:59:59'

Theo ngày đăng ký thẻ
and bhytdate between '2017-03-01 00:00:00' and '2017-03-15 23:59:59'

and logtime between '2017-03-01 00:00:00' and '2017-03-15 23:59:59'

Theo ngày kiểm tra thông tuyến



	
	
	
	
	
	
	
	
	
	