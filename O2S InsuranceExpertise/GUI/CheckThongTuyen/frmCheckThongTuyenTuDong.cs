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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                    string password = Base.EncryptAndDecrypt.CalculateMD5Hash(Base.SessionLogin.Password_GDBHYT);
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
                    CheckThongTuyen();
                }
                else
                {
                    CheckThongTuyen();
                }

            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
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
                string password = Base.EncryptAndDecrypt.CalculateMD5Hash(Base.SessionLogin.Password_GDBHYT);
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
                    string thongbao = "";
                    switch (lsKhamChuaBenh.maKetQua)
                    {
                        case "00":
                            {
                                thongbao = "Thông tin thẻ chính xác";
                                break;
                            }
                        case "01":
                            {
                                thongbao = "Thẻ hết giá trị sử dụng";
                                break;
                            }

                        default:
                            break;
                    }

                    lblThongBaoKetQua.Text = thongbao;
                    lblThongBaoKetQua.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.
                    lblThongBaoKetQua.Text = "Có lỗi xảy ra!";
                    lblThongBaoKetQua.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
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
                    this.Size = new System.Drawing.Size(440, 450);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
            }
        }
        #endregion


        #region Check Len Server
        private void btnCheckThongTuyen_Click(object sender, EventArgs e)
        {
            try
            {
                CheckThongTuyen_Server();
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
            }
        }

        private void CheckThongTuyen_Server()
        {
            try
            {
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
                    lblThongBaoKetQua.Text = "Có " + lstlichsuKCB_Loi.Count + " hồ sơ thẻ không chính xác.";
                    lblThongBaoKetQua.ForeColor = System.Drawing.Color.Green;
                    gridControlDSBN.DataSource = lstlichsuKCB_Loi;
                }
                else
                {
                    //string ketqua = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase); //Get 401 error here.
                    lblThongBaoKetQua.Text = "Có lỗi xảy ra!";
                    lblThongBaoKetQua.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Base.Logging.Error(ex);
            }
        }

        #endregion

        private void frmCheckThongTuyenTuDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
