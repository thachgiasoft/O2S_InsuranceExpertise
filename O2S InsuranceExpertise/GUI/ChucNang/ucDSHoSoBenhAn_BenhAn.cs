﻿using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;
using O2S_InsuranceExpertise.DTO;
using O2S_InsuranceExpertise.GUI.ChucNang.HSBA_BenhAn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.ChucNang
{
    public partial class ucDSHoSoBenhAn : UserControl
    {
        #region Declaration
        private MrdHsbaHosobenhanDTO currentMrdHsbaHsba { get; set; }
        #endregion

        #region Load
        private void ucDSHoSoBenhAn_BenhAn_Load(InsuranceExpertiseDTO rowMecicalrecord)
        {
            try
            {
                BenhAn_LoadDataDefault();
                BenhAn_LoadDanhSachLoaiBenhAn();
                BenhAn_LoadDanhSachLichSuBenhAn(rowMecicalrecord);
                BenhAn_LoadBenhAnCuaBenhNhan(rowMecicalrecord);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void BenhAn_LoadDataDefault()
        {
            try
            {
                cboMauBenhAn.EditValue = null;
                gridControlHSBADSBenhAn.DataSource = null;
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void BenhAn_LoadDanhSachLoaiBenhAn()
        {
            try
            {
                cboMauBenhAn.Properties.DataSource = GlobalStore.GlobalLst_MrdHsbaTemplate;
                cboMauBenhAn.Properties.DisplayMember = "mrd_hsbatemname";
                cboMauBenhAn.Properties.ValueMember = "mrd_hsbatemid";
                if (GlobalStore.GlobalLst_MrdHsbaTemplate.Count == 1)
                {
                    cboMauBenhAn.ItemIndex = 0;
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void BenhAn_LoadDanhSachLichSuBenhAn(InsuranceExpertiseDTO rowMecicalrecord)
        {
            SplashScreenManager.ShowForm(typeof(O2S_InsuranceExpertise.Utilities.ThongBao.WaitForm1));
            try
            {
                string sqlLichSuBA = "Select ROW_NUMBER() OVER (ORDER BY mba.hosobenhanid desc) as stt, mba.mrd_hsba_hosobenhanid, mba.mrd_hsbatemid, mht.mrd_hsbatemname, mba.patientid, mba.hosobenhanid, mba.vienphiid, hosobenhan.hosobenhandate, (case when hosobenhan.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hosobenhan.hosobenhandate_ravien end) as hosobenhandate_ravien, mba.create_date, mus.username as create_mrdusername from mrd_hsba_hosobenhan mba inner join dblink('myconn','select hosobenhanid, hosobenhandate, hosobenhandate_ravien from hosobenhan where patientid=" + rowMecicalrecord.patientid + "') as hosobenhan(hosobenhanid integer, hosobenhandate timestamp without time zone, hosobenhandate_ravien timestamp without time zone) on hosobenhan.hosobenhanid=mba.hosobenhanid left join mrd_tbluser mus on mus.userid=mba.create_mrduserid inner join mrd_hsba_template mht on mht.mrd_hsbatemid=mba.mrd_hsbatemid where mba.patientid=" + rowMecicalrecord.patientid + " ; ";
                gridControlHSBADSBenhAn.DataSource = condb.GetDataTable_Dblink(sqlLichSuBA);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void BenhAn_LoadBenhAnCuaBenhNhan(InsuranceExpertiseDTO rowMecicalrecord)
        {
            try
            {
                this.highlight_tabBenhAn = false;
                this.currentMrdHsbaHsba = new MrdHsbaHosobenhanDTO();
                if (rowMecicalrecord.InsuranceExpertisestatus != 2)
                {
                    this.currentMrdHsbaHsba.file_readonly = true;
                    btnChonTaoBenhAn.Visible = false;
                    btnXemBenhAn.Visible = true;
                    cboMauBenhAn.ReadOnly = true;
                }
                else
                {
                    this.currentMrdHsbaHsba.file_readonly = false;
                    string sqlkiemtrabenhan = "SELECT mrd_hsba_hosobenhanid, hosobenhanid, mrd_hsbatemid, mrd_hsba_hosobenhandata FROM mrd_hsba_hosobenhan WHERE hosobenhanid=" + rowMecicalrecord.hosobenhanid + ";";
                    DataTable databenhan = condb.GetDataTable_HSBA(sqlkiemtrabenhan);
                    if (databenhan != null && databenhan.Rows.Count > 0)
                    {
                        cboMauBenhAn.EditValue = Utilities.Util_TypeConvertParse.ToInt64(databenhan.Rows[0]["mrd_hsbatemid"].ToString());
                        this.currentMrdHsbaHsba.mrd_hsba_hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(databenhan.Rows[0]["mrd_hsba_hosobenhanid"].ToString());
                        this.currentMrdHsbaHsba.mrd_hsba_hosobenhandata = databenhan.Rows[0]["mrd_hsba_hosobenhandata"].ToString();

                        btnChonTaoBenhAn.Visible = false;
                        btnXemBenhAn.Visible = true;
                        cboMauBenhAn.ReadOnly = true;
                    }
                    else
                    {
                        btnChonTaoBenhAn.Visible = true;
                        btnXemBenhAn.Visible = false;
                        cboMauBenhAn.ReadOnly = false;
                        this.highlight_tabBenhAn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        #endregion

        #region Button
        private void btnChonTaoBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMauBenhAn.EditValue != null)
                {
                    if (this.SelectRowInsuranceExpertise.InsuranceExpertisestatus == 0)
                    {
                        O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.BENH_NHAN_CHUA_DUOC_TIEP_NHAN_VAO_PHONG);
                        frmthongbao.Show();
                    }
                    else if (this.SelectRowInsuranceExpertise.InsuranceExpertisestatus == 2)
                    {
                        this.currentMrdHsbaHsba.patientid = this.SelectRowInsuranceExpertise.patientid;
                        this.currentMrdHsbaHsba.vienphiid = this.SelectRowInsuranceExpertise.vienphiid;
                        this.currentMrdHsbaHsba.InsuranceExpertiseid = this.SelectRowInsuranceExpertise.InsuranceExpertiseid;
                        this.currentMrdHsbaHsba.hosobenhanid = this.SelectRowInsuranceExpertise.hosobenhanid;
                        this.currentMrdHsbaHsba.departmentgroupid = this.SelectRowInsuranceExpertise.departmentgroupid;
                        this.currentMrdHsbaHsba.departmentid = this.SelectRowInsuranceExpertise.departmentid;
                        this.currentMrdHsbaHsba.mrd_hsbatemid = Utilities.Util_TypeConvertParse.ToInt64(cboMauBenhAn.EditValue.ToString());
                        frmNhapBenhAn frmNhap = new frmNhapBenhAn(this.currentMrdHsbaHsba);
                        frmNhap.ShowDialog();

                        //Sua dung Office de mo
                        //  HSBA_BenhAn_Process.LayDuLieuVaXuatFileWord(mrdHsbaHsba);
                        ucDSHoSoBenhAn_BenhAn_Load(this.SelectRowInsuranceExpertise);
                    }
                    else
                    {
                        O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.BENH_AN_DA_KET_THUC);
                        frmthongbao.Show();
                    }
                }
                else
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.CHUA_CHON_LOAI_BENH_AN);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        private void btnXemBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                this.currentMrdHsbaHsba.patientid = this.SelectRowInsuranceExpertise.patientid;
                this.currentMrdHsbaHsba.vienphiid = this.SelectRowInsuranceExpertise.vienphiid;
                this.currentMrdHsbaHsba.InsuranceExpertiseid = this.SelectRowInsuranceExpertise.InsuranceExpertiseid;
                this.currentMrdHsbaHsba.hosobenhanid = this.SelectRowInsuranceExpertise.hosobenhanid;
                this.currentMrdHsbaHsba.mrd_hsbatemid = Utilities.Util_TypeConvertParse.ToInt64(cboMauBenhAn.EditValue.ToString());
                frmNhapBenhAn frmNhap = new frmNhapBenhAn(this.currentMrdHsbaHsba);
                frmNhap.ShowDialog();

                //Sua dung Office de mo
                //  HSBA_BenhAn_Process.LayDuLieuVaXuatFileWord(mrdHsbaHsba);
                ucDSHoSoBenhAn_BenhAn_Load(this.SelectRowInsuranceExpertise);
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        private void repositoryItemButtonView_Click(object sender, EventArgs e)
        {
            try
            {
                gridControlHSBADSBenhAn_DoubleClick(null, null);
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void gridControlHSBADSBenhAn_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewHSBADSBenhAn.FocusedRowHandle;
                MrdHsbaHosobenhanDTO rowHsbaHsba = new MrdHsbaHosobenhanDTO();
                rowHsbaHsba.mrd_hsba_hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(gridViewHSBADSBenhAn.GetRowCellValue(rowHandle, "mrd_hsba_hosobenhanid").ToString());
                rowHsbaHsba.hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(gridViewHSBADSBenhAn.GetRowCellValue(rowHandle, "hosobenhanid").ToString());
                rowHsbaHsba.mrd_hsbatemid = Utilities.Util_TypeConvertParse.ToInt64(gridViewHSBADSBenhAn.GetRowCellValue(rowHandle, "mrd_hsbatemid").ToString());
                rowHsbaHsba.file_readonly = true;
                frmNhapBenhAn frmNhap = new frmNhapBenhAn(rowHsbaHsba);
                frmNhap.ShowDialog();
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void gridViewHSBADSBenhAn_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    e.Menu.Items.Clear();
                    DXMenuItem itemXoaPhieuChiDinh = new DXMenuItem("Copy mẫu bệnh án này");
                    itemXoaPhieuChiDinh.Image = imMenu_HSBA.Images[0];
                    //itemXoaToanBA.Shortcut = Shortcut.F6;
                    itemXoaPhieuChiDinh.Click += new EventHandler(ItemSuDungMauBenhAn_Click);
                    e.Menu.Items.Add(itemXoaPhieuChiDinh);
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }
        void ItemSuDungMauBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnChonTaoBenhAn.Visible == true)
                {
                    var rowHandle = gridViewHSBADSBenhAn.FocusedRowHandle;
                    MrdHsbaHosobenhanDTO rowHsbaHsba = new MrdHsbaHosobenhanDTO();
                    rowHsbaHsba.mrd_hsbatemid = Utilities.Util_TypeConvertParse.ToInt64(gridViewHSBADSBenhAn.GetRowCellValue(rowHandle, "mrd_hsbatemid").ToString());
                    rowHsbaHsba.hosobenhanid = Utilities.Util_TypeConvertParse.ToInt64(gridViewHSBADSBenhAn.GetRowCellValue(rowHandle, "hosobenhanid").ToString());
                    cboMauBenhAn.EditValue = rowHsbaHsba.mrd_hsbatemid;
                    string getdata_nd = "SELECT mrd_hsba_hosobenhanid, hosobenhanid, mrd_hsbatemid, mrd_hsba_hosobenhandata_nd FROM mrd_hsba_hosobenhan WHERE hosobenhanid=" + rowHsbaHsba.hosobenhanid + ";";
                    DataTable databenhan_nd = condb.GetDataTable_HSBA(getdata_nd);
                    if (databenhan_nd != null && databenhan_nd.Rows.Count > 0)
                    {
                        this.currentMrdHsbaHsba.mrd_hsba_hosobenhandata_nd = databenhan_nd.Rows[0]["mrd_hsba_hosobenhandata_nd"].ToString();
                    }
                    btnChonTaoBenhAn_Click(null, null);
                }
                else
                {
                    O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_InsuranceExpertise.Utilities.ThongBao.frmThongBao(O2S_InsuranceExpertise.Base.ThongBaoLable.BENH_AN_DA_DUOC_TAO);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }
        private void repositoryItemButtonSuDungMau_Click(object sender, EventArgs e)
        {
            try
            {
                ItemSuDungMauBenhAn_Click(null, null);
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        #endregion

    }
}
