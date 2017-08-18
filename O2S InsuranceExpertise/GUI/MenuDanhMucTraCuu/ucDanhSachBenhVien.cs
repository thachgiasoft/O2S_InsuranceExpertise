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
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.MenuDanhMucTraCuu
{
    public partial class ucDanhSachBenhVien : UserControl
    {
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        List<Model.Models.DanhSachBenhVienDTO> lstbenhVien { get; set; }

        #region Load
        public ucDanhSachBenhVien()
        {
            InitializeComponent();
        }

        private void ucDanhSachBenhVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachBenhVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachBenhVien()
        {
            try
            {
                string sqldsbv = "select row_number () over (order by benhvienkcbbd) as stt, benhvienid, benhvienkcbbd, benhviencode, benhvienname, benhvienaddress,benhvienhang,benhvientuyen,ghichu from ie_benhvien;";
                DataTable dataBenhVien = condb.GetDataTable_HSBA(sqldsbv);
                this.lstbenhVien = new List<Model.Models.DanhSachBenhVienDTO>();
                if (dataBenhVien != null && dataBenhVien.Rows.Count > 0)
                {
                    for (int i = 0; i < dataBenhVien.Rows.Count; i++)
                    {
                        Model.Models.DanhSachBenhVienDTO benhvien = new Model.Models.DanhSachBenhVienDTO();
                        benhvien.stt = Common.TypeConvert.TypeConvertParse.ToInt64(dataBenhVien.Rows[i]["stt"].ToString());
                        benhvien.benhvienkcbbd = dataBenhVien.Rows[i]["benhvienkcbbd"].ToString();
                        benhvien.benhviencode = dataBenhVien.Rows[i]["benhviencode"].ToString();
                        benhvien.benhvienname = dataBenhVien.Rows[i]["benhvienname"].ToString();
                        benhvien.benhvienaddress = dataBenhVien.Rows[i]["benhvienaddress"].ToString();
                        benhvien.benhvienhang = dataBenhVien.Rows[i]["benhvienhang"].ToString();
                        benhvien.benhvientuyen = dataBenhVien.Rows[i]["benhvientuyen"].ToString();
                        benhvien.ghichu = dataBenhVien.Rows[i]["ghichu"].ToString();
                        benhvien.benhvienname_khongdau = Common.String.StringConvert.UnSignVNese(benhvien.benhvienname).ToLower();
                        benhvien.benhvienaddress_khongdau = Common.String.StringConvert.UnSignVNese(benhvien.benhvienaddress).ToLower();
                        this.lstbenhVien.Add(benhvien);
                    }
                }
                gridControlDSBenhVien.DataSource = this.lstbenhVien;
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

        private void txtTuKhoaTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTuKhoaTimKiem_TextChanged(null, null);
            }
        }

        private void txtTuKhoaTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTuKhoaTimKiem.Text.Trim() != "")
                {
                    string tukhoa = Common.String.StringConvert.UnSignVNese(txtTuKhoaTimKiem.Text.Trim().ToLower());
                    List<Model.Models.DanhSachBenhVienDTO> lstie_benhvien_timkiem = this.lstbenhVien.Where(o => o.benhvienname_khongdau.Contains(tukhoa) || o.benhvienaddress_khongdau.Contains(tukhoa) || o.benhvienkcbbd.Contains(tukhoa)).ToList();
                    gridControlDSBenhVien.DataSource = lstie_benhvien_timkiem;
                }
                else
                {
                    gridControlDSBenhVien.DataSource = this.lstbenhVien;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
