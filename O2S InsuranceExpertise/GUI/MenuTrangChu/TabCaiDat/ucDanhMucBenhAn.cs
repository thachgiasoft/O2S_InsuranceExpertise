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
using O2S_InsuranceExpertise.DTO;
using O2S_InsuranceExpertise.Base;

namespace O2S_InsuranceExpertise.GUI.MenuTrangChu
{
    public partial class ucDanhMucBenhAn : UserControl
    {
        O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();
        private long ie_hsbatemid = 0;
        private string ie_hsbatemnamepath = "";

        #region Load
        public ucDanhMucBenhAn()
        {
            InitializeComponent();
        }
        private void ucDanhMucBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(false);
                LoadDanhSachBenhAn();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void EnableAndDisableControl(bool result)
        {
            try
            {
                txtHSBATempCode.ReadOnly = true;
                txtHSBATempName.ReadOnly = !result;
                txtHSBATempNamePath.ReadOnly = !result;
                btnTimFileTemplate.Enabled = result;
                btnSua.Enabled = result;
                btnLuu.Enabled = result;
                btnHuy.Enabled = result;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachBenhAn()
        {
            try
            {
                string sqldsbenhan = "select ROW_NUMBER() OVER (ORDER BY ie_hsbatemname) as stt, ie_hsbatemid, ie_hsbatemcode, ie_hsbatemname, ie_hsbatemtypeid, ie_hsbatemnamepath from ie_hsba_template;";
                DataView dataOption = new DataView(condb.GetDataTable_HSBA(sqldsbenhan));
                if (dataOption != null && dataOption.Count > 0)
                {
                    gridControlDSBenhAn.DataSource = dataOption;
                }
                else
                {
                    gridControlDSBenhAn.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        private void gridViewDSOption_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void btnTimFileTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    txtHSBATempNamePath.Text = openFileDialogSelect.FileName;
                    this.ie_hsbatemnamepath = openFileDialogSelect.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtHSBATempCode.ReadOnly = false;
                txtHSBATempName.ReadOnly = false;
                txtHSBATempNamePath.ReadOnly = false;
                btnTimFileTemplate.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                txtHSBATempCode.ReadOnly = true;
                txtHSBATempName.ReadOnly = false;
                txtHSBATempNamePath.ReadOnly = false;
                EnableAndDisableControl(true);
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                gridControlDSBenhAn.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ie_hsbatemid != 0) //sua
                {
                    //Update servicepriceref
                    string updateservicepriceref = "update ie_hsba_template set ie_hsbatemname='" + txtHSBATempName.Text.Trim() + "', ie_hsbatemnamepath='" + this.ie_hsbatemnamepath + "' where ie_hsbatemid=" + this.ie_hsbatemid + ";";
                    if (condb.ExecuteNonQuery_HSBA(updateservicepriceref))
                    {
                        O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                    gridControlDSBenhAn.Enabled = true;
                }
                else //them moi
                {
                    if (txtHSBATempCode.Text != "" && this.ie_hsbatemnamepath !="")
                    {
                        string insertbenhan = "INSERT INTO ie_hsba_template(ie_hsbatemcode, ie_hsbatemname, ie_hsbatemtypeid, ie_hsbatemnamepath) VALUES ('" + txtHSBATempCode.Text.Trim() + "', '" + txtHSBATempName.Text.Trim() + "', '0', '" + this.ie_hsbatemnamepath + "'); ";
                        if (condb.ExecuteNonQuery_HSBA(insertbenhan))
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                            frmthongbao.Show();
                        }
                    }
                    else
                    {
                        O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                        frmthongbao.Show();
                    }
                }
                LoadDanhSachBenhAn();
                txtHSBATempCode.Text = "";
                txtHSBATempName.Text = "";
                txtHSBATempNamePath.Text = "";
                txtHSBATempCode.ReadOnly = true;
                txtHSBATempName.ReadOnly = true;
                txtHSBATempNamePath.ReadOnly = true;
                btnTimFileTemplate.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                gridControlDSBenhAn.Enabled = true;
                this.ie_hsbatemid = 0;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                txtHSBATempCode.Text = "";
                txtHSBATempName.Text = "";
                txtHSBATempNamePath.Text = "";
                txtHSBATempCode.ReadOnly = true;
                txtHSBATempName.ReadOnly = true;
                txtHSBATempNamePath.ReadOnly = true;
                btnTimFileTemplate.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                gridControlDSBenhAn.Enabled = true;
                this.ie_hsbatemid = 0;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridControlDSBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSBenhAn.RowCount > 0)
                {
                    var rowHandle = gridViewDSBenhAn.FocusedRowHandle;
                    ie_hsbatemid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBenhAn.GetRowCellValue(rowHandle, "ie_hsbatemid").ToString());
                    txtHSBATempCode.Text = gridViewDSBenhAn.GetRowCellValue(rowHandle, "ie_hsbatemcode").ToString();
                    txtHSBATempName.Text = gridViewDSBenhAn.GetRowCellValue(rowHandle, "ie_hsbatemname").ToString();
                    txtHSBATempNamePath.Text = gridViewDSBenhAn.GetRowCellValue(rowHandle, "ie_hsbatemnamepath").ToString();
                    btnSua.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }




    }
}
