using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.DAL
{
    internal static class KetNoiSCDLProcess
    {
        private static O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();

        internal static bool CapNhatCoSoDuLieu()
        {
            bool result = true;
            try
            {
                result = KetNoiSCDLProcess.CreateTableTblUser();
                result = KetNoiSCDLProcess.CreateTableTblLog();
                result = KetNoiSCDLProcess.CreateTableLicense();
                result = KetNoiSCDLProcess.CreateTableOption();
                //result = KetNoiSCDLProcess.CreateTableTblNhanVien();
                result = KetNoiSCDLProcess.CreateTableTblPermission();
                result = KetNoiSCDLProcess.CreateTableUserMedicineStore();
                result = KetNoiSCDLProcess.CreateTableUserMedicinePhongLuu();

                result = KetNoiSCDLProcess.CreateTableUserDepartmentgroup();
                result = KetNoiSCDLProcess.CreateTableVersion();
                result = KetNoiSCDLProcess.CreateTableConfig();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi Update DB" + ex.ToString());
            }
            return result;
        }

        #region Tao bang
        private static bool CreateTableTblUser()
        {
            bool result = false;
            try
            {
                string sql_tbllog = "CREATE TABLE IF NOT EXISTS IE_tbluser ( userid serial NOT NULL, usercode text NOT NULL, username text, userpassword text, userstatus integer, usergnhom integer, usernote text, userhisid integer, CONSTRAINT IE_tbluser_pkey PRIMARY KEY (userid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tbllog))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableTblUser" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableTblLog()
        {
            bool result = false;
            try
            {
                string sql_tbllog = "CREATE TABLE IF NOT EXISTS IE_tbllog ( logid serial NOT NULL, loguser text, logvalue text, ipaddress text, computername text, softversion text, logtime timestamp without time zone, CONSTRAINT IE_tbllog_pkey PRIMARY KEY (logid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tbllog))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableTblLog" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableOption()
        {
            bool result = false;
            try
            {
                string sqloption = "CREATE TABLE IF NOT EXISTS IE_option ( optionid serial NOT NULL, optioncode text, optionname text, optionvalue text, optionnote text, optionlook integer, optiondate timestamp without time zone, optioncreateuser text, CONSTRAINT IE_option_pkey PRIMARY KEY (optionid) );";
                if (condb.ExecuteNonQuery_HSBA(sqloption))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableOption" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableUserDepartmentgroup()
        {
            bool result = false;
            try
            {
                string sqloption = "CREATE TABLE IF NOT EXISTS ie_tbluser_departmentgroup(userdepgid serial NOT NULL, departmentgroupid integer, departmentid integer, departmenttype integer, usercode text,  userdepgidnote text, CONSTRAINT tbluser_departmentgroup_pkey PRIMARY KEY (userdepgid));";
                if (condb.ExecuteNonQuery_HSBA(sqloption))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableUserDepartmentgroup" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableVersion()
        {
            bool result = false;
            try
            {
                string sqloption = "CREATE TABLE IF NOT EXISTS ie_version ( versionid serial NOT NULL, appversion text, app_link text, app_type integer, updateapp bytea, appsize integer, sqlversion text, updatesql bytea, sqlsize integer, sync_flag integer, update_flag integer, CONSTRAINT ie_version_pkey PRIMARY KEY (versionid) );";
                if (condb.ExecuteNonQuery_HSBA(sqloption))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableSersion" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableLicense()
        {
            bool result = false;
            try
            {
                string sql_tbl_license = "CREATE TABLE IF NOT EXISTS IE_license ( licenseid serial NOT NULL, datakey text, licensekey text, CONSTRAINT IE_license_pkey PRIMARY KEY (licenseid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tbl_license))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableLicense" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableTblNhanVien()
        {
            bool result = false;
            try
            {
                string sql_tbluser = "CREATE TABLE IF NOT EXISTS nhompersonnel ( nhanvienid serial NOT NULL, usercode text NOT NULL, username text, userpassword text, userstatus integer, usergnhom integer, usernote text, userhisid integer, CONSTRAINT nhompersonnel_pkey PRIMARY KEY (nhanvienid));";
                if (condb.ExecuteNonQuery_HIS(sql_tbluser))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableTblNhanVien" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableTblPermission()
        {
            bool result = false;
            try
            {
                string sql_tblper = "CREATE TABLE IF NOT EXISTS IE_tbluser_permission ( userpermissionid serial NOT NULL, permissionid integer, permissioncode text, permissionname text, userid integer, usercode text, permissioncheck boolean, userpermissionnote text, CONSTRAINT userpermissionid_pkey PRIMARY KEY (userpermissionid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tblper))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableTblPermission" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableUserMedicineStore()
        {
            bool result = false;
            try
            {
                string sql_tbluser = "CREATE TABLE IF NOT EXISTS ie_tbluser_medicinestore( usermestid serial NOT NULL, medicinestoreid integer, medicinestoretype integer, usercode text, userdepgidnote text, CONSTRAINT ie_tbluser_medicinestore_pkey PRIMARY KEY (usermestid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tbluser))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableUserMedicineStore" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableUserMedicinePhongLuu()
        {
            bool result = false;
            try
            {
                string sql_tbluser = "CREATE TABLE IF NOT EXISTS ie_tbluser_medicinephongluu( userphongluutid serial NOT NULL, medicinephongluuid integer, medicinestoreid integer, usercode text, userdepgidnote text, CONSTRAINT ie_tbluser_medicinephongluu_pkey PRIMARY KEY (userphongluutid) );";
                if (condb.ExecuteNonQuery_HSBA(sql_tbluser))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableUserMedicinePhongLuu" + ex.ToString());
            }
            return result;
        }
        private static bool CreateTableConfig()
        {
            bool result = false;
            try
            {
                string sqloption = "CREATE TABLE IF NOT EXISTS ie_config ( configid serial NOT NULL, usergdbhyt text, passgdbhyt text, urlfullserver text, configtype integer, CONSTRAINT ie_config_pkey PRIMARY KEY (configid) );";
                if (condb.ExecuteNonQuery_HSBA(sqloption))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateTableConfig" + ex.ToString());
            }
            return result;
        }

        #endregion

        #region Tao Function
        private static bool CreateFunctionByteaImport()
        {
            bool result = false;
            try
            {
                string sqloption = " create or replace function bytea_import(p_path text, p_result out bytea) language plpgsql as $$ declare l_oid oid; r record; begin p_result := ''; select lo_import(p_path) into l_oid; for r in ( select data from pg_largeobject where loid = l_oid order by pageno ) loop p_result = p_result || r.data; end loop; perform lo_unlink(l_oid); end;$$;";
                if (condb.ExecuteNonQuery_HSBA(sqloption))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Lỗi CreateFunctionByteaimport" + ex.ToString());
            }
            return result;
        }

        #endregion

        #region Custom



        #endregion
    }
}
