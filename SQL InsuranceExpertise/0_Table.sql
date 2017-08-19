---Bảng trong dự án: O2S_InsuranceExpertise

--=================================================== table IE_license
CREATE TABLE IE_license
(
  licenseid serial NOT NULL,
  datakey text,
  licensekey text,
  CONSTRAINT IE_license_pkey PRIMARY KEY (licenseid)
);
--=================================================== table IE_config
-- Table: ie_config

-- DROP TABLE ie_config;

CREATE TABLE ie_config
(
  configid serial NOT NULL,
  usergdbhyt text,
  passgdbhyt text,
  urlfullserver text,
  configtype integer,
  CONSTRAINT ie_config_pkey PRIMARY KEY (configid)
)
CREATE INDEX IE_configtype_idx
  ON ie_config
  USING btree
  (configtype);
  
--=================================================== -- Table: ie_version
-- DROP TABLE ie_version;

CREATE TABLE ie_version
(
  versionid serial NOT NULL,
  appversion text,
  app_link text,
  app_type integer,
  updateapp bytea,
  appsize integer,
  sqlversion text,
  updatesql bytea,
  sqlsize integer,
  sync_flag integer,
  update_flag integer,
  CONSTRAINT ie_version_pkey PRIMARY KEY (versionid)
);

-- DROP INDEX ie_version_app_link_idx;

CREATE INDEX ie_version_app_link_idx
  ON ie_version
  USING btree
  (app_link COLLATE pg_catalog."default");

-- Index: ie_version_appversion_idx

-- DROP INDEX ie_version_appversion_idx;

CREATE INDEX ie_version_appversion_idx
  ON ie_version
  USING btree
  (appversion COLLATE pg_catalog."default");

-- Index: ie_version_versionid_idx

-- DROP INDEX ie_version_versionid_idx;

CREATE INDEX ie_version_versionid_idx
  ON ie_version
  USING btree
  (versionid);


--=================================================== Table: IE_tbluser
-- DROP TABLE IE_tbluser;
CREATE TABLE IE_tbluser
(
  userid serial NOT NULL,
  usercode text NOT NULL,
  username text,
  userpassword text,
  userstatus integer,
  usergnhom integer,
  usernote text,
  userhisid integer,
  CONSTRAINT IE_tbluser_pkey PRIMARY KEY (userid)
);

-- Index: IE_tbluser_usercode_idx

-- DROP INDEX IE_tbluser_usercode_idx;

CREATE INDEX IE_tbluser_usercode_idx
  ON IE_tbluser
  USING btree
  (usercode COLLATE pg_catalog."default");

-- Index: IE_tbluser_userhisid_idx

-- DROP INDEX IE_tbluser_userhisid_idx;

CREATE INDEX IE_tbluser_userhisid_idx
  ON IE_tbluser
  USING btree
  (userhisid);

-- Index: IE_tbluser_userid_idx

-- DROP INDEX IE_tbluser_userid_idx;

CREATE INDEX IE_tbluser_userid_idx
  ON IE_tbluser
  USING btree
  (userid);


--=================================================== Table: IE_tbluser_departmentgroup

-- DROP TABLE IE_tbluser_departmentgroup;

CREATE TABLE IE_tbluser_departmentgroup
(
  userdepgid serial NOT NULL,
  departmentgroupid integer,
  departmentid integer,
  departmenttype integer,
  usercode text,
  userdepgidnote text,
  CONSTRAINT tbluser_departmentgroup_pkey PRIMARY KEY (userdepgid)
);

-- Index: tbldegp_departmentgroupid_idx

-- DROP INDEX tbldegp_departmentgroupid_idx;

CREATE INDEX tbldegp_departmentgroupid_idx
  ON IE_tbluser_departmentgroup
  USING btree
  (departmentgroupid);

-- Index: tbldegp_departmentid_idx

-- DROP INDEX tbldegp_departmentid_idx;

CREATE INDEX tbldegp_departmentid_idx
  ON IE_tbluser_departmentgroup
  USING btree
  (departmentid);

-- Index: tbldegp_usercode_idx

-- DROP INDEX tbldegp_usercode_idx;

CREATE INDEX tbldegp_usercode_idx
  ON IE_tbluser_departmentgroup
  USING btree
  (usercode COLLATE pg_catalog."default");

