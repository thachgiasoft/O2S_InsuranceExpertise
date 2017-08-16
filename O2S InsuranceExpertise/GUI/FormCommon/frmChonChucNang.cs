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
        bool checkChonChucNang = false;
        public frmChonChucNang()
        {
            InitializeComponent();
            timerChonChucNang.Start();
        }

        private void btnKiemTraThongTuyen_Click(object sender, EventArgs e)
        {
            try
            {
                checkChonChucNang = true;
                GUI.MenuCongCuKhac.frmCheckThongTuyenTuDong frmMenu = new MenuCongCuKhac.frmCheckThongTuyenTuDong();
                frmMenu.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnGiamDinhBHYT_Click(object sender, EventArgs e)
        {
            try
            {
                checkChonChucNang = true;
                frmMain frmm = new frmMain();
                frmm.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void timerChonChucNang_Tick(object sender, EventArgs e)
        {
            try
            {
                timerChonChucNang.Stop();
                if (checkChonChucNang == false)
                {
                    frmMain frmm = new frmMain();
                    frmm.Show();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
