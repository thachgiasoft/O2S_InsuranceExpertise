using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class frmChonChucNang : Form
    {
        public frmChonChucNang()
        {
            InitializeComponent();
            timerChonChucNang.Start();
        }

        private void btnKiemTraThongTuyen_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.CheckThongTuyen.frmCheckThongTuyenTuDong frmMenu = new CheckThongTuyen.frmCheckThongTuyenTuDong();
                frmMenu.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
            }
        }

        private void btnGiamDinhBHYT_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain frmm = new frmMain();
                frmm.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
            }
        }

        private void timerChonChucNang_Tick(object sender, EventArgs e)
        {
            try
            {
                timerChonChucNang.Stop();
                frmMain frmm = new frmMain();
                frmm.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
            }
        }
    }
}
