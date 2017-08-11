using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    public partial class ucCheckThongTuyenThuCong : UserControl
    {
        public ucCheckThongTuyenThuCong()
        {
            InitializeComponent();
            // Hiển thị Text Hint
            txtPatientId.ForeColor = SystemColors.GrayText;
            txtPatientId.Text = "Mã bệnh nhân";
            this.txtPatientId.Leave += new System.EventHandler(this.txtPatientId_Leave);
            this.txtPatientId.Enter += new System.EventHandler(this.txtPatientId_Enter);

            txtVienPhiId.ForeColor = SystemColors.GrayText;
            txtVienPhiId.Text = "Mã viện phí";
            this.txtVienPhiId.Leave += new System.EventHandler(this.txtVienPhiId_Leave);
            this.txtVienPhiId.Enter += new System.EventHandler(this.txtVienPhiId_Enter);

            txtBhytCode.ForeColor = SystemColors.GrayText;
            txtBhytCode.Text = "Mã thẻ BHYT";
            this.txtBhytCode.Leave += new System.EventHandler(this.txtBhytCode_Leave);
            this.txtBhytCode.Enter += new System.EventHandler(this.txtBhytCode_Enter);
        }
        #region  Hiển thị Text Hint
        private void txtPatientId_Leave(object sender, EventArgs e)
        {
            if (txtPatientId.Text.Length == 0)
            {
                txtPatientId.Text = "Mã bệnh nhân";
                txtPatientId.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtPatientId_Enter(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "Mã bệnh nhân")
            {
                txtPatientId.Text = "";
                txtPatientId.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtVienPhiId_Leave(object sender, EventArgs e)
        {
            if (txtVienPhiId.Text.Length == 0)
            {
                txtVienPhiId.Text = "Mã viện phí";
                txtVienPhiId.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtVienPhiId_Enter(object sender, EventArgs e)
        {
            if (txtVienPhiId.Text == "Mã viện phí")
            {
                txtVienPhiId.Text = "";
                txtVienPhiId.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtBhytCode_Leave(object sender, EventArgs e)
        {
            if (txtBhytCode.Text.Length == 0)
            {
                txtBhytCode.Text = "Mã thẻ BHYT";
                txtBhytCode.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtBhytCode_Enter(object sender, EventArgs e)
        {
            if (txtBhytCode.Text == "Mã thẻ BHYT")
            {
                txtBhytCode.Text = "";
                txtBhytCode.ForeColor = SystemColors.WindowText;
            }
        }

        #endregion
        #region Load
        private void ucCheckThongTuyenThuCong_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        #endregion

        #region Custom
        private void gridViewDSBN_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        #endregion


        #region Grid Danh sách bệnh nhân
        private void gridViewDSBN_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {

                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    //GridView view = sender as GridView;
                    e.Menu.Items.Clear();
                    DXMenuItem itemKiemTraDaChon = new DXMenuItem("Kiểm tra thông tuyến bệnh nhân đã chọn"); // caption menu
                    itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                    itemKiemTraDaChon.Click += new EventHandler(KiemTraDaChon_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraDaChon);

                    DXMenuItem itemKiemTraTatCa = new DXMenuItem("Kiểm tra thông tuyến tất cả"); // caption menu
                    itemKiemTraTatCa.Image = imageCollectionDSBN.Images[1]; // icon cho menu
                    itemKiemTraTatCa.Click += new EventHandler(KiemTraTatCa_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraTatCa);
                    itemKiemTraTatCa.BeginGroup = true;

                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void KiemTraDaChon_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void KiemTraTatCa_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        #endregion

        #region Grid Kết quả Check Thông tuyến
        private void gridControlKQCheck_Click(object sender, EventArgs e)
        {

        }




        #endregion


        #region Custom
        private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void txtBhytCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBhytCode.Text != "")
                {
                    //txtPatientId.ForeColor = SystemColors.GrayText;
                    //txtPatientId.Text = "Mã bệnh nhân";
                    //this.txtPatientId.Leave += new System.EventHandler(this.txtPatientId_Leave);
                    //this.txtPatientId.Enter += new System.EventHandler(this.txtPatientId_Enter);

                    //txtVienPhiId.ForeColor = SystemColors.GrayText;
                    //txtVienPhiId.Text = "Mã viện phí";
                    //this.txtVienPhiId.Leave += new System.EventHandler(this.txtVienPhiId_Leave);
                    //this.txtVienPhiId.Enter += new System.EventHandler(this.txtVienPhiId_Enter);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void txtPatientId_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientId.Text != "")
                {
                    txtVienPhiId.ForeColor = SystemColors.GrayText;
                    txtVienPhiId.Text = "Mã viện phí";
                    this.txtVienPhiId.Leave += new System.EventHandler(this.txtVienPhiId_Leave);
                    this.txtVienPhiId.Enter += new System.EventHandler(this.txtVienPhiId_Enter);

                    //txtBhytCode.ForeColor = SystemColors.GrayText;
                    //txtBhytCode.Text = "Mã thẻ BHYT";
                    //this.txtBhytCode.Leave += new System.EventHandler(this.txtBhytCode_Leave);
                    //this.txtBhytCode.Enter += new System.EventHandler(this.txtBhytCode_Enter);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void txtVienPhiId_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVienPhiId.Text != "")
                {
                    txtPatientId.ForeColor = SystemColors.GrayText;
                    txtPatientId.Text = "Mã bệnh nhân";
                    this.txtPatientId.Leave += new System.EventHandler(this.txtPatientId_Leave);
                    this.txtPatientId.Enter += new System.EventHandler(this.txtPatientId_Enter);

                    //txtBhytCode.ForeColor = SystemColors.GrayText;
                    //txtBhytCode.Text = "Mã thẻ BHYT";
                    //this.txtBhytCode.Leave += new System.EventHandler(this.txtBhytCode_Leave);
                    //this.txtBhytCode.Enter += new System.EventHandler(this.txtBhytCode_Enter);
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        #endregion


    }
}
