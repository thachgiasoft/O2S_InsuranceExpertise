using O2S_InsuranceExpertise.GUI.FormCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    public partial class frmCongCuKhac_MoRong : Form
    {
        public frmCongCuKhac_MoRong()
        {
            InitializeComponent();
        }

        private void frmCongCuKhac_MoRong_Load(object sender, EventArgs e)
        {
            try
            {
                panelData.Controls.Clear();
                ucCongCuKhac uchienthi = new ucCongCuKhac();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelData.Controls.Add(uchienthi);
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void frmCongCuKhac_MoRong_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //frmCheckThongTuyenTuDong frmChon = new frmCheckThongTuyenTuDong();
                //frmChon.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            try
            {
                //frmCheckThongTuyenTuDong frmChon = new frmCheckThongTuyenTuDong();
                //frmChon.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
    }
}
