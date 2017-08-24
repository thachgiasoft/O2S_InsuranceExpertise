----============================ Báo cáo Đăng ký thẻ BHYT Ngoại trú
--ngay 17/8/2017
--ngay 21/8: ket qua ngoai tru tra ve mac dinh la Thong tin the chinh xac
--ngay 24/8 them cot ngay check cong bhyt

--SELECT dblink_connect('myconn_ie', 'dbname=O2SInsurance port=5432 host=localhost user=postgres password=1234');

SELECT row_number () over (order by "+orderby+") as stt,
	hsba.patientid, 
	log.vienphiid, 
	hsba.patientname,
	(case mrd.doituongbenhnhanid when 1 then 'BHYT'
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
	mrd.chandoanbandau,
	(mrd.noigioithieucode || '-' || ncd.benhvienname) as noichuyenden,
	degp.departmentgroupid,
	de.departmentid,
	(degp.departmentgroupname || '-' ||de.departmentname) as khoaphong,
	hsba.hosobenhandate,
	(case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hsba.hosobenhandate_ravien end) as hosobenhandate_ravien,
	(case mrd.xutrikhambenhid
		when 1 then 'Cấp toa cho về'
		when 2 then 'Điều trị ngoại trú'
		when 3 then 'Hẹn'
		when 4 then 'Nhập viện'
		when 5 then 'Chuyển viện'
		when 6 then 'Tử vong'
		when 7 then 'Trốn viện'
		when 8 then 'Hẹn khám tiếp'
		when 9 then 'Hẹn khám mới'
		when 10 then 'Khác2'
		when 11 then 'Khác'
	end) as xutrikhambenh,
	mrd.nextdepartmentid,
	kvv.departmentgroupname as khoavaovien,	
	log.logtime,
	(log.loguser || ' - ' || ndk.username )as nguoidangky,
	--(select ibc.bhytchecknote from dblink('myconn_ie','SELECT bhytcheckid,bhytid,bhytchecknote FROM ie_bhyt_check') AS ibc(bhytcheckid integer,bhytid integer,bhytchecknote text) where ibc.bhytid=bh.bhytid order by ibc.bhytcheckid desc limit 1) as bhytchecknote,
	'Thông tin thẻ chính xác' as bhytchecknote,
	(select ibc.bhytchecksdate from dblink('myconn_ie','SELECT bhytcheckid,bhytid,bhytchecksdate FROM ie_bhyt_check " + tieuchi_ie_bhyt_check + "') AS ibc(bhytcheckid integer,bhytid integer,bhytchecksdate timestamp without time zone) where ibc.bhytid=bh.bhytid order by ibc.bhytcheckid desc limit 1) as bhytchecksdate,
	'' as nguoihuydangky,
	log.logeventcontent
FROM (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien from hosobenhan "+tieuchi_hsba+") hsba 
	inner join (select logeventid,hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype=1 "+tieuchi_log+") log on log.hosobenhanid=hsba.hosobenhanid
	inner join (select medicalrecordid,departmentgroupid,departmentid,bhytid,chandoanbandau,noigioithieucode,xutrikhambenhid,nextdepartmentid,doituongbenhnhanid from medicalrecord where loaibenhanid=24 and departmentgroupid in ("+lstKhoaChonLayBC+")) mrd on mrd.medicalrecordid=log.medicalrecordid
	inner join (select bhytid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid from bhyt where bhytcode<>'') bh on bh.bhytid=mrd.bhytid
	left join (select userhisid,usercode,username from nhompersonnel) ndk on ndk.usercode=log.loguser
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid
	left join (select departmentid,departmentname from department) de on de.departmentid=mrd.departmentid
	left join (select ie_benhvien.benhvienkcbbd,ie_benhvien,benhvienname from dblink('myconn_ie','SELECT benhvienkcbbd,benhvienname FROM ie_benhvien') AS ie_benhvien(benhvienkcbbd text,benhvienname text)) ncd on ncd.benhvienkcbbd=mrd.noigioithieucode
	left join (select departmentgroupid,departmentgroupname from departmentgroup) kvv on kvv.departmentgroupid=mrd.nextdepartmentid
where log.logeventcontent like '%' || bh.bhytcode || '%';















----------Ban Nhap

SELECT row_number () over (order by hsba.patientid) as stt,
	hsba.patientid, 
	log.vienphiid, 
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
	mrd.chandoanbandau,
	mrd.noigioithieucode,
	ncd.benhvienname as noichuyenden,
	degp.departmentgroupid,
	de.departmentid,
	(degp.departmentgroupname || '-' ||de.departmentname) as khoaphong,
	hsba.hosobenhandate,
	(case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hsba.hosobenhandate_ravien end) as hosobenhandate_ravien,
	(case mrd.xutrikhambenhid
		when 1 then 'Cấp toa cho về'
		when 2 then 'Điều trị ngoại trú'
		when 4 then 'Nhập viện'
		when 5 then 'Chuyển viện'
		when 6 then 'Tử vong'
		when 7 then 'Trốn viện'
		when 8 then 'Khác'
	end) as xutrikhambenh,
	mrd.nextdepartmentid, --when mrd.xutrikhambenhid=4
	kvv.departmentgroupname as khoavaovien,	
	log.logtime,
	(log.loguser || ' - ' || nv.username )as nguoidangky,
	'' as bhytchecknote,
	log.logeventcontent
	/*hsba.hosobenhanid,
	bh.bhytid,
	log.logeventid,
	mrd.medicalrecordid,
	nv.usercode */	
FROM (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien from hosobenhan) hsba 
	inner join (select logeventid,hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype=1 and logtime between '2017-01-01 00:00:00' and '2017-01-05 00:00:00') log on log.hosobenhanid=hsba.hosobenhanid
	inner join (select medicalrecordid,departmentgroupid,departmentid,bhytid,chandoanbandau,noigioithieucode,xutrikhambenhid,nextdepartmentid from medicalrecord where loaibenhanid=24 and departmentgroupid in (33)) mrd on mrd.medicalrecordid=log.medicalrecordid
	inner join (select bhytid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid from bhyt where bhytcode<>'') bh on bh.bhytid=mrd.bhytid
	left join (select userhisid,usercode,username from nhompersonnel) nv on nv.usercode=log.loguser
	left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid
	left join (select departmentid,departmentname from department) de on de.departmentid=mrd.departmentid
	left join (select ie_benhvien.benhvienkcbbd,ie_benhvien,benhvienname from dblink('myconn_ie','SELECT benhvienkcbbd,benhvienname FROM ie_benhvien') AS ie_benhvien(benhvienkcbbd text,benhvienname text)) ncd on ncd.benhvienkcbbd=mrd.noigioithieucode
	left join (select departmentgroupid,departmentgroupname from departmentgroup) kvv on kvv.departmentgroupid=mrd.nextdepartmentid
where log.logeventcontent like '%' || bh.bhytcode || '%'
	
	