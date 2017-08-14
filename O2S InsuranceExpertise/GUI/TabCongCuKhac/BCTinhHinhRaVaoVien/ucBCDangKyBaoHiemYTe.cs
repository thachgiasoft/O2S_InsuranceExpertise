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


namespace O2S_InsuranceExpertise.GUI.TabCongCuKhac
{
    public partial class ucBCDangKyBaoHiemYTe : UserControl
    {
        #region Declaration
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
       // private DataTable dataDanhBenhNhan { get; set; }
        #endregion

        #region Load
        public ucBCDangKyBaoHiemYTe()
        {
            InitializeComponent();
        }

        private void ucBangKeTongHopHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LoadDanhSachKhoa();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
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
                string tieuchi_hsba = "";
                string tieuchi_bhyt = "";
                string tieuchi_log = "";
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
                    orderby = " hsba.hosobenhandate ";
                }
                else if (cboTieuChi.Text == "Theo ngày ra viện")
                {
                    tieuchi_hsba = " where hosobenhandate_ravien between '" + tungay + "' and '" + denngay + "' ";
                    orderby = " hsba.hosobenhandate_ravien ";
                }
                else if (cboTieuChi.Text == "Theo ngày đăng ký thẻ")
                {
                    tieuchi_bhyt = " and bhytdate between '" + tungay + "' and '" + denngay + "' ";
                    tieuchi_log = " and logtime between '" + tungay + "' and '" + denngay + "' ";
                    orderby = " log.logtime ";
                }

                string sql_getdata = "SELECT row_number () over (order by " + orderby + ") as stt, hsba.patientid, log.vienphiid, hsba.sovaovien, '' as sodkbhyt, hsba.patientname, bh.bhytcode, bh.macskcbbd, bh.bhytfromdate, bh.bhytutildate, log.logeventcontent, bh.noisinhsong, (case when bh.du5nam6thangluongcoban=1 then 'OK' end) as du5nam6thangluongcoban, degp.departmentgroupname, '' as noichuyenden, hsba.hosobenhandate, (case when hsba.hosobenhandate_ravien<>'0001-01-01 00:00:00' then hsba.hosobenhandate_ravien end) as hosobenhandate_ravien, replace(log.logform, 'TAB:', '') as noidangky, (log.loguser || ' - ' || nv.username )as nguoidangky, (case bh.bhyt_loaiid when 1 then 'Đúng tuyến' when 2 then 'Đúng tuyến (giới thiệu)' when 3 then 'Đúng tuyến (cấp cứu)' when 4 then 'Trái tuyến' else '' end) as bhyt_loaiid, log.logeventtype, log.logtime FROM (select hosobenhanid,patientid,sovaovien,patientname,hosobenhandate,hosobenhandate_ravien from hosobenhan " + tieuchi_hsba + ") hsba inner join (select hosobenhanid,bhytcode,macskcbbd,bhytfromdate,bhytutildate,noisinhsong,du5nam6thangluongcoban,bhyt_loaiid from bhyt where bhytcode<>'' " + tieuchi_bhyt + ") bh on hsba.hosobenhanid=bh.hosobenhanid left join (select hosobenhanid,vienphiid,medicalrecordid,logeventcontent,logform,loguser,logeventtype,logtime from logevent where logeventtype in (1,8) " + tieuchi_log + ") log on log.hosobenhanid=hsba.hosobenhanid and log.logeventcontent like '%' || bh.bhytcode || '%' left join (select medicalrecordid,departmentgroupid,departmentid from medicalrecord ) mrd on mrd.medicalrecordid=log.medicalrecordid left join (select userhisid,usercode,username from nhompersonnel) nv on nv.usercode=log.loguser left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=mrd.departmentgroupid GROUP BY hsba.patientid,log.vienphiid,hsba.sovaovien,hsba.patientname,bh.bhytcode,bh.macskcbbd,bh.bhytfromdate,bh.bhytutildate,log.logeventcontent,bh.noisinhsong,bh.du5nam6thangluongcoban,degp.departmentgroupname,hsba.hosobenhandate,hsba.hosobenhandate_ravien,log.logform,log.loguser,nv.username,bh.bhyt_loaiid,log.logeventtype,log.logtime; ";

                DataTable dataDanhBenhNhan = condb.GetDataTable_HIS(sql_getdata);
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

                    thongTinThem.Add(reportitem);
                    string fileTemplatePath = "BC_DangKyBaoHiemYTe.xlsx";

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

                thongTinThem.Add(reportitem);
                string fileTemplatePath = "BC_DangKyBaoHiemYTe.xlsx";
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
