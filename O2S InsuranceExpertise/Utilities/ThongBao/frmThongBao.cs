﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.Utilities.ThongBao
{
    public partial class frmThongBao : Form
    {
        public frmThongBao()
        {
            InitializeComponent();
        }
        public frmThongBao(string thongbao)
        {
            InitializeComponent();
            lblThongBao.Text = thongbao;
            timerThongBao.Start();
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {
            try
            {
                timerThongBao.Stop();
                this.Visible = false;
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void lblThongBao_Click(object sender, EventArgs e)
        {
            try
            {
                timerThongBao.Stop();
                this.Visible = false;
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
