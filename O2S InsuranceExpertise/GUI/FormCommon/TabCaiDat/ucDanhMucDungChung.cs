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

namespace O2S_InsuranceExpertise.GUI.FormCommon.TabCaiDat
{
    public partial class ucDanhMucDungChung : UserControl
    {
        #region Khai bao
        O2S_InsuranceExpertise.DAL.ConnectDatabase condb = new O2S_InsuranceExpertise.DAL.ConnectDatabase();
        private DataView loaiDanhMuc { get; set; } 
        private long selectie_othertypelistid { get; set; }
        private long selectie_otherlistid { get; set; }

        #endregion
        public ucDanhMucDungChung()
        {
            InitializeComponent();
        }

        #region Load
        private void ucDanhMucDungChung_Load(object sender, EventArgs e)
        {
            try
            {
                Load_ControlDefault();
                LoadDS_LoaiDanhMuc();
                LoadDS_DanhMuc(0);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void Load_ControlDefault()
        {
            try
            {
                btnLoaiDM_Them.Enabled = true;
                btnLoaiDM_Luu.Enabled = false;
                txtLoaiDM_Ma.ReadOnly = true;
                txtLoaiDM_Ten.ReadOnly = true;

                btnDM_Them.Enabled = false;
                btnDM_Luu.Enabled = false;
                txtDM_Ma.ReadOnly = true;
                txtDM_Ten.ReadOnly = true;
                txtDM_GiaTri.ReadOnly = true;
                cboDM_LoaiDMTen.ReadOnly = true;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void LoadDS_LoaiDanhMuc()
        {
            try
            {
                loaiDanhMuc = new DataView();
                string sqlgetdanhsach = "select ROW_NUMBER() OVER (ORDER BY ie_othertypelistid) as stt, ie_othertypelistid, ie_othertypelistcode, ie_othertypelistname, ie_othertypeliststatus from ie_othertypelist; ";
                DataView dataDanhSach = new DataView(condb.GetDataTable_HSBA(sqlgetdanhsach));
                gridControlLoaiDM.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DisplayMember = "ie_othertypelistname";
                cboDM_LoaiDMTen.Properties.ValueMember = "ie_othertypelistid";
                loaiDanhMuc = dataDanhSach;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void LoadDS_DanhMuc(long othertypelistid)
        {
            try
            {
                string ie_othertypelistid = "";
                if (othertypelistid != 0)
                {
                    ie_othertypelistid = " where oty.ie_othertypelistid=" + othertypelistid;
                }
                string sqlgetdanhsach = "select ROW_NUMBER() OVER (ORDER BY oty.ie_othertypelistname, o.ie_otherlistname) as stt, oty.ie_othertypelistid, oty.ie_othertypelistcode, oty.ie_othertypelistname, o.ie_otherlistid, o.ie_otherlistcode, o.ie_otherlistname, o.ie_otherliststatus from ie_othertypelist oty inner join ie_otherlist o on o.ie_othertypelistid=oty.ie_othertypelistid " + ie_othertypelistid + "; ";
                DataView dataDanhSach = new DataView(condb.GetDataTable_HSBA(sqlgetdanhsach));
                gridControlDM.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DataSource = this.loaiDanhMuc;
                cboDM_LoaiDMTen.Properties.DisplayMember = "ie_othertypelistname";
                cboDM_LoaiDMTen.Properties.ValueMember = "ie_othertypelistid";
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        #endregion

        #region Loai danh muc
        private void btnLoaiDM_Them_Click(object sender, EventArgs e)
        {
            try
            {
                this.selectie_othertypelistid = 0;
                btnLoaiDM_Them.Enabled = true;
                btnLoaiDM_Luu.Enabled = true;
                txtLoaiDM_Ma.ReadOnly = false;
                txtLoaiDM_Ten.ReadOnly = false;
                txtLoaiDM_Ma.Text = "";
                txtLoaiDM_Ten.Text = "";

                btnDM_Them.Enabled = false;
                btnDM_Luu.Enabled = false;
                txtDM_Ma.ReadOnly = true;
                txtDM_Ten.ReadOnly = true;
                txtDM_GiaTri.ReadOnly = true;
                txtDM_Ma.Text = "";
                txtDM_Ten.Text = "";
                txtDM_GiaTri.Text = "";
                cboDM_LoaiDMTen.ReadOnly = true;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void btnLoaiDM_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoaiDM_Ma.Text.Trim() != "" && txtLoaiDM_Ten.Text.Trim() != "")
                {
                    if (this.selectie_othertypelistid == 0)
                    {
                        string kiemtratontai = "select ie_othertypelistid from ie_othertypelist where ie_othertypelistcode='" + txtLoaiDM_Ma.Text.Trim().ToUpper() + "';";
                        DataView dataDanhSach = new DataView(condb.GetDataTable_HSBA(kiemtratontai));
                        if (dataDanhSach != null && dataDanhSach.Count > 0)
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.KHONG_THE_SU_DUNG_MA_NAY);
                            frmthongbao.Show();
                        }
                        else //them moi
                        {
                            string insert = "INSERT INTO ie_othertypelist(ie_othertypelistcode, ie_othertypelistname) VALUES ('" + txtLoaiDM_Ma.Text.Trim().ToUpper() + "', '" + txtLoaiDM_Ten.Text.Trim() + "'); ";
                            if (condb.ExecuteNonQuery_HSBA(insert))
                            {
                                O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                                frmthongbao.Show();
                            }
                        }
                    }
                    else//cap nhat
                    {
                        string insert = "UPDATE ie_othertypelist SET ie_othertypelistname='" + txtLoaiDM_Ten.Text.Trim() + "' WHERE ie_othertypelistid=" + this.selectie_othertypelistid + "; ";
                        if (condb.ExecuteNonQuery_HSBA(insert))
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                            frmthongbao.Show();
                        }
                    }
                    LoadDS_LoaiDanhMuc();
                }
                else
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void gridControlLoaiDM_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewLoaiDM.RowCount > 0)
                {
                    var rowHandle = gridViewLoaiDM.FocusedRowHandle;

                    this.selectie_othertypelistid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewLoaiDM.GetRowCellValue(rowHandle, "ie_othertypelistid").ToString());
                    txtLoaiDM_Ma.Text = gridViewLoaiDM.GetRowCellValue(rowHandle, "ie_othertypelistcode").ToString();
                    txtLoaiDM_Ten.Text = gridViewLoaiDM.GetRowCellValue(rowHandle, "ie_othertypelistname").ToString();
                    btnLoaiDM_Them.Enabled = true;
                    btnLoaiDM_Luu.Enabled = true;
                    txtLoaiDM_Ma.ReadOnly = true;
                    txtLoaiDM_Ten.ReadOnly = false;
                    LoadDS_DanhMuc(this.selectie_othertypelistid);

                    btnDM_Them.Enabled = true;
                    btnDM_Luu.Enabled = true;
                    txtDM_Ma.ReadOnly = true;
                    txtDM_Ten.ReadOnly = true;
                    txtDM_GiaTri.ReadOnly = true;
                    txtDM_Ma.Text = "";
                    txtDM_Ten.Text = "";
                    txtDM_GiaTri.Text = "";
                    cboDM_LoaiDMTen.ReadOnly = true;
                    cboDM_LoaiDMTen.EditValue = null;
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        #endregion

        #region Danh muc
        private void btnDM_Them_Click(object sender, EventArgs e)
        {
            try
            {
                this.selectie_otherlistid = 0;
                btnLoaiDM_Them.Enabled = false;
                btnLoaiDM_Luu.Enabled = false;
                txtLoaiDM_Ma.ReadOnly = true;
                txtLoaiDM_Ten.ReadOnly = true;
                txtLoaiDM_Ma.Text = "";
                txtLoaiDM_Ten.Text = "";

                btnDM_Them.Enabled = true;
                btnDM_Luu.Enabled = true;
                txtDM_Ma.ReadOnly = false;
                txtDM_Ten.ReadOnly = false;
                txtDM_GiaTri.ReadOnly = false;
                txtDM_Ma.Text = "";
                txtDM_Ten.Text = "";
                txtDM_GiaTri.Text = "";
                cboDM_LoaiDMTen.ReadOnly = false;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void btnDM_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDM_Ma.Text.Trim() != "" && txtDM_Ten.Text.Trim() != "" && cboDM_LoaiDMTen.EditValue != null)
                {
                    if (this.selectie_otherlistid == 0)
                    {
                        string kiemtratontai = "select ie_otherlistid from ie_otherlist where ie_otherlistcode='" + txtDM_Ma.Text.Trim().ToUpper() + "';";
                        DataView dataDanhSach = new DataView(condb.GetDataTable_HSBA(kiemtratontai));
                        if (dataDanhSach != null && dataDanhSach.Count > 0)
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.KHONG_THE_SU_DUNG_MA_NAY);
                            frmthongbao.Show();
                        }
                        else //them moi
                        {
                            string insert = "INSERT INTO ie_otherlist(ie_otherlistcode, ie_otherlistname, ie_othertypelistid, ie_otherlistvalue) VALUES ('" + txtDM_Ma.Text.Trim().ToUpper() + "', '" + txtDM_Ten.Text.Trim() + "','" + cboDM_LoaiDMTen.EditValue.ToString() + "', '" + txtDM_GiaTri.Text.Trim().ToUpper() + "'); ";
                            if (condb.ExecuteNonQuery_HSBA(insert))
                            {
                                O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                                frmthongbao.Show();
                            }
                        }
                    }
                    else//cap nhat
                    {
                        string insert = "UPDATE ie_otherlist SET ie_otherlistname='" + txtDM_Ten.Text.Trim() + "', ie_otherlistvalue='" + txtDM_GiaTri.Text.Trim() + "' WHERE ie_otherlistid=" + this.selectie_otherlistid + "; ";
                        if (condb.ExecuteNonQuery_HSBA(insert))
                        {
                            O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                            frmthongbao.Show();
                        }
                    }
                    LoadDS_DanhMuc(Common.TypeConvert.TypeConvertParse.ToInt64(cboDM_LoaiDMTen.EditValue.ToString()));
                }
                else
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void gridControlDM_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDM.RowCount > 0)
                {
                    var rowHandle = gridViewDM.FocusedRowHandle;

                    this.selectie_otherlistid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDM.GetRowCellValue(rowHandle, "ie_otherlistid").ToString());
                    txtDM_Ma.Text = gridViewDM.GetRowCellValue(rowHandle, "ie_otherlistcode").ToString();
                    txtDM_Ten.Text = gridViewDM.GetRowCellValue(rowHandle, "ie_otherlistname").ToString();
                    cboDM_LoaiDMTen.EditValue = gridViewDM.GetRowCellValue(rowHandle, "ie_othertypelistid");
                    txtDM_GiaTri.Text = gridViewDM.GetRowCellValue(rowHandle, "ie_otherlistvalue").ToString();
                    btnDM_Them.Enabled = true;
                    btnDM_Luu.Enabled = true;
                    txtDM_Ma.ReadOnly = true;
                    txtDM_Ten.ReadOnly = false;
                    txtDM_GiaTri.ReadOnly = false;
                    cboDM_LoaiDMTen.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        #endregion

        #region Custom
        private void gridViewLoaiDM_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        #endregion





    }
}
