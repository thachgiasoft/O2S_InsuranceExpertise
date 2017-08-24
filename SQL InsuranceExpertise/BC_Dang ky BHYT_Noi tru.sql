---bao cao Dang ky the BHYT ngay 24/8
--Nội trú

--them stt_bhyt,
--sua cot Ket qua tra ve tren cong bhyt
--them cot doi tuong BN
--ngay 24/8 them cot ngay check cong bhyt

SELECT row_number () over (order by "+orderby+") as stt,
	hsba.patientid, 
	log.vienphiid, 
	hsba.sovaovien, 
	bh.stt_dkbhyt as sodkbhyt,
	hsba.patientname,
	(case vp.doituongbenhnhanid when 1 then 'BHYT'
			when 2 then 'Viện phí'
			when 3 then 'Dịch vụ'
			when 4 then 'Người nước ngoài'
			when 5 then 'Miễn phí'
			when 6 then 'Hợp đồng'
		end) as doituongbenhnhanid,
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
	(select ibc.bhytchecknote from dblink('myconn_ie','SELECT bhytcheckid,bhytid,bhytchecknote FROM ie_bhyt_check " + tieuchi_ie_bhyt_check + "') AS ibc(bhytcheckid integer,bhytid integer,bhytchecknote text) where ibc.bhytid=bh.bhytid order by ibc.bhytcheckid desc limit 1) as bhytchecknote,
	(select ibc.bhytchecksdate from dblink('myconn_ie','SELECT bhytcheckid,bhytid,bhytchecksdate FROM ie_bhyt_check " + tieuchi_ie_bhyt_check + "') AS ibc(bhytcheckid integer,bhytid integer,bhytchecksdate timestamp without time zone) where ibc.bhytid=bh.bhytid order by ibc.bhytcheckid desc limit 1) as bhytchecksdate,
	'' as nguoihuydangky,
	log.logeventcontent
FROM (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,sovaovien from hosobenhan "+tieuchi_hsba+") hsba 
	inner join (select logeventid,hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype=8 and medicalrecordid=0 "+tieuchi_log+") log on log.hosobenhanid=hsba.hosobenhanid
	inner join (select hosobenhanid,medicalrecordid,departmentgroupid,departmentid,bhytid,chandoanbandau,noigioithieucode,xutrikhambenhid,nextdepartmentid from medicalrecord where loaibenhanid=24 and hinhthucvaovienid=0) mrd on mrd.hosobenhanid=hsba.hosobenhanid
	inner join (select vienphiid,bhytid,hosobenhanid,doituongbenhnhanid from vienphi where loaivienphiid=0 "+tieuchi_vp+") vp on vp.vienphiid=log.vienphiid
	inner join (select bhytid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid,stt_dkbhyt from bhyt where bhytcode<>'') bh on bh.bhytid=vp.bhytid
	inner join (select userhisid,usercode,username from nhompersonnel) ndk on ndk.usercode=log.loguser
	inner join tbldepartment user_de on user_de.usercode=log.loguser
	inner join (select departmentid,departmentname,departmentgroupid from department) de on de.departmentid=user_de.departmentid
	inner join (select departmentgroupid,departmentgroupname from departmentgroup where departmentgroupid in ("+lstKhoaChonLayBC+")) degp on degp.departmentgroupid=de.departmentgroupid
	left join (select ie_benhvien.benhvienkcbbd,ie_benhvien,benhvienname from dblink('myconn_ie','SELECT benhvienkcbbd,benhvienname FROM ie_benhvien') AS ie_benhvien(benhvienkcbbd text,benhvienname text)) ncd on ncd.benhvienkcbbd=mrd.noigioithieucode
where log.logeventcontent like '%' || bh.bhytcode || '%'	
group by hsba.patientid,log.vienphiid,hsba.sovaovien,hsba.patientname,bh.bhytcode,bh.macskcbbd,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,degp.departmentgroupname,mrd.noigioithieucode,ncd.benhvienname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,log.logtime,log.loguser,ndk.username,log.logeventcontent,bh.stt_dkbhyt,bh.bhytid,vp.doituongbenhnhanid;
	
	
	
	
	
	
	
	
	
	
	




	
	
	
	
	
	
	
	
	
	