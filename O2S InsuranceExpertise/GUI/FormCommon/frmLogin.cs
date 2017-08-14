using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;
using System.Net;
using System.Diagnostics;
using O2S_InsuranceExpertise.Base;
using System.IO;
using O2S_InsuranceExpertise.DTO;
using O2S_InsuranceExpertise.Utilities;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class frmLogin : Form
    {
        O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();
        NpgsqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraKetNoiDenCoSoDuLieu() == false)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                KiemTraInsertMayTram();
                LoadDataFromDatabase();
                LoadDefaultValue();
                KiemTraVaCopyFileLaucherNew();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private bool KiemTraKetNoiDenCoSoDuLieu()
        {
            bool result = false;
            try
            {
                string serverhost = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
                string serveruser = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                string serverpass = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                string serverdb = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
                string serverhost_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost_HSBA"].ToString().Trim() ?? "", true);
                string serveruser_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username_HSBA"].ToString().Trim(), true);
                string serverpass_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password_HSBA"].ToString().Trim(), true);
                string serverdb_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database_HSBA"].ToString().Trim(), true);

                if (conn == null)
                {
                    conn = new NpgsqlConnection("Server=" + serverhost + ";Port=5432;User Id=" + serveruser + "; " + "Password=" + serverpass + ";Database=" + serverdb + ";CommandTimeout=1800000;");
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                conn.Close();
                result = true;
                //todo them ket noi den CSDL HSBA
                if (conn == null)
                {
                    conn = new NpgsqlConnection("Server=" + serverhost_HSBA + ";Port=5432;User Id=" + serveruser_HSBA + "; " + "Password=" + serverpass_HSBA + ";Database=" + serverdb_HSBA + ";CommandTimeout=1800000;");
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                conn.Close();
                result = true;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        private void KiemTraInsertMayTram()
        {
            try
            {
                SessionLogin.MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                string license_trang = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt("", true);
                string kiemtra_client = "SELECT * FROM ie_license WHERE datakey='" + SessionLogin.MaDatabase + "' ;";
                DataView dv = new DataView(condb.GetDataTable_HSBA(kiemtra_client));
                if (dv != null && dv.Count > 0)
                {
                    //Kiem tra license
                    //O2S_InsuranceExpertise.GUI.FormCommon.DangKyBanQuyen.kiemTraLicenseHopLe.KiemTraLicenseHopLe();
                }
                else
                {
                    string insert_client = "INSERT INTO ie_license(datakey, licensekey) VALUES ('" + SessionLogin.MaDatabase + "','" + license_trang + "' );";
                    condb.GetDataTable_HSBA(insert_client);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDataFromDatabase()
        {
            try
            {
                 BUS.LoadDataSystems.LoadTaiKhoanCongBHYT();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDefaultValue()
        {
            try
            {
                if (ConfigurationManager.AppSettings["LoginUser"].ToString() != "" && ConfigurationManager.AppSettings["LoginPassword"].ToString() != "")
                {
                    this.txtUsername.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginUser"].ToString(), true);
                    this.txtPassword.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginPassword"].ToString(), true);
                    this.checkEditNhoPass.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["checkEditNhoPass"]);
                }
                else
                {
                    this.txtUsername.Text = "";
                    this.txtPassword.Text = "";
                }
                txtUsername.Focus();

                SessionLogin.SessionMachineName = Environment.MachineName;
                // Địa chỉ Ip
                String strHostName = Dns.GetHostName();
                IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
                //int nIP = 0;
                string listIP = "";
                for (int i = 0; i < iphostentry.AddressList.Count(); i++)
                {
                    listIP += iphostentry.AddressList[i] + ";";
                }
                SessionLogin.SessionMyIP = listIP;
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                SessionLogin.SessionVersion = fvi.FileVersion;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #region Kiem tra va copy Lanucher
        private void KiemTraVaCopyFileLaucherNew()
        {
            try
            {
                DataView dataurlfile = new DataView(condb.GetDataTable_HSBA("select app_link from ie_version where app_type=0 limit 1;"));
                if (dataurlfile != null && dataurlfile.Count > 0)
                {
                    string tempDirectory = dataurlfile[0]["app_link"].ToString();
                    CopyFolder_CheckSum(tempDirectory, Environment.CurrentDirectory);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private static void CopyFolder_CheckSum(string SourceFolder, string DestFolder)
        {
            Directory.CreateDirectory(DestFolder); //Tao folder moi
            string[] files = Directory.GetFiles(SourceFolder);
            //Neu co file thi phai copy file
            foreach (string file in files)
            {
                try
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(DestFolder, name);
                    if (name.Contains("O2S InsuranceExpertiseLauncher"))
                    {
                        //Check file
                        if (Common.Checksum.GetFileCheckSum.GetMD5HashFromFile(file) != Common.Checksum.GetFileCheckSum.GetMD5HashFromFile(dest))
                        {
                            File.Copy(file, dest, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                    Common.Logging.LogSystem.Error("Lỗi copy file check_sum" + ex.ToString());
                }
            }

            string[] folders = Directory.GetDirectories(SourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(DestFolder, name);
                CopyFolder_CheckSum(folder, dest);
            }
        }
        #endregion

        #endregion
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return;
                }
                // tạo 1 tài khoản ở trên PM, không chứa trong DB để làm tài khoản admin
                else if (txtUsername.Text.ToLower() == Base.KeyTrongPhanMem.AdminUser_key && txtPassword.Text == Base.KeyTrongPhanMem.AdminPass_key)
                {
                    SessionLogin.SessionUserID = -1;
                    SessionLogin.SessionUsercode = txtUsername.Text.Trim().ToLower();
                    SessionLogin.SessionUsername = "Administrator";

                    LoadDuLieuSauKhiDangNhap();
                }
                else
                {
                    string en_txtUsername = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUsername.Text.Trim().ToLower(), true);
                    string en_txtPassword = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPassword.Text.Trim(), true);
                    try
                    {
                        string command = "SELECT userid, usercode, username, userpassword FROM ie_tbluser WHERE usercode='" + en_txtUsername + "' and userpassword='" + en_txtPassword + "';";
                        DataView dv = new DataView(condb.GetDataTable_HSBA(command));
                        if (dv != null && dv.Count > 0)
                        {
                            Base.KiemTraLicense.KiemTraLicenseHopLe();
                            SessionLogin.SessionUserID = Common.TypeConvert.TypeConvertParse.ToInt64(dv[0]["userid"].ToString());
                            SessionLogin.SessionUsercode = txtUsername.Text.Trim().ToLower();
                            SessionLogin.SessionUsername = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[0]["username"].ToString(), true);

                            LoadDuLieuSauKhiDangNhap();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error(ex);
                        txtUsername.Focus();
                    }
                }

                // Khi được check vào nút ghi nhớ thì sẽ lưu tên đăng nhập và mật khẩu vào file config
                if (checkEditNhoPass.Checked)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["checkEditNhoPass"].Value = Convert.ToString(checkEditNhoPass.Checked);
                    _config.AppSettings.Settings["LoginUser"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUsername.Text.Trim(), true);
                    _config.AppSettings.Settings["LoginPassword"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPassword.Text.Trim(), true);
                    _config.Save(ConfigurationSaveMode.Modified);

                    ConfigurationManager.RefreshSection("appSettings");
                }
                // không thì sẽ xóa giá trị đã lưu trong file congfig đi
                else
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["checkEditNhoPass"].Value = "false";
                    _config.AppSettings.Settings["LoginUser"].Value = "";
                    _config.AppSettings.Settings["LoginPassword"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn("Dang nhap " + ex.ToString());
            }
        }

        private void LoadDuLieuSauKhiDangNhap()
        {
            try
            {
                SessionLogin.SessionLstPhanQuyenNguoiDung = O2S_InsuranceExpertise.Base.CheckPermission.GetListPhanQuyenNguoiDung();
                SessionLogin.SessionlstPhanQuyen_KhoaPhong = O2S_InsuranceExpertise.Base.CheckPermission.GetPhanQuyen_KhoaPhong();
                //SessionLogin.SessionLstPhanQuyen_KhoThuoc = O2S_InsuranceExpertise.Base.CheckPermission.GetPhanQuyen_KhoThuoc();
                //SessionLogin.SessionLstPhanQuyen_PhongLuu = O2S_InsuranceExpertise.Base.CheckPermission.GetPhanQuyen_PhongLuu();

                //Kiem tra phan quyen gom nhung quyen nao ? 

                bool check_ThongTuyen = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_10");
                bool check_Menu = false;
                List<DTO.classPermission> SessionLstPhanQuyen_ChucNangKhac = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.permissioncode!="TOOL_10").ToList();
                if (SessionLstPhanQuyen_ChucNangKhac != null && SessionLstPhanQuyen_ChucNangKhac.Count > 0)
                {
                    check_Menu = true;
                }

                if (check_ThongTuyen == true && check_Menu == false)
                {
                    GUI.CheckThongTuyen.frmCheckThongTuyenTuDong frmChon = new CheckThongTuyen.frmCheckThongTuyenTuDong();
                    frmChon.Show();
                    this.Visible = false;
                }
                else if (check_ThongTuyen == true && check_Menu == true)
                {
                    frmChonChucNang frmmenu = new frmChonChucNang();
                    frmmenu.Show();
                    this.Visible = false;
                }
                else
                {
                    frmMain frmChon = new frmMain();
                    frmChon.Show();
                    this.Visible = false;
                }
                Common.Logging.LogSystem.Info("Application open successfull. Time=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #region Custom
        // Khi nhập username và nhấn enter thì forcus vào ô nhập pass
        private void txtUsername_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPassword.Text != "")
                {
                    btnLogin.PerformClick();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
        }

        // Sau khi nhập password và ấn enter thì đăng nhập luôn
        private void txtPassword_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        // nếu viết vào ô username = "config" thì mở ra bảng để cấu hình DB
        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.ToUpper() == "CONFIG")
            {
                frmConnectDB frmcon = new frmConnectDB();
                frmcon.Dock = System.Windows.Forms.DockStyle.Bottom;
                frmcon.ShowDialog();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
                this.Dispose();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void linkTroGiup_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Liên hệ với tác giả để được trợ giúp! \nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông tin về tác giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

    }
}
