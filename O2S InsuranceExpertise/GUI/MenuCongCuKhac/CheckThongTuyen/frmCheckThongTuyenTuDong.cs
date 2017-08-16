using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using O2S_InsuranceExpertise.DTO;
using Newtonsoft.Json;
using O2S_InsuranceExpertise.Model.Models;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.MenuCongCuKhac
{
    public partial class frmCheckThongTuyenTuDong : Form
    {
        static HttpClient client = new HttpClient();
        private HttpClient client_1 = new HttpClient();
        private List<KetQuaCheckThongTuyen_ExtendDTO> lsLichSuKhamChuaBenh { get; set; }
        public frmCheckThongTuyenTuDong()
        {
            InitializeComponent();
        }

        #region Load
        private void frmCheckThongTuyenTuDong_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                lblThongBaoKetQua.Text = "";
                LoadDanhSachKhoa();
                this.Size = new System.Drawing.Size(440, 220);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void LoadDanhSachKhoa()
        {
            try
            {
                //linq groupby
                var lstDSKhoa = Base.SessionLogin.SessionlstPhanQuyen_KhoaPhong.Where(o => o.departmentgrouptype == 1 || o.departmentgrouptype == 4 || o.departmentgrouptype == 11).ToList().GroupBy(o => o.departmentgroupid).Select(n => n.First()).ToList();
                if (lstDSKhoa != null && lstDSKhoa.Count > 0)
                {
                    cboKhoa.Properties.DataSource = lstDSKhoa;
                    cboKhoa.Properties.DisplayMember = "departmentgroupname";
                    cboKhoa.Properties.ValueMember = "departmentgroupid";
                }
                if (lstDSKhoa.Count > 0)
                {
                    cboKhoa.ItemIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }




        #endregion

        #region Custom
        private void linkLabelXemDanhSach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (linkLabelXemDanhSach.Text == "Xem danh sách")
                {
                    this.Size = new System.Drawing.Size(700, 650);
                    linkLabelXemDanhSach.Text = "Thu gọn danh sách";
                    this.StartPosition= FormStartPosition.CenterScreen;
                }
                else
                {
                    this.Size = new System.Drawing.Size(440, 220);
                    linkLabelXemDanhSach.Text = "Xem danh sách";
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void linkLabelXemThem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FormCommon.frmMain frmChon = new FormCommon.frmMain(true);
                frmChon.ShowDialog();
                //this.Visible = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
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
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void gridViewDSBN_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                //if (e.Column == gridColumn_stt)
                //{
                //    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        //Tùy chọn View con của View hiển thị
        private void gridControlDSBN_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            try
            {
                (e.View as GridView).ColumnPanelRowHeight = 25;
                (e.View as GridView).RowHeight = 25;
                (e.View as GridView).OptionsView.ShowIndicator = false;

                (e.View as GridView).Columns["stt_lichsu"].Caption = "STT";
                (e.View as GridView).Columns["maHoSo"].Caption = "Mã hồ sơ";
                (e.View as GridView).Columns["maCSKCB"].Caption = "Mã CSKCB";
                (e.View as GridView).Columns["tuNgay"].Caption = "Ngày vào viện";
                (e.View as GridView).Columns["denNgay"].Caption = "Ngày ra viện";
                (e.View as GridView).Columns["tenBenh"].Caption = "Tên bệnh";
                (e.View as GridView).Columns["tinhTrang"].Caption = "Mã tình trạng";
                (e.View as GridView).Columns["tinhTrang_Ten"].Caption = "Tình trạng";
                (e.View as GridView).Columns["kqDieuTri"].Caption = "Mã kết quả ĐT";
                (e.View as GridView).Columns["kqDieuTri_Ten"].Caption = "Kết quả điều trị";

                (e.View as GridView).Columns["tinhTrang"].Visible = false;
                (e.View as GridView).Columns["kqDieuTri"].Visible = false;

                (e.View as GridView).Columns["stt_lichsu"].Width = 35;
                (e.View as GridView).Columns["maHoSo"].Width = 80;
                (e.View as GridView).Columns["maCSKCB"].Width = 70;
                (e.View as GridView).Columns["tuNgay"].Width = 90;
                (e.View as GridView).Columns["denNgay"].Width = 90;
                (e.View as GridView).Columns["tenBenh"].Width = 200;
                (e.View as GridView).Columns["tinhTrang_Ten"].Width = 100;
                (e.View as GridView).Columns["kqDieuTri_Ten"].Width = 100;

                (e.View as GridView).Columns["stt_lichsu"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["maHoSo"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["maCSKCB"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tuNgay"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["denNgay"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tenBenh"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["tinhTrang_Ten"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["kqDieuTri_Ten"].OptionsColumn.AllowEdit = false;

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void frmCheckThongTuyenTuDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Check Len Server
        private void btnCheckThongTuyen_Click(object sender, EventArgs e)
        {
            try
            {
                gridControlDSBN.DataSource = null;
                CheckThongTuyen_Server();
                //btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void CheckThongTuyen_Server()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                client_1 = new HttpClient();
                client_1.BaseAddress = new Uri(Base.SessionLogin.UrlFullServer);
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                TieuChiCheckThongTuyenDTO form_data = new TieuChiCheckThongTuyenDTO();
                form_data.tuNgay = dateTuNgay.DateTime;
                form_data.denNgay = dateDenNgay.DateTime;
                if (cboKhoa.EditValue != null)
                {
                    form_data.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt64(cboKhoa.EditValue.ToString());
                }
                var content = new StringContent(JsonConvert.SerializeObject(form_data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/CheckThongTuyen/GetCheckListHosobenhan", content).Result;

                this.lsLichSuKhamChuaBenh = new List<KetQuaCheckThongTuyen_ExtendDTO>();
                if (response.IsSuccessStatusCode)
                {
                    this.lsLichSuKhamChuaBenh = response.Content.ReadAsAsync<List<KetQuaCheckThongTuyen_ExtendDTO>>().Result;
                    //Danh sách BN trả KQ về thẻ bị lỗi
                    List<KetQuaCheckThongTuyen_ExtendDTO> lstlichsuKCB_Loi = this.lsLichSuKhamChuaBenh.Where(o => o.maKetQua != "00").ToList();
                    //Lỗi do cổng BHYT
                    List<KetQuaCheckThongTuyen_ExtendDTO> lstlichsuKCB_MaKQGDBHYT = this.lsLichSuKhamChuaBenh.Where(o => o.maLoi_CongGDBHYT == null).ToList();
                    if ((lstlichsuKCB_MaKQGDBHYT == null || lstlichsuKCB_MaKQGDBHYT.Count == 0) && this.lsLichSuKhamChuaBenh.Count > 0)
                    {
                        lblThongBaoKetQua.Text = "Lỗi kết nối đến cổng Giám định BHYT!";
                        lblThongBaoKetQua.ForeColor = System.Drawing.Color.Red;
                        SplashScreenManager.CloseForm();
                        return;
                    }
                    else
                    {
                        lblThongBaoKetQua.Text = "Có " + lstlichsuKCB_Loi.Count + "/" + this.lsLichSuKhamChuaBenh.Count + " hồ sơ có lỗi.";
                        lblThongBaoKetQua.ForeColor = System.Drawing.Color.Green;
                    }
                    gridControlDSBN.DataSource = this.lsLichSuKhamChuaBenh;
                }
                else
                {
                    string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.

                    switch ((int)response.StatusCode)
                    {
                        case 500:
                            {
                                lblThongBaoKetQua.Text = "Lỗi kết nối đến server (" + (int)response.StatusCode + ")!";
                                break;
                            }
                        default:
                            {
                                lblThongBaoKetQua.Text = "Lỗi (" + (int)response.StatusCode + ")!";
                                break;
                            }
                    }
                    lblThongBaoKetQua.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        #endregion




    }
}
