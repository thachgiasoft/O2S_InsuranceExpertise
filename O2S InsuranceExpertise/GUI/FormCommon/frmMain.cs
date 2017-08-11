﻿using O2S_InsuranceExpertise.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class frmMain : Form
    {
        O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();
        internal string lblHienThiThongTinChucNang { get; set; }
        DialogResult hoi;

        public frmMain()
        {
            InitializeComponent();
        }

        #region Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                timerClock.Start();
                timerKiemTraLicense.Interval = O2S_InsuranceExpertise.Base.KeyTrongPhanMem.ThoiGianKiemTraLicense;
                timerKiemTraLicense.Start();

                LoadPageMenu();
                KiemTraLicense_EnableButton(); //kiem tra license truoc khi kiem tra phan quyen
                KiemTraPhanQuyenNguoiDung();
                LoadThongTinVePhanMem_Version();
                LoadGiaoDien();

                TimerChayChuongTrinhServiceAn(); // Chay du lieu ngam   - TAM THOI KHONG SU DUNG
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void LoadPageMenu()
        {
            try
            {
                tabMenuTrangChu.Controls.Clear();
                O2S_InsuranceExpertise.GUI.FormCommon.ucTrangChu ucTrangChu = new FormCommon.ucTrangChu();
                ucTrangChu.MyGetData = new FormCommon.ucTrangChu.GetString(HienThiTenChucNang);
                ucTrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuTrangChu.Controls.Add(ucTrangChu);

                //tabMenuCauHinh.Controls.Clear();
                //FormCommon.ucCauHinh ucCauHinh = new ucCauHinh();
                //ucCauHinh.MyGetData = new ucCauHinh.GetString(HienThiTenChucNang);
                //ucCauHinh.Dock = System.Windows.Forms.DockStyle.Fill;
                //tabMenuCauHinh.Controls.Add(ucCauHinh);

                tabMenuCauHinh.Controls.Clear();
                FormCommon.ucCongCuKhac ucCongCuKhac = new ucCongCuKhac();
                ucCongCuKhac.MyGetData = new ucCongCuKhac.GetString(HienThiTenChucNang);
                ucCongCuKhac.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuCauHinh.Controls.Add(ucCongCuKhac);

            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void LoadThongTinVePhanMem_Version()
        {
            try
            {
                string serverhost = EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString(), true);
                string serverdb = EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString(), true);
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                this.Text = "Phần mềm giám định Bảo hiểm y tế (v" + version + ")";
                StatusUsername.Caption = SessionLogin.SessionUsername;
                StatusDBName.Caption = serverhost + " [ " + serverdb + " ]";
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        #endregion

        #region Giao dien
        private void LoadGiaoDien()
        {
            try
            {
                foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem();
                    item.Caption = skin.SkinName;
                    item.Name = "button" + skin.SkinName;
                    item.ItemClick += item_ItemClick;
                    // barSubItemSkin.AddItem(item);
                }
                if (ConfigurationManager.AppSettings["skin"].ToString() != "")
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["skin"].ToString());
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        private void item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.BarItem item = e.Item;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(item.Caption);
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.AppSettings.Settings["skin"].Value = item.Caption;
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        #endregion

        private void KiemTraLicense_EnableButton()
        {
            try
            {
                //Kiểm tra phân quyền
                if (SessionLogin.SessionUsercode == O2S_InsuranceExpertise.Base.KeyTrongPhanMem.AdminUser_key)
                {
                    EnableAndDisableChucNang(true); //admin              
                }
                else
                {
                    if (SessionLogin.KiemTraLicenseSuDung)
                    {
                        EnableAndDisableChucNang(true);
                    }
                    else
                    {
                        EnableAndDisableChucNang(false);
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }


        // sự kiện hỏi khi ấn nút X để đóng chương trình
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (hoi != DialogResult.Retry)
                {
                    hoi = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (hoi == DialogResult.No)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        // Thoát chương trình 
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Hiển thị thời gian ngày tháng
        private void timerClock_Tick(object sender, EventArgs e)
        {
            StatusClock.Caption = DateTime.Now.ToString("dddd, HH:mm:ss dd/MM/yyyy");
        }

        private void timerKiemTraLicense_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SessionLogin.SessionUsercode != O2S_InsuranceExpertise.Base.KeyTrongPhanMem.AdminUser_key)
                {
                    KiemTraLicense.KiemTraLicenseHopLe();
                    if (SessionLogin.KiemTraLicenseSuDung == false)
                    {
                        timerKiemTraLicense.Stop();
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Visible = false;
                            this.Dispose();
                            frmLogin frm = new frmLogin();
                            frm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        private void tabPaneMenu_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            try
            {
                if (tabPaneMenu.SelectedPage == tabMenuRestart)
                {
                    hoi = DialogResult.Retry;
                    Application.Restart();
                    Application.ExitThread();
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
                throw;
            }
        }

        //delegate
        internal void HienThiTenChucNang(string _message)
        {
            try
            {
                lblHienThiThongTinChucNang = _message;
                lblStatusTenBC.Caption = lblHienThiThongTinChucNang;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }






    }
}