-- Index: tbldegp_userdepgid_idx

-- DROP INDEX tbldegp_userdepgid_idx;

CREATE INDEX tbldegp_userdepgid_idx
  ON IE_tbluser_departmentgroup
  USING btree
  (userdepgid);

--===================================================Table: IE_tbluser_permission

-- DROP TABLE IE_tbluser_permission;

CREATE TABLE IE_tbluser_permission
(
  userpermissionid serial NOT NULL,
  permissionid integer,
  permissioncode text,
  permissionname text,
  userid integer,
  usercode text,
  permissioncheck boolean,
  userpermissionnote text,
  CONSTRAINT userpermissionid_pkey PRIMARY KEY (userpermissionid)
);

-- Index: userpermiss_permissioncode_idx

-- DROP INDEX userpermiss_permissioncode_idx;

CREATE INDEX userpermiss_permissioncode_idx
  ON IE_tbluser_permission
  USING btree
  (permissioncode COLLATE pg_catalog."default");

-- Index: userpermiss_permissionid_idx

-- DROP INDEX userpermiss_permissionid_idx;

CREATE INDEX userpermiss_permissionid_idx
  ON IE_tbluser_permission
  USING btree
  (permissionid);

-- Index: userpermiss_usercode_idx

-- DROP INDEX userpermiss_usercode_idx;

CREATE INDEX userpermiss_usercode_idx
  ON IE_tbluser_permission
  USING btree
  (usercode COLLATE pg_catalog."default");

-- Index: userpermiss_userid_idx

-- DROP INDEX userpermiss_userid_idx;

CREATE INDEX userpermiss_userid_idx
  ON IE_tbluser_permission
  USING btree
  (userid);

-- Index: userpermiss_userpermissionid_idx

-- DROP INDEX userpermiss_userpermissionid_idx;

CREATE INDEX userpermiss_userpermissionid_idx
  ON IE_tbluser_permission
  USING btree
  (userpermissionid);

--=================================================== Table: ie_tbluser_medicinephongluu

-- DROP TABLE ie_tbluser_medicinephongluu;

CREATE TABLE ie_tbluser_medicinephongluu
(
  userphongluutid serial NOT NULL,
  medicinephongluuid integer,
  medicinestoreid integer,
  usercode text,
  userdepgidnote text,
  CONSTRAINT ie_tbluser_medicinephongluu_pkey PRIMARY KEY (userphongluutid)
);

-- Index: tblphongluu_medicinephongluuid_idx

-- DROP INDEX tblphongluu_medicinephongluuid_idx;

CREATE INDEX tblphongluu_medicinephongluuid_idx
  ON ie_tbluser_medicinephongluu
  USING btree
  (medicinephongluuid);

-- Index: tblphongluu_medicinestoreid_idx

-- DROP INDEX tblphongluu_medicinestoreid_idx;

CREATE INDEX tblphongluu_medicinestoreid_idx
  ON ie_tbluser_medicinephongluu
  USING btree
  (medicinestoreid);

-- Index: tblphongluu_usercode_idx

-- DROP INDEX tblphongluu_usercode_idx;

CREATE INDEX tblphongluu_usercode_idx
  ON ie_tbluser_medicinephongluu
  USING btree
  (usercode COLLATE pg_catalog."default");

-- Index: tblphongluu_userphongluutid_idx

-- DROP INDEX tblphongluu_userphongluutid_idx;

CREATE INDEX tblphongluu_userphongluutid_idx
  ON ie_tbluser_medicinephongluu
  USING btree
  (userphongluutid);

 
--=================================================== Table: ie_tbluser_medicinestore

-- DROP TABLE ie_tbluser_medicinestore;

CREATE TABLE ie_tbluser_medicinestore
(
  usermestid serial NOT NULL,
  medicinestoreid integer,
  medicinestoretype integer,
  usercode text,
  userdepgidnote text,
  CONSTRAINT ie_tbluser_medicinestore_pkey PRIMARY KEY (usermestid)
);

-- Index: tblmedistore_medicinestoreid_idx

-- DROP INDEX tblmedistore_medicinestoreid_idx;

CREATE INDEX tblmedistore_medicinestoreid_idx
  ON ie_tbluser_medicinestore
  USING btree
  (medicinestoreid);

-- Index: tblmedistore_usercode_idx

-- DROP INDEX tblmedistore_usercode_idx;

