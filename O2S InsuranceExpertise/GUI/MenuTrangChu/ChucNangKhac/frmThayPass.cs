﻿using System;
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
using O2S_InsuranceExpertise.Base;

namespace O2S_InsuranceExpertise.GUI.MenuTrangChu
{
    public partial class frmThayPass : Form
    {
        O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();

        public frmThayPass()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtPasswordOld.Text == "" || txtPasswordNew1.Text == "" || txtPasswordNew2.Text == "")
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin.", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtPasswordNew1.Text == "") MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtPasswordNew2.Text == "") MessageBox.Show("Bạn chưa nhập lại mật khẩu mới.", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtPasswordNew1.Text != txtPasswordNew2.Text) MessageBox.Show("Mật khẩu mới của bạn không trùng khớp.", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string en_txtUserID = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(SessionLogin.SessionUsercode, true);
                    string en_txtUserPasswordOld = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPasswordOld.Text.Trim(), true);
                    string en_txtUserPasswordNew = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPasswordNew1.Text.Trim(), true);

                    string sqlquerry = "select * from ie_tbluser where usercode='" + en_txtUserID + "' and userpassword='" + en_txtUserPasswordOld + "'";
                    DataView dataBC = new DataView(condb.GetDataTable_HSBA(sqlquerry));

                    if (dataBC.Count > 0 && txtPasswordNew1.Text == txtPasswordNew2.Text)
                    {
                        string sqlupdate_user = "UPDATE ie_tbluser SET userpassword='" + en_txtUserPasswordNew + "' WHERE usercode='" + en_txtUserID + "';";
                       if (condb.ExecuteNonQuery_HSBA(sqlupdate_user))
                        {
                            MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu cũ.", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Common.Logging.LogSystem.Error(ex);
                }

            }
        }


        private void txtPasswordOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPasswordNew1.Focus();
            }
        }

        private void txtPasswordNew1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPasswordNew2.Focus();
            }
        }

        private void txtPasswordNew2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThayDoi.Focus();
            }
        }

        // bắt sự kiện khi check vào nút hiển thị mật khẩu
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditHienThi.Checked == true)
            {
                txtPasswordNew1.Properties.PasswordChar = '\0';
                txtPasswordNew2.Properties.PasswordChar = '\0';
            }
            else
            {
                txtPasswordNew1.Properties.PasswordChar = '*';
                txtPasswordNew2.Properties.PasswordChar = '*';
            }
        }

        private void frmThayPass_Load(object sender, EventArgs e)
        {
            lblTenUserDN.Text = SessionLogin.SessionUsercode;
        }


    }
}
