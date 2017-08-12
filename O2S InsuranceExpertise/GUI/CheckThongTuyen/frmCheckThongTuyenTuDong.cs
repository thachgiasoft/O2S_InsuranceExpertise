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

namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    public partial class frmCheckThongTuyenTuDong : Form
    {
        static HttpClient client = new HttpClient();
        private HttpClient client_1 = new HttpClient();
        private List<LichSuKhamChuaBenhDTO> lsLichSuKhamChuaBenh { get; set; }
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

        #region Check_Old
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobalStore.tokenSession == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string username = Base.SessionLogin.UserName_GDBHYT;
                    string password = Base.SessionLogin.Password_GDBHYT_MD5;
                    //HTTP POST
                    ApiTokenDTO input = new ApiTokenDTO { username = username, password = password };
                    var values = new Dictionary<string, string>
                    {
                    { "username",username},
                    { "password",password}
                    };
                    var content = new FormUrlEncodedContent(values);
                    HttpResponseMessage response = client.PostAsync("api/token/take", content).Result;

                    GlobalStore.tokenSession = new TokenDTO();
                    if (response.IsSuccessStatusCode)
                    {
                        GlobalStore.tokenSession = response.Content.ReadAsAsync<TokenDTO>().Result;
                    }
                    //CheckThongTuyen();

                    TheBHYT_ChkThongTuyenDTO form_data = new TheBHYT_ChkThongTuyenDTO();
                    form_data.maThe = "XN2311201300054";
                    form_data.hoTen = "LÊ VĂN RƯỢC";
                    form_data.ngaySinh = "20/10/1930";
                    form_data.gioiTinh = 1;
                    form_data.ngayBD = "01/01/2015";
                    form_data.ngayKT = "31/12/2015";
                    form_data.maCSKCB = "31009";
                    form_data.username = Base.SessionLogin.UserName_GDBHYT;
                    form_data.password = Base.SessionLogin.Password_GDBHYT;
                    form_data.token = GlobalStore.tokenSession.APIKey.access_token;
                    form_data.id_token = GlobalStore.tokenSession.APIKey.id_token;

                    LichSuKhamChuaBenhDTO lichsuKCB = new LichSuKhamChuaBenhDTO();
                    lichsuKCB = CheckTungTheBHYT_CongBHYT(form_data);
                    //results.Add(lichsuKCB);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void CheckThongTuyen()
        {
            try
            {
                client_1 = new HttpClient();
                client_1.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string password = Common.EncryptAndDecrypt.EncryptAndDecrypt.CalculateMD5Hash(Base.SessionLogin.Password_GDBHYT);
                //HTTP POST
                string param_data = string.Format("token={0}&id_token={1}&username={2}&password={3}", GlobalStore.tokenSession.APIKey.access_token, GlobalStore.tokenSession.APIKey.id_token, Base.SessionLogin.UserName_GDBHYT, password);

                TheBHYT_ChkThongTuyenDTO form_data = new TheBHYT_ChkThongTuyenDTO();
                form_data.maThe = "XN2311201300054";
                form_data.hoTen = "LÊ VĂN RƯỢC";
                form_data.ngaySinh = "20/10/1930";
                form_data.gioiTinh = 1;
                form_data.ngayBD = "01/01/2015";
                form_data.ngayKT = "31/12/2015";
                form_data.maCSKCB = "31009";
                form_data.username = Base.SessionLogin.UserName_GDBHYT;
                form_data.password = Base.SessionLogin.Password_GDBHYT;
                form_data.token = GlobalStore.tokenSession.APIKey.access_token;
                form_data.id_token = GlobalStore.tokenSession.APIKey.id_token;

                var content = new StringContent(JsonConvert.SerializeObject(form_data), Encoding.UTF8, "application/json");

                //var values = new Dictionary<string, string>
                //{
                //    { "maThe",form_data.maThe},
                //    { "hoTen",form_data.hoTen},
                //    { "ngaySinh",form_data.ngaySinh},
                //    { "gioiTinh",form_data.gioiTinh.ToString()},
                //    { "maCSKCB",form_data.maCSKCB},
                //    { "ngayBD",form_data.ngayBD},
                //    { "ngayKT",form_data.ngayKT}
                //};
                //var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = client_1.PostAsync("api/egw/nhanLichSuKCB?" + param_data, content).Result;

                LichSuKhamChuaBenhDTO lsKhamChuaBenh = new LichSuKhamChuaBenhDTO();
                if (response.IsSuccessStatusCode)
                {
                    lsKhamChuaBenh = response.Content.ReadAsAsync<LichSuKhamChuaBenhDTO>().Result;
                    switch (lsKhamChuaBenh.maKetQua)
                    {
                        case "00":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thông tin thẻ chính xác";
                                break;
                            }
                        case "01":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ hết giá trị sử dụng";
                                break;
                            }
                        case "02":
                            {
                                lsKhamChuaBenh.tenKetQua = "KCB khi chưa đến hạn";
                                break;
                            }
                        case "03":
                            {
                                lsKhamChuaBenh.tenKetQua = "Hết hạn thẻ khi chưa ra viện";
                                break;
                            }
                        case "04":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ có giá trị khi đang nằm viện";
                                break;
                            }
                        case "05":
                            {
                                lsKhamChuaBenh.tenKetQua = "Mã thẻ không có trong dữ liệu thẻ";
                                break;
                            }
                        case "06":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai họ tên";
                                break;
                            }
                        case "07":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai ngày sinh";
                                break;
                            }
                        case "08":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai giới tính";
                                break;
                            }
                        case "09":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai nơi đăng ký KCB ban đầu";
                                break;
                            }
                        default:
                            break;
                    }
                    lblThongBaoKetQua.Text = lsKhamChuaBenh.tenKetQua;
                }
                else
                {
                    string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private LichSuKhamChuaBenhDTO CheckTungTheBHYT_CongBHYT(TheBHYT_ChkThongTuyenDTO form_data)
        {
            LichSuKhamChuaBenhDTO result = new LichSuKhamChuaBenhDTO();
            try
            {
                client_1 = new HttpClient();
                client_1.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn/");
                client_1.DefaultRequestHeaders.Accept.Clear();
                client_1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP POST
                string param_data = string.Format("token={0}&id_token={1}&username={2}&password={3}", GlobalStore.tokenSession.APIKey.access_token, GlobalStore.tokenSession.APIKey.id_token, Base.SessionLogin.UserName_GDBHYT, Base.SessionLogin.Password_GDBHYT_MD5);

                var content = new StringContent(JsonConvert.SerializeObject(form_data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/egw/nhanLichSuKCB?" + param_data, content).Result;

                LichSuKhamChuaBenhDTO lsKhamChuaBenh = new LichSuKhamChuaBenhDTO();
                if (response.IsSuccessStatusCode)
                {
                    lsKhamChuaBenh = response.Content.ReadAsAsync<LichSuKhamChuaBenhDTO>().Result;
                    switch (lsKhamChuaBenh.maKetQua)
                    {
                        case "00":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thông tin thẻ chính xác";
                                break;
                            }
                        case "01":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ hết giá trị sử dụng";
                                break;
                            }
                        case "02":
                            {
                                lsKhamChuaBenh.tenKetQua = "KCB khi chưa đến hạn";
                                break;
                            }
                        case "03":
                            {
                                lsKhamChuaBenh.tenKetQua = "Hết hạn thẻ khi chưa ra viện";
                                break;
                            }
                        case "04":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ có giá trị khi đang nằm viện";
                                break;
                            }
                        case "05":
                            {
                                lsKhamChuaBenh.tenKetQua = "Mã thẻ không có trong dữ liệu thẻ";
                                break;
                            }
                        case "06":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai họ tên";
                                break;
                            }
                        case "07":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai ngày sinh";
                                break;
                            }
                        case "08":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai giới tính";
                                break;
                            }
                        case "09":
                            {
                                lsKhamChuaBenh.tenKetQua = "Thẻ sai nơi đăng ký KCB ban đầu";
                                break;
                            }
                        default:
                            break;
                    }
                    result = lsKhamChuaBenh;
                }
                else
                {
                    string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.
                }

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
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
                }
                else
                {
                    this.Size = new System.Drawing.Size(440, 220);
                    linkLabelXemDanhSach.Text = "Xem danh sách";
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
                frmCongCuKhac_MoRong frmChon = new frmCongCuKhac_MoRong();
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

                TieuChiCheckDTO form_data = new TieuChiCheckDTO();
                form_data.tuNgay = dateTuNgay.DateTime;
                form_data.denNgay = dateDenNgay.DateTime;
                if (cboKhoa.EditValue != null)
                {
                    form_data.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt64(cboKhoa.EditValue.ToString());
                }
                var content = new StringContent(JsonConvert.SerializeObject(form_data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client_1.PostAsync("api/CheckThongTuyen/GetCheckListHosobenhan", content).Result;

                this.lsLichSuKhamChuaBenh = new List<LichSuKhamChuaBenhDTO>();
                if (response.IsSuccessStatusCode)
                {
                    this.lsLichSuKhamChuaBenh = response.Content.ReadAsAsync<List<LichSuKhamChuaBenhDTO>>().Result;
                    List<LichSuKhamChuaBenhDTO> lstlichsuKCB_Loi = this.lsLichSuKhamChuaBenh.Where(o => o.maKetQua != "00").ToList();
                    List<LichSuKhamChuaBenhDTO> lstlichsuKCB_LoiGDBHYT = this.lsLichSuKhamChuaBenh.Where(o => o.maLoi_CongGDBHYT ==null).ToList();
                    if (lstlichsuKCB_LoiGDBHYT == null || lstlichsuKCB_LoiGDBHYT.Count == 0)
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
