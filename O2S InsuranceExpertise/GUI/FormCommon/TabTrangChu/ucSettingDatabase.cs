﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.FormCommon.TabTrangChu
{
    public partial class ucSettingDatabase : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private string userGDBHYTCurrent = "";
        public ucSettingDatabase()
        {
            InitializeComponent();
        }

        #region Load
        private void ucSettingDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKetNoiDatabase();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadKetNoiDatabase()
        {
            try
            {
                // Giải mã giá trị lưu trong config
                this.txtDBHost.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim(), true);
                this.txtDBPort.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerPort"].ToString().Trim(), true);
                this.txtDBUser.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                this.txtDBPass.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                this.txtDBName.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
                this.txtDBHost_HSBA.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost_HSBA"].ToString().Trim(), true);
                this.txtDBPort_HSBA.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerPort_HSBA"].ToString().Trim(), true);
                this.txtDBUser_HSBA.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username_HSBA"].ToString().Trim(), true);
                this.txtDBPass_HSBA.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password_HSBA"].ToString().Trim(), true);
                this.txtDBName_HSBA.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database_HSBA"].ToString().Trim(), true);

                LoadCauHinhTaiKhoanDangNhapTrenCongBHYT();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadCauHinhTaiKhoanDangNhapTrenCongBHYT()
        {
            try
            {
                string sql_getThongTin = "select usergdbhyt,passgdbhyt,urlfullserver from ie_config where configtype=1;";
                DataTable dataTaiKhoan = condb.GetDataTable_HSBA(sql_getThongTin);
                if (dataTaiKhoan != null && dataTaiKhoan.Rows.Count > 0)
                {
                    txtUserGDBHYT.Text = dataTaiKhoan.Rows[0]["usergdbhyt"].ToString();
                    txtPassGDBHYT.Text = dataTaiKhoan.Rows[0]["passgdbhyt"].ToString();
                    this.userGDBHYTCurrent = txtUserGDBHYT.Text;
                    txtUrlFullServer.Text = dataTaiKhoan.Rows[0]["urlfullserver"].ToString();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion
        private void btnDBKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                //May chu HIS
                bool boolfound = false;
                string connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                    txtDBHost.Text, txtDBPort.Text, txtDBUser.Text, txtDBPass.Text, txtDBName.Text);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT * FROM tbuser";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu HIS thành công!", "Thông báo");
                }
                if (boolfound == false)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu HIS!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
                conn.Close();
                //May chu HSBA
                bool boolfound_HSBA = false;
                string connstring_HSBA = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                    txtDBHost_HSBA.Text, txtDBPort_HSBA.Text, txtDBUser_HSBA.Text, txtDBPass_HSBA.Text, txtDBName_HSBA.Text);
                NpgsqlConnection conn_HSBA = new NpgsqlConnection(connstring_HSBA);
                conn_HSBA.Open();
                string sql_HSBA = "SELECT * FROM ie_license";
                NpgsqlCommand command_HSBA = new NpgsqlCommand(sql_HSBA, conn_HSBA);
                NpgsqlDataReader dr_HSBA = command_HSBA.ExecuteReader();
                if (dr_HSBA.Read())
                {
                    boolfound_HSBA = true;
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu Hồ sơ bệnh án thành công!", "Thông báo");
                }
                if (boolfound_HSBA == false)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu Giám định BHYT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr_HSBA.Close();
                conn_HSBA.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnDBLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.AppSettings.Settings["ServerHost"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBHost.Text.Trim(), true);
                _config.AppSettings.Settings["ServerPort"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBPort.Text.Trim(), true);
                _config.AppSettings.Settings["Username"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBUser.Text.Trim(), true);
                _config.AppSettings.Settings["Password"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBPass.Text.Trim(), true);
                _config.AppSettings.Settings["Database"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBName.Text.Trim(), true);
                _config.AppSettings.Settings["ServerHost_HSBA"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBHost_HSBA.Text.Trim(), true);
                _config.AppSettings.Settings["ServerPort_HSBA"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBPort_HSBA.Text.Trim(), true);
                _config.AppSettings.Settings["Username_HSBA"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBUser_HSBA.Text.Trim(), true);
                _config.AppSettings.Settings["Password_HSBA"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBPass_HSBA.Text.Trim(), true);
                _config.AppSettings.Settings["Database_HSBA"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBName_HSBA.Text.Trim(), true);
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                LuuLaiTaiKhoanTrenCongGDBHYT();


                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LuuLaiTaiKhoanTrenCongGDBHYT()
        {
            try
            {
                string sql_tkgdbhyt = "";
                if (this.userGDBHYTCurrent == "")
                {
                    sql_tkgdbhyt = "INSERT INTO ie_config(usergdbhyt, passgdbhyt, urlfullserver, configtype) VALUES ('" + txtUserGDBHYT.Text.Trim() + "', '" + txtPassGDBHYT.Text + "', '" + txtUrlFullServer.Text + "', '1');";
                }
                else
                {
                    sql_tkgdbhyt = "UPDATE ie_config SET usergdbhyt='" + txtUserGDBHYT.Text.Trim() + "', passgdbhyt='" + txtPassGDBHYT.Text + "', urlfullserver='" + txtUrlFullServer.Text + "' where configtype=1; ";
                }
                condb.ExecuteNonQuery_HSBA(sql_tkgdbhyt);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnDBUpdate_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(O2S_InsuranceExpertise.Utilities.ThongBao.WaitForm1));
            try
            {
                if (O2S_InsuranceExpertise.DAL.KetNoiSCDLProcess.CapNhatCoSoDuLieu())
                {
                    MessageBox.Show("Cập nhật cơ sở dữ liệu thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật cơ sở dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Lỗi cập nhật cơ sở dữ liệu!" + ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }


    }
}
