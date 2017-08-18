using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Globalization;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;


namespace O2S_InsuranceExpertise.GUI.MenuCongCuKhac
{
    public partial class ucBCDangKyBaoHiemYTe_NoiTru : UserControl
    {
        #region Declaration
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        // private DataTable dataDanhBenhNhan { get; set; }
        #endregion

        #region Load
        public ucBCDangKyBaoHiemYTe_NoiTru()
        {
            InitializeComponent();
        }

        private void ucBangKeTongHopHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LoadDanhSachKhoa_NoiTru();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachKhoa_NoiTru()
        {
            try
            {
                //Load Danh Sach Khoa co buong dieu tri
                var lstKhoaCoBuongDieuTri = Base.SessionLogin.SessionlstPhanQuyen_KhoaPhong.Where(o => o.departmenttype == 3 || o.departmenttype == 9).ToList();
                //linq groupby
                var lstDSKhoa = lstKhoaCoBuongDieuTri.Where(o => o.departmentgrouptype == 1 || o.departmentgrouptype == 4 || o.departmentgrouptype == 11).ToList().GroupBy(o => o.departmentgroupid).Select(n => n.First()).ToList();
                if (lstDSKhoa != null && lstDSKhoa.Count > 0)
                {
                    chkcomboListDSKhoa.Properties.DataSource = lstDSKhoa;
                    chkcomboListDSKhoa.Properties.DisplayMember = "departmentgroupname";
                    chkcomboListDSKhoa.Properties.ValueMember = "departmentgroupid";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                if (chkcomboListDSKhoa.Text == "")
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CHUA_CHON_KHOA_PHONG);
                    frmthongbao.Show();
                    SplashScreenManager.CloseForm();
                    return;
                }
                //Cap nhat STT_BHYT
                GUI.MenuCongCuKhac.DanhSTTBHYTProcess.DanhSTTBHYT_TableBHYT();
                string tieuchi_hsba = "";
                //string tieuchi_bhyt = "";
                string tieuchi_log = "";
                string tieuchi_vp = "";
                string orderby = "";
                string lstKhoaChonLayBC = "";

                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                List<Object> lstKhoaCheck = chkcomboListDSKhoa.Properties.Items.GetCheckedValues();
                if (lstKhoaCheck.Count > 0)
                {
                    for (int i = 0; i < lstKhoaCheck.Count - 1; i++)
                    {
                        lstKhoaChonLayBC += lstKhoaCheck[i] + ",";
                    }
                    lstKhoaChonLayBC += lstKhoaCheck[lstKhoaCheck.Count - 1];
                }

                if (cboTieuChi.Text == "Theo ngày vào viện")
                {
                    tieuchi_hsba = " where hosobenhandate between '" + tungay + "' and '" + denngay + "' ";
                    tieuchi_vp = " where vienphidate between '" + tungay + "' and '" + denngay + "' ";
                    orderby = " hsba.hosobenhandate ";
                }
                else if (cboTieuChi.Text == "Theo ngày ra viện")
                {
                    tieuchi_hsba = " where hosobenhandate_ravien between '" + tungay + "' and '" + denngay + "' ";
                    tieuchi_vp = " where vienphidate_ravien between '" + tungay + "' and '" + denngay + "' ";
                    orderby = " hsba.hosobenhandate_ravien ";
                }
                else if (cboTieuChi.Text == "Theo ngày đăng ký thẻ")
                {
                    // tieuchi_bhyt = " and bhytdate between '" + tungay + "' and '" + denngay + "' ";
                    tieuchi_log = " and logtime between '" + tungay + "' and '" + denngay + "' ";
                    orderby = " log.logtime ";
                }

                string sql_getdata = "SELECT row_number () over (order by " + orderby + ") as stt, hsba.patientid, log.vienphiid, hsba.sovaovien, bh.stt_dkbhyt as sodkbhyt, hsba.patientname, (case vp.doituongbenhnhanid when 1 then 'BHYT' when 2 then 'Viện phí' when 3 then 'Dịch vụ' when 4 then 'Người nước ngoài' when 5 then 'Miễn phí' when 6 then 'Hợp đồng' end) as doituongbenhnhanid, bh.bhytcode, bh.macskcbbd, bh.bhytfromdate, bh.bhytutildate, (case bh.bhyt_loaiid when 1 then 'Đúng tuyến' when 2 then 'Đúng tuyến (giới thiệu)' when 3 then 'Đúng tuyến (cấp cứu)' when 4 then 'Trái tuyến' else '' end) as bhyt_loaiid, bh.noisinhsong, (case when bh.du5nam6thangluongcoban=1 then 'OK' end) as du5nam6thangluongcoban, degp.departmentgroupname, (mrd.noigioithieucode || '-' || ncd.benhvienname) as noichuyenden, hsba.hosobenhandate, (case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hsba.hosobenhandate_ravien end) as hosobenhandate_ravien, log.logtime, (log.loguser || ' - ' || ndk.username )as nguoidangky, (select ibc.bhytchecknote from dblink('myconn_ie','SELECT bhytcheckid,bhytid,bhytchecknote FROM ie_bhyt_check') AS ibc(bhytcheckid integer,bhytid integer,bhytchecknote text) where ibc.bhytid=bh.bhytid order by ibc.bhytcheckid desc limit 1) as bhytchecknote, '' as nguoihuydangky, log.logeventcontent FROM (select hosobenhanid,patientid,patientname,hosobenhandate,hosobenhandate_ravien,sovaovien from hosobenhan " + tieuchi_hsba + ") hsba inner join (select logeventid,hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype=8 and medicalrecordid=0 " + tieuchi_log + ") log on log.hosobenhanid=hsba.hosobenhanid inner join (select hosobenhanid,medicalrecordid,departmentgroupid,departmentid,bhytid,chandoanbandau,noigioithieucode,xutrikhambenhid,nextdepartmentid from medicalrecord where loaibenhanid=24 and hinhthucvaovienid=0) mrd on mrd.hosobenhanid=hsba.hosobenhanid inner join (select vienphiid,bhytid,hosobenhanid,doituongbenhnhanid from vienphi where loaivienphiid=0 " + tieuchi_vp + ") vp on vp.vienphiid=log.vienphiid inner join (select bhytid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid,stt_dkbhyt from bhyt where bhytcode<>'') bh on bh.bhytid=vp.bhytid inner join (select userhisid,usercode,username from nhompersonnel) ndk on ndk.usercode=log.loguser inner join tbldepartment user_de on user_de.usercode=log.loguser inner join (select departmentid,departmentname,departmentgroupid from department) de on de.departmentid=user_de.departmentid inner join (select departmentgroupid,departmentgroupname from departmentgroup where departmentgroupid in (" + lstKhoaChonLayBC + ")) degp on degp.departmentgroupid=de.departmentgroupid left join (select ie_benhvien.benhvienkcbbd,ie_benhvien,benhvienname from dblink('myconn_ie','SELECT benhvienkcbbd,benhvienname FROM ie_benhvien') AS ie_benhvien(benhvienkcbbd text,benhvienname text)) ncd on ncd.benhvienkcbbd=mrd.noigioithieucode where log.logeventcontent like '%' || bh.bhytcode || '%' group by hsba.patientid,log.vienphiid,hsba.sovaovien,hsba.patientname,bh.bhytcode,bh.macskcbbd,bh.bhytfromdate,bh.bhytutildate,bh.bhyt_loaiid,bh.noisinhsong,bh.du5nam6thangluongcoban,degp.departmentgroupname,mrd.noigioithieucode,ncd.benhvienname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,log.logtime,log.loguser,ndk.username,log.logeventcontent,bh.stt_dkbhyt,bh.bhytid,vp.doituongbenhnhanid;";

                DataTable dataDanhBenhNhan = condb.GetDataTable_Dblink_IE(sql_getdata);
                if (dataDanhBenhNhan != null && dataDanhBenhNhan.Rows.Count > 0)
                {
                    gridControlDataBaoCao.DataSource = dataDanhBenhNhan;
                }
                else
                {
                    gridControlDataBaoCao.DataSource = null;
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        #region Xuat bao cao
        private void tbnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.RowCount > 0)
                {
                    string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                    string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                    string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                    List<O2S_InsuranceExpertise.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_InsuranceExpertise.Model.Models.reportExcelDTO>();
                    O2S_InsuranceExpertise.Model.Models.reportExcelDTO reportitem = new O2S_InsuranceExpertise.Model.Models.reportExcelDTO();
                    reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                    reportitem.value = tungaydenngay;

                    O2S_InsuranceExpertise.Model.Models.reportExcelDTO reportitem_khoa = new O2S_InsuranceExpertise.Model.Models.reportExcelDTO();
                    reportitem_khoa.name = Base.bienTrongBaoCao.DEPARTMENTGROUPNAME;
                    reportitem_khoa.value = chkcomboListDSKhoa.Text;

                    thongTinThem.Add(reportitem);
                    thongTinThem.Add(reportitem_khoa);
                    string fileTemplatePath = "BC_DangKyBaoHiemYTe_NoiTru.xlsx";

                    DataTable dataExportFilter = Common.GridControl.GridControlConvert.ConvertGridControlToDataTable(gridViewDataBaoCao);
                    Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                    export.ExportExcelTemplate("", fileTemplatePath, thongTinThem, dataExportFilter);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<O2S_InsuranceExpertise.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_InsuranceExpertise.Model.Models.reportExcelDTO>();
                O2S_InsuranceExpertise.Model.Models.reportExcelDTO reportitem = new O2S_InsuranceExpertise.Model.Models.reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;

                O2S_InsuranceExpertise.Model.Models.reportExcelDTO reportitem_khoa = new O2S_InsuranceExpertise.Model.Models.reportExcelDTO();
                reportitem_khoa.name = Base.bienTrongBaoCao.DEPARTMENTGROUPNAME;
                reportitem_khoa.value = chkcomboListDSKhoa.Text;

                thongTinThem.Add(reportitem);
                thongTinThem.Add(reportitem_khoa);
                string fileTemplatePath = "BC_DangKyBaoHiemYTe_NoiTru.xlsx";
                DataTable dataExportFilter = Common.GridControl.GridControlConvert.ConvertGridControlToDataTable(gridViewDataBaoCao);
                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExportFilter);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();

        }

        private void gridViewDSHoaDon_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
    }
}
