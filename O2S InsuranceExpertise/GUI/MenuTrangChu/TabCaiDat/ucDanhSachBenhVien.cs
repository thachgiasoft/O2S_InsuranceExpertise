﻿using System;
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
using Aspose.Cells;

namespace O2S_InsuranceExpertise.GUI.MenuTrangChu
{
    public partial class ucDanhSachBenhVien : UserControl
    {
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private string benhvienid = "";
        private string worksheetName = "DM_CSKCB";
        #region Load
        public ucDanhSachBenhVien()
        {
            InitializeComponent();
        }

        private void ucDanhSachBenhVien_Load(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(false);
                LoadDanhSachBenhVien();
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
                btnOptionOK.Enabled = result;

                txtbenhvienkcbbd.ReadOnly = true;
                txtbenhvienname.Enabled = result;
                txtbenhviencode.Enabled = result;
                txtbenhvienaddress.Enabled = result;
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
                string sqldsbv = "select row_number () over (order by benhvienkcbbd) as stt, benhvienid, benhvienkcbbd, benhviencode, benhvienname, benhvienaddress, benhvienhang, benhvientuyen, ghichu from ie_benhvien;";
                DataView dataOption = new DataView(condb.GetDataTable_HSBA(sqldsbv));
                if (dataOption != null && dataOption.Count > 0)
                {
                    gridControlDSBenhVien.DataSource = dataOption;
                }
                else
                {
                    gridControlDSBenhVien.DataSource = null;
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

        private void HienThiThongBao(string tenThongBao)
        {
            try
            {
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(tenThongBao);
                frmthongbao.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSOption_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(true);
                var rowHandle = gridViewDSBenhVien.FocusedRowHandle;
                benhvienid = gridViewDSBenhVien.GetRowCellValue(rowHandle, "benhvienid").ToString();
                txtbenhvienkcbbd.Text = gridViewDSBenhVien.GetRowCellValue(rowHandle, "benhvienkcbbd").ToString();
                txtbenhvienname.Text = gridViewDSBenhVien.GetRowCellValue(rowHandle, "benhvienname").ToString();
                txtbenhviencode.Text = gridViewDSBenhVien.GetRowCellValue(rowHandle, "benhviencode").ToString();
                txtbenhvienaddress.Text = gridViewDSBenhVien.GetRowCellValue(rowHandle, "benhvienaddress").ToString();

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnOptionOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (benhvienid != "")
                {
                    string sqlupdate = "UPDATE ie_benhvien SET benhvienname='" + txtbenhvienname.Text.Trim() + "', benhviencode='" + txtbenhviencode.Text.Trim() + "', benhvienaddress='" + txtbenhvienaddress.Text.Trim() + "' WHERE benhvienid='" + benhvienid + "'; ";
                    if (condb.ExecuteNonQuery_HSBA(sqlupdate))
                    {
                        HienThiThongBao(Base.ThongBaoLable.SUA_THANH_CONG);
                    }
                }
                else
                {
                    string sqlupdate = "INSERT INTO ie_benhvien(benhvienkcbbd, benhviencode, benhvienname, benhvienaddress) VALUES ('" + txtbenhvienkcbbd.Text.Trim() + "', '" + txtbenhviencode.Text.Trim() + "', '" + txtbenhvienname.Text.Trim() + "', '" + txtbenhvienaddress.Text.Trim() + "');";
                    if (condb.ExecuteNonQuery_HSBA(sqlupdate))
                    {
                        HienThiThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    }
                }

                gridControlDSBenhVien.DataSource = null;
                ucDanhSachBenhVien_Load(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnOptionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(true);
                txtbenhvienkcbbd.ReadOnly = false;

                benhvienid = "";
                txtbenhvienkcbbd.Text = "";
                txtbenhvienname.Text = "";
                txtbenhviencode.Text = "";
                txtbenhvienaddress.Text = "";
                txtbenhvienkcbbd.Focus();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                    //Base.ReadExcelFile _excel = new Base.ReadExcelFile(openFileDialogSelect.FileName);
                    //var data = _excel.GetDataTable("SELECT BENHVIENKCBBD, BENHVIENCODE, BENHVIENNAME, BENHVIENADDRESS, BENHVIENHANG, BENHVIENTUYEN, MAHUYEN, GHICHU FROM[" + worksheetName + "$]");
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[worksheetName];
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(2, 0, worksheet.Cells.MaxDataRow, worksheet.Cells.MaxDataColumn+1, true);
                    data_Excel.TableName = "DATA";
                    if (data_Excel != null)
                    {
                        int dem_update = 0;
                        int dem_insert = 0;
                        DataView dmCSYT_Import = new DataView(data_Excel);

                        for (int i = 0; i < dmCSYT_Import.Count; i++)
                        {
                            if (dmCSYT_Import[i]["BENHVIENKCBBD"].ToString() != "")
                            {
                                condb.Connect();
                                string sql_kt = "SELECT benhvienkcbbd FROM ie_benhvien WHERE benhvienkcbbd='" + dmCSYT_Import[i]["BENHVIENKCBBD"].ToString() + "';";
                                DataView dv_kt = new DataView(condb.GetDataTable_HSBA(sql_kt));
                                if (dv_kt.Count > 0) //update
                                {
                                    string sql_updateUser = "UPDATE ie_benhvien SET benhviencode='" + dmCSYT_Import[i]["BENHVIENCODE"].ToString() + "', benhvienname='" + dmCSYT_Import[i]["BENHVIENNAME"].ToString().Replace("'", "''") + "', benhvienaddress='" + dmCSYT_Import[i]["BENHVIENADDRESS"].ToString().Replace("'", "''") + "', benhvienhang='" + dmCSYT_Import[i]["BENHVIENHANG"] + "', benhvientuyen='" + dmCSYT_Import[i]["BENHVIENTUYEN"] + "', mahuyen='" + dmCSYT_Import[i]["MAHUYEN"] + "', ghichu='" + dmCSYT_Import[i]["GHICHU"] + "' WHERE benhvienkcbbd='" + dmCSYT_Import[i]["BENHVIENKCBBD"].ToString() + "';";
                                    try
                                    {
                                        condb.ExecuteNonQuery_HSBA(sql_updateUser);
                                        dem_update += 1;
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    string sql_insertDVKT = "INSERT INTO ie_benhvien(benhvienkcbbd, benhviencode, benhvienname, benhvienaddress, benhvienhang, benhvientuyen, mahuyen, ghichu) VALUES ('" + dmCSYT_Import[i]["BENHVIENKCBBD"].ToString() + "', '" + dmCSYT_Import[i]["BENHVIENCODE"].ToString() + "', '" + dmCSYT_Import[i]["BENHVIENNAME"].ToString().Replace("'", "''") + "', '" + dmCSYT_Import[i]["BENHVIENADDRESS"].ToString().Replace("'", "''") + "', '" + dmCSYT_Import[i]["BENHVIENHANG"].ToString().Replace("'", "''") + "', '" + dmCSYT_Import[i]["BENHVIENTUYEN"].ToString().Replace("'", "''") + "', '" + dmCSYT_Import[i]["MAHUYEN"].ToString().Replace("'", "''") + "', '" + dmCSYT_Import[i]["GHICHU"].ToString().Replace("'", "''") + "');";
                                    try
                                    {
                                        condb.ExecuteNonQuery_HSBA(sql_insertDVKT);
                                        dem_insert += 1;
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Thêm mới [ " + dem_insert + " ] & cập nhật [ " + dem_update + " ] Cơ sở y tế thành công.");
                        gridControlDSBenhVien.DataSource = null;
                        ucDanhSachBenhVien_Load(null, null);
                    }
                    SplashScreenManager.CloseForm();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                SplashScreenManager.CloseForm();
            }
        }
    }
}