CREATE INDEX tblmedistore_usercode_idx
  ON ie_tbluser_medicinestore
  USING btree
  (usercode COLLATE pg_catalog."default");

-- Index: tblmedistore_usermestid_idx

-- DROP INDEX tblmedistore_usermestid_idx;

CREATE INDEX tblmedistore_usermestid_idx
  ON ie_tbluser_medicinestore
  USING btree
  (usermestid);

 
--===================================================Table: IE_tbllog

-- DROP TABLE IE_tbllog;

CREATE TABLE IE_tbllog
(
  logid serial NOT NULL,
  loguser text,
  logvalue text,
  ipaddress text,
  computername text,
  softversion text,
  logtime timestamp without time zone,
  CONSTRAINT IE_tbllog_pkey PRIMARY KEY (logid)
);

--=================================================== Table: IE_otherlist

-- DROP TABLE IE_otherlist;

CREATE TABLE IE_otherlist
(
  otherlistid serial NOT NULL,
  othertypelistid integer,
  otherlistcode text,
  otherlistname text,
  otherlistvalue text,
  otherliststatus integer,
  otherlistnote text,
  CONSTRAINT IE_otherlist_pkey PRIMARY KEY (otherlistid)
);

-- Index: IE_otherlistid_idx

-- DROP INDEX IE_otherlistid_idx;

CREATE INDEX IE_otherlistid_idx
  ON IE_otherlist
  USING btree
  (otherlistid);

-- Index: IE_otothertypelistid_idx

-- DROP INDEX IE_otothertypelistid_idx;

CREATE INDEX IE_otothertypelistid_idx
  ON IE_otherlist
  USING btree
  (othertypelistid);


--=================================================== Table: IE_othertypelist

-- DROP TABLE IE_othertypelist;

CREATE TABLE IE_othertypelist
(
  othertypelistid serial NOT NULL,
  othertypelistcode text,
  othertypelistname text,
  othertypeliststatus integer,
  othertypelistnote text,
  CONSTRAINT IE_othertypelist_pkey PRIMARY KEY (othertypelistid)
);

-- Index: IE_othertypelist_typecode_idx

-- DROP INDEX IE_othertypelist_typecode_idx;

CREATE INDEX IE_othertypelist_typecode_idx
  ON IE_othertypelist
  USING btree
  (othertypelistcode COLLATE pg_catalog."default");

-- Index: IE_othertypelistid_idx

-- DROP INDEX IE_othertypelistid_idx;

CREATE INDEX IE_othertypelistid_idx
  ON IE_othertypelist
  USING btree
  (othertypelistid);


--===================================================Table: IE_option

-- DROP TABLE IE_option;

CREATE TABLE IE_option
(
  optionid serial NOT NULL,
  optioncode text,
  optionname text,
  optionvalue text,
  optionnote text,
  optionlook integer,
  optiondate timestamp without time zone,
  optioncreateuser text,
  CONSTRAINT IE_option_pkey PRIMARY KEY (optionid)
);

-- Index: IE_option_toolsoptioncode_idx

-- DROP INDEX IE_option_toolsoptioncode_idx;

CREATE INDEX IE_option_toolsoptioncode_idx
  ON IE_option
  USING btree
  (optioncode COLLATE pg_catalog."default");

-- Index: IE_option_toolsoptionid_idx

-- DROP INDEX IE_option_toolsoptionid_idx;

CREATE INDEX IE_option_toolsoptionid_idx
  ON IE_option
  USING btree
  (optionid);

-- Index: IE_option_toolsoptionvalue_idx

-- DROP INDEX IE_option_toolsoptionvalue_idx;

CREATE INDEX IE_option_toolsoptionvalue_idx
  ON IE_option
  USING btree
  (optionvalue COLLATE pg_catalog."default");


--=================================================== Table IE_bhyt_check
--ALTER TABLE bhyt add bhytcheckstatus integer DEFAULT 0;
-- DROP TABLE IE_bhyt_check;

