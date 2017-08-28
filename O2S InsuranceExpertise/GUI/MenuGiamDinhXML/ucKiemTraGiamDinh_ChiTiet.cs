using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using O2S_InsuranceExpertise.Model.Models;
using DevExpress.XtraGrid.Views.Grid;
using O2S_InsuranceExpertise.Utilities.GridView;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML
{
    public partial class ucKiemTraGiamDinh_ChiTiet : UserControl
    {
        #region Khai bao
        private XML_HOSODTO XMLHoSo_KiemTra { get; set; }


        #endregion
        public ucKiemTraGiamDinh_ChiTiet()
        {
            InitializeComponent();
        }
        public ucKiemTraGiamDinh_ChiTiet(XML_HOSODTO _XMLHoSo_KiemTra)
        {
            try
            {
                InitializeComponent();
                this.XMLHoSo_KiemTra = _XMLHoSo_KiemTra;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Load
        private void ucKiemTraGiaDinh_ChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiThongTinBenhNhan();
                //Giam dinh XML1
                GoiKiemTraGiamDinh_Server();
                //gridViewDSLoi_DVKT.Columns["TEN_NHOM"].SortOrder = DevExpress.Data.ColumnSortOrder.None;
                //gridViewDSLoi_DVKT.Columns["MA_NHOM"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void HienThiThongTinBenhNhan()
        {
            try
            {
                if (this.XMLHoSo_KiemTra != null)
                {
                    lblMaBN.Text = this.XMLHoSo_KiemTra.MA_BN;
                    lblTenBN.Text = this.XMLHoSo_KiemTra.HO_TEN;
                    lblTongChiPhi.Text = Common.Number.NumberConvert.NumberToString(this.XMLHoSo_KiemTra.T_TONGCHI ?? 0, 2);
                    lblBHYTThanhToan.Text = Common.Number.NumberConvert.NumberToString(this.XMLHoSo_KiemTra.T_BHTT ?? 0, 2);
                    lblBNThanhToan.Text = Common.Number.NumberConvert.NumberToString(this.XMLHoSo_KiemTra.T_BNTT ?? 0, 2);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom
        private void gridViewDSLoi_TongHop_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewDSLoi_TongHop_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (gridViewDSLoi_TongHop.GetRowCellValue(e.RowHandle, "LOAI_CANH_BAO") != null)
                {
                    string _soloi = gridViewDSLoi_TongHop.GetRowCellValue(e.RowHandle, "LOAI_CANH_BAO").ToString();
                    if (_soloi != "")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewDSLoi_DVKT_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (gridViewDSLoi_DVKT.GetRowCellValue(e.RowHandle, "LOAI_CANH_BAO") != null)
                {
                    string _soloi = gridViewDSLoi_DVKT.GetRowCellValue(e.RowHandle, "LOAI_CANH_BAO").ToString();
                    if (_soloi != "")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        //Danh stt Group row gridview
        private void gridViewDSLoi_DVKT_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName != "STT")
                    return;
                if (view.GroupedColumns.Count != 0 && !e.IsForGroupRow)
                {
                    int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                    e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion


    }
}
