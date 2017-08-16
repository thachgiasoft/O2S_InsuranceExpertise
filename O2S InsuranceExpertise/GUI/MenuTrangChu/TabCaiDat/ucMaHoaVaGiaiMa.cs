using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.MenuTrangChu
{
    public partial class ucMaHoaVaGiaiMa : UserControl
    {
        public ucMaHoaVaGiaiMa()
        {
            InitializeComponent();
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDauRa.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDauVao.Text, true);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDauRa.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(txtDauVao.Text, true);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(txtDauRa.Text);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
