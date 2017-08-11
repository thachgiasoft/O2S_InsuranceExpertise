---Bảng trong dự án: O2S_InsuranceExpertise

--=================================================== table IE_license
CREATE TABLE IE_license
(
  licenseid serial NOT NULL,
  datakey text,
  licensekey text,
  CONSTRAINT IE_license_pkey PRIMARY KEY (licenseid)
)
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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_tbluser
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_tbluser_departmentgroup
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_tbluser_permission
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_tbllog
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_otherlist
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_othertypelist
  OWNER TO postgres;

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
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IE_option
  OWNER TO postgres;

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
-- DROP TABLE IE_option;
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
  departmentgroupid integer,
  departmentid integer,
  hosobenhandate timestamp without time zone,
  hosobenhandate_ravien timestamp without time zone,
  lastupdatedate_hsba timestamp without time zone,
  lastupdatedate_bhyt timestamp without time zone,
  bhytchecknote text,
  CONSTRAINT bhytcheckid_pkey PRIMARY KEY (bhytcheckid)
)
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
--===================================================
--===================================================
--===================================================
--===================================================
--===================================================
--===================================================
--===================================================