CREATE TABLE IE_bhyt_check
(
  bhytcheckid serial NOT NULL,
  bhytid integer,
  hosobenhanid integer,
  vienphiid integer,
  patientid integer,
  patientname text,
  birthday timestamp without time zone,
  birthday_year integer,
  gioitinhcode text,
  gioitinhname text,
  bhytcode text,
  macskcbbd text,
  bhytdate timestamp without time zone,
  bhytfromdate timestamp without time zone,
  bhytutildate timestamp without time zone,
  bhyt_loaiid integer,
  noisinhsong text,
  du5nam6thangluongcoban integer,
  dtcbh_luyke6thang integer,
  bhytcheckstatus integer,
  bhytchecksdate timestamp without time zone,
  departmentgroupid integer,
  departmentid integer,
  hosobenhandate timestamp without time zone,
  hosobenhandate_ravien timestamp without time zone,
  lastupdatedate_hsba timestamp without time zone,
  lastupdatedate_bhyt timestamp without time zone,
  bhytchecknote text,
  CONSTRAINT bhytcheckid_pkey PRIMARY KEY (bhytcheckid)
);
CREATE INDEX IE_bhyt_check_bhytid_idx
  ON IE_bhyt_check
  USING btree
  (bhytid); 
CREATE INDEX IE_bhyt_check_hosobenhanid_idx
  ON IE_bhyt_check
  USING btree
  (hosobenhanid); 
CREATE INDEX IE_bhyt_check_vienphiid_idx
  ON IE_bhyt_check
  USING btree
  (vienphiid); 
CREATE INDEX IE_bhyt_check_patientid_idx
  ON IE_bhyt_check
  USING btree
  (patientid); 
CREATE INDEX IE_bhyt_check_bhytcode_idx
  ON IE_bhyt_check
  USING btree
  (bhytcode); 
CREATE INDEX IE_bhyt_check_departmentgroupid_idx
  ON IE_bhyt_check
  USING btree
  (departmentgroupid); 
CREATE INDEX IE_bhyt_check_departmentid_idx
  ON IE_bhyt_check
  USING btree
  (departmentid);   
CREATE INDEX IE_bhyt_check_hosobenhandate_idx
  ON IE_bhyt_check
  USING btree
  (hosobenhandate);  
CREATE INDEX IE_bhyt_check_patientname_idx
  ON IE_bhyt_check
  USING btree
  (patientname);    
CREATE INDEX IE_bhyt_check_birthday_idx
  ON IE_bhyt_check
  USING btree
  (birthday); 
CREATE INDEX IE_bhyt_check_gioitinhcode_idx
  ON IE_bhyt_check
  USING btree
  (gioitinhcode); 
CREATE INDEX IE_bhyt_check_macskcbbd_idx
  ON IE_bhyt_check
  USING btree
  (macskcbbd); 
CREATE INDEX IE_bhyt_check_bhytfromdate_idx
  ON IE_bhyt_check
  USING btree
  (bhytfromdate);    
CREATE INDEX IE_bhyt_check_bhytutildate_idx
  ON IE_bhyt_check
  USING btree
  (bhytutildate);      
  
--=================================================== Table IE_lichsukcb_check
-- DROP TABLE IE_lichsukcb_check;

CREATE TABLE IE_lichsukcb_check
(
  lichsukcbcheckid serial not null,
  patientid integer,
  patientname text,
  mahoso integer,
  macskcb text,
  tencskcb text,
  ngayvaovien timestamp without time zone,
  ngayravien timestamp without time zone,
  tenbenh text,
  tinhtrangcode text,
  tinhtrangten text,
  kqdieutricode text,
  kqdieutri_ten text,
  bhytchecksdate timestamp without time zone,  
  CONSTRAINT IE_lichsukcb_check_pkey PRIMARY KEY (lichsukcbcheckid)
);
  
CREATE INDEX lichsukcbcheck_patientid_idx
  ON IE_lichsukcb_check
  USING btree
  (patientid);    
CREATE INDEX lichsukcbcheck_mahosoidx
  ON IE_lichsukcb_check
  USING btree
  (mahoso);    
  
  
  
--===================================================-- Table: ie_benhvien

-- DROP TABLE ie_benhvien;

CREATE TABLE ie_benhvien
(
  benhvienid serial NOT NULL,
  benhvienkcbbd text,
  benhviencode text,
  benhvienname text,
  benhvienaddress text,
  benhvienhang text,
  benhvienloai text,
  benhvientuyen text,
  ghichu text,
  matinh text,
  mahuyen text,
  maxa text,
  version timestamp without time zone,
  sync_flag integer,
  update_flag integer,
  CONSTRAINT ie_benhvien_pkey PRIMARY KEY (benhvienid)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ie_benhvien
  OWNER TO postgres;

-- Index: ie_benhvien_benhviencode_idx

-- DROP INDEX ie_benhvien_benhviencode_idx;

CREATE INDEX ie_benhvien_benhviencode_idx
  ON ie_benhvien
  USING btree
  (benhviencode COLLATE pg_catalog."default");

CREATE INDEX ie_benhvien_benhvienkcbbd_idx
  ON ie_benhvien
  USING btree
  (benhvienkcbbd);
--=================================================================Table Giam dinh BHYT.

--===================================================TABLE ie_danhmuc_dvkt;
-- DROP TABLE ie_danhmuc_dvkt;

CREATE TABLE ie_danhmuc_dvkt
(
	danhmucdvktid serial NOT NULL,
	stt	integer,
	ma_dvkt text,
	ma_ax text,
	ten_dvkt text,
	ten_ax text,
	ma_gia text,
	don_gia double precision,
	gia_ax double precision,
	quyet_dinh text,
	cong_bo integer,
	ma_cosokcb integer,
	manhom_9324 text,
	hieuluc_id integer,
	hieuluc text,
	ketqua_id integer,
	ketqua text,
	lydotuchoi text,
	is_look integer default 0,
	version timestamp without time zone,
  CONSTRAINT ie_danhmuc_dvkt_pkey PRIMARY KEY (danhmucdvktid)
);
CREATE INDEX ie_danhmuc_dvkt_ma_dvkt_idx ON ie_danhmuc_dvkt USING btree (ma_dvkt); 
CREATE INDEX ie_danhmuc_dvkt_ma_ax_idx ON ie_danhmuc_dvkt USING btree (ma_ax); 
CREATE INDEX ie_danhmuc_dvkt_ten_dvkt_idx ON ie_danhmuc_dvkt USING btree (ten_dvkt); 
CREATE INDEX ie_danhmuc_dvkt_ten_ax_idx ON ie_danhmuc_dvkt USING btree (ten_ax); 
CREATE INDEX ie_danhmuc_dvkt_ma_gia_idx ON ie_danhmuc_dvkt USING btree (ma_gia); 
CREATE INDEX ie_danhmuc_dvkt_don_gia_idx ON ie_danhmuc_dvkt USING btree (don_gia); 
CREATE INDEX ie_danhmuc_dvkt_gia_ax_idx ON ie_danhmuc_dvkt USING btree (gia_ax); 
CREATE INDEX ie_danhmuc_dvkt_manhom_9324_idx ON ie_danhmuc_dvkt USING btree (manhom_9324); 

--===================================================TABLE ie_danhmuc_giuong;
-- DROP TABLE ie_danhmuc_giuong;

CREATE TABLE ie_danhmuc_giuong
(
	danhmucgiuongid serial NOT NULL,
	stt	integer,
	ma_dvkt text,
	ma_ax text,
	ten_dvkt text,
	ten_ax text,
	ma_gia text,
	don_gia double precision,
	gia_ax double precision,
	quyet_dinh text,
	cong_bo integer,
	ma_cosokcb integer,
	manhom_9324 text,
	hieuluc_id integer,
	hieuluc text,
	ketqua_id integer,
	ketqua text,
	lydotuchoi text,
	is_look integer default 0,
	version timestamp without time zone,
  CONSTRAINT ie_danhmuc_giuong_pkey PRIMARY KEY (danhmucgiuongid)
);
CREATE INDEX ie_danhmuc_giuong_ma_dvkt_idx ON ie_danhmuc_dvkt USING btree (ma_dvkt);
CREATE INDEX ie_danhmuc_giuong_ma_ax_idx ON ie_danhmuc_dvkt USING btree (ma_ax); 
CREATE INDEX ie_danhmuc_giuong_ten_dvkt_idx ON ie_danhmuc_dvkt USING btree (ten_dvkt); 
CREATE INDEX ie_danhmuc_giuong_ten_ax_idx ON ie_danhmuc_dvkt USING btree (ten_ax); 
CREATE INDEX ie_danhmuc_giuong_ma_gia_idx ON ie_danhmuc_dvkt USING btree (ma_gia); 
CREATE INDEX ie_danhmuc_giuong_don_gia_idx ON ie_danhmuc_dvkt USING btree (don_gia); 
CREATE INDEX ie_danhmuc_giuong_gia_ax_idx ON ie_danhmuc_dvkt USING btree (gia_ax); 
CREATE INDEX ie_danhmuc_giuong_manhom_9324_idx ON ie_danhmuc_dvkt USING btree (manhom_9324); 
  
--===================================================Table ie_danhmuc_thuoc
-- DROP TABLE ie_danhmuc_thuoc;

CREATE TABLE ie_danhmuc_thuoc
(
	danhmucthuocid serial NOT NULL,
	stt	integer,
	ma_hoat_chat text,
	ma_ax text,
	hoat_chat text,
	hoatchat_ax text,
	ma_duong_dung text,
	ma_duongdung_ax text,
	duong_dung text,
	duongdung_ax text,
	ham_luong text,
	hamluong_ax text,
	ten_thuoc text,
	tenthuoc_ax text,
	so_dang_ky text,
	sodangky_ax text,
	dong_goi text,
	don_vi_tinh text,
	don_gia double precision,
	don_gia_tt double precision,
	so_luong double precision,
	ma_cskcb integer,
	hang_sx text,
	nuoc_sx text,
	nha_thau text,
	quyet_dinh text,
	cong_bo text,
	ma_thuoc_bv text,
	loai_thuoc integer,
	loai_thau integer,
	nhom_thau text,
	manhom_9324 integer,
	hieuluc_id integer,
	hieuluc text,
	ketqua_id integer,
	ketqua text,
	lydotuchoi text,
	is_look integer default 0,
	version timestamp without time zone,
  CONSTRAINT ie_danhmuc_thuoc_pkey PRIMARY KEY (danhmucthuocid)
);
CREATE INDEX ie_danhmuc_thuoc_ma_hoat_chat_idx ON ie_danhmuc_thuoc USING btree (ma_hoat_chat); 
CREATE INDEX ie_danhmuc_thuoc_ma_ax_idx ON ie_danhmuc_thuoc USING btree (ma_ax); 
CREATE INDEX ie_danhmuc_thuoc_hoat_chat_idx ON ie_danhmuc_thuoc USING btree (hoat_chat); 
CREATE INDEX ie_danhmuc_thuoc_hoatchat_ax_idx ON ie_danhmuc_thuoc USING btree (hoatchat_ax); 
CREATE INDEX ie_danhmuc_thuoc_ma_duong_dung_idx ON ie_danhmuc_thuoc USING btree (ma_duong_dung); 
CREATE INDEX ie_danhmuc_thuoc_ma_duongdung_ax_idx ON ie_danhmuc_thuoc USING btree (ma_duongdung_ax); 
CREATE INDEX ie_danhmuc_thuoc_duong_dung_idx ON ie_danhmuc_thuoc USING btree (duong_dung); 
CREATE INDEX ie_danhmuc_thuoc_duongdung_ax_idx ON ie_danhmuc_thuoc USING btree (duongdung_ax); 
CREATE INDEX ie_danhmuc_thuoc_ten_thuoc_idx ON ie_danhmuc_thuoc USING btree (ten_thuoc); 
CREATE INDEX ie_danhmuc_thuoc_tenthuoc_ax_idx ON ie_danhmuc_thuoc USING btree (tenthuoc_ax); 
CREATE INDEX ie_danhmuc_thuoc_so_dang_ky_idx ON ie_danhmuc_thuoc USING btree (so_dang_ky); 
CREATE INDEX ie_danhmuc_thuoc_sodangky_ax_idx ON ie_danhmuc_thuoc USING btree (sodangky_ax); 
CREATE INDEX ie_danhmuc_thuoc_dong_goi_idx ON ie_danhmuc_thuoc USING btree (dong_goi); 
CREATE INDEX ie_danhmuc_thuoc_don_vi_tinh_idx ON ie_danhmuc_thuoc USING btree (don_vi_tinh); 
CREATE INDEX ie_danhmuc_thuoc_don_gia_idx ON ie_danhmuc_thuoc USING btree (don_gia); 
CREATE INDEX ie_danhmuc_thuoc_don_gia_tt_idx ON ie_danhmuc_thuoc USING btree (don_gia_tt); 
CREATE INDEX ie_danhmuc_thuoc_quyet_dinh_idx ON ie_danhmuc_thuoc USING btree (quyet_dinh); 
CREATE INDEX ie_danhmuc_thuoc_cong_bo_idx ON ie_danhmuc_thuoc USING btree (cong_bo); 
CREATE INDEX ie_danhmuc_thuoc_loai_thuoc_idx ON ie_danhmuc_thuoc USING btree (loai_thuoc); 
CREATE INDEX ie_danhmuc_thuoc_loai_thau_idx ON ie_danhmuc_thuoc USING btree (loai_thau); 
CREATE INDEX ie_danhmuc_thuoc_nhom_thau_idx ON ie_danhmuc_thuoc USING btree (nhom_thau); 
CREATE INDEX ie_danhmuc_thuoc_manhom_9324_idx ON ie_danhmuc_thuoc USING btree (manhom_9324); 


--===================================================Table ie_danhmuc_vattu
-- DROP TABLE ie_danhmuc_vattu;

CREATE TABLE ie_danhmuc_vattu
(
	danhmucvattuid serial NOT NULL,
	stt integer,
	ma_nhom_vtyt text,
	ma_nhom_ax text,
	ten_nhom_vtyt text,
	ten_nhom_ax text,
	ma_hieu text,
	ma_vtyt_bv text,
	ten_vtyt_bv text,
	quy_cach text,
	nuoc_sx text,
	hang_sx text,
	don_vi_tinh text,
	don_gia double precision,
	don_gia_tt double precision,
	nha_thau text,
	quyet_dinh text,
	cong_bo integer,
	dinh_muc text,
	so_luong double precision,
	ma_cskcb integer,
	loai_thau integer,
	manhom_9324 integer,
	hieuluc_id integer,
	hieuluc text,
	ketqua_id integer,
	ketqua text,
	lydotuchoi text,
	is_look integer default 0,
	version timestamp without time zone,
  CONSTRAINT ie_danhmuc_vattu_pkey PRIMARY KEY (danhmucvattuid)
);
CREATE INDEX ie_danhmuc_vattu_ma_nhom_vtyt_idx ON ie_danhmuc_vattu USING btree (ma_nhom_vtyt); 
CREATE INDEX ie_danhmuc_vattu_ma_nhom_ax_idx ON ie_danhmuc_vattu USING btree (ma_nhom_ax); 
CREATE INDEX ie_danhmuc_vattu_ten_nhom_vtyt_idx ON ie_danhmuc_vattu USING btree (ten_nhom_vtyt); 
CREATE INDEX ie_danhmuc_vattu_ten_nhom_ax_idx ON ie_danhmuc_vattu USING btree (ten_nhom_ax); 
CREATE INDEX ie_danhmuc_vattu_ma_vtyt_bv_idx ON ie_danhmuc_vattu USING btree (ma_vtyt_bv); 
CREATE INDEX ie_danhmuc_vattu_ten_vtyt_bv_idx ON ie_danhmuc_vattu USING btree (ten_vtyt_bv); 
CREATE INDEX ie_danhmuc_vattu_don_vi_tinh_idx ON ie_danhmuc_vattu USING btree (don_vi_tinh); 
CREATE INDEX ie_danhmuc_vattu_don_gia_idx ON ie_danhmuc_vattu USING btree (don_gia); 
CREATE INDEX ie_danhmuc_vattu_don_gia_tt_idx ON ie_danhmuc_vattu USING btree (don_gia_tt); 
CREATE INDEX ie_danhmuc_vattu_quyet_dinh_idx ON ie_danhmuc_vattu USING btree (quyet_dinh); 
CREATE INDEX ie_danhmuc_vattu_cong_bo_idx ON ie_danhmuc_vattu USING btree (cong_bo); 
CREATE INDEX ie_danhmuc_vattu_dinh_muc_idx ON ie_danhmuc_vattu USING btree (dinh_muc); 
CREATE INDEX ie_danhmuc_vattu_ma_cskcb_idx ON ie_danhmuc_vattu USING btree (ma_cskcb); 
CREATE INDEX ie_danhmuc_vattu_loai_thau_idx ON ie_danhmuc_vattu USING btree (loai_thau); 
CREATE INDEX ie_danhmuc_vattu_manhom_9324_idx ON ie_danhmuc_vattu USING btree (manhom_9324); 

--===================================================
--===================================================
--===================================================








