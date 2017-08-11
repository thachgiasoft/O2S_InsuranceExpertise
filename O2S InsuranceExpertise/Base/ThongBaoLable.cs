﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Base
{
    public static class ThongBaoLable
    {
        internal static string THEM_MOI_THANH_CONG = "Thêm mới thành công!";
        internal static string SUA_THANH_CONG = "Sửa thành công!";
        internal static string IMPORT_TU_EXCEL_THANH_CONG = "Thêm mới từ excel thành công!";
        internal static string CO_LOI_XAY_RA = "Có lỗi xảy ra!";
        internal static string KHONG_THE_THUC_HIEN_DUOC = "Không thể thực hiện được!";
        internal static string KHONG_TIM_THAY_BAN_GHI_NAO = "Không tìm thấy bản ghi nào!";
        internal static string KHONG_CO_DU_LIEU = "Không có dữ liệu!";
        internal static string VIEN_PHI_DA_KHOA_KHONG_THE_THAO_TAC_DUOC = "Viện phí đã khóa, không thể thao tác được!";
        internal static string VIEN_PHI_DA_KHOA = "Viện phí đã khóa!";
        internal static string VUI_LONG_NHAP_DAY_DU_THONG_TIN = "Vui lòng nhập đầy đủ thông tin!";
        internal static string EXPORT_DU_LIEU_THANH_CONG = "Xuất dữ liệu thành công!";
        internal static string CAP_NHAT_THANH_CONG = "Cập nhật thành công!";
        internal static string CHUA_CHON_KHOA_PHONG = "Chưa chọn khoa/phòng!";
        internal static string CHUA_CHON_PHONG_THUC_HIEN = "Chưa chọn phòng thực hiện!";
        internal static string CHUA_CHON_KHO_TU_TRUC = "Chưa chọn kho/tủ trực!";
        internal static string THAO_TAC_THANH_CONG = "Thao tác thành công!";
        internal static string KHONG_TIM_THAY_TEMPLATE_BAO_CAO = "Không tìm thấy file template báo cáo!";
        internal static string HIEN_THI_DU_LIEU_THANH_CONG = "Hiển thị dữ liệu thành công!";
        internal static string CO_LOI_XAY_RA_KIEM_TRA_LAI_TEMPLATE = "Có lỗi xảy ra. Kiểm tra lại template!";
        internal static string CHUA_CHON_LOAI_BAO_CAO = "Chưa chọn loại báo cáo!";
        internal static string BENH_AN_DANG_MO = "Bệnh án đang mở!";
        internal static string MO_BENH_AN_THANH_CONG = "Mở bệnh án thành công!";
        internal static string BENH_NHAN_DA_DUYET_VIEN_PHI = "Bệnh nhân đã duyệt viện phí!";
        internal static string BENH_AN_DA_THANH_TOAN ="Bệnh án đã thanh toán!";
        internal static string BENH_NHAN_CHUA_DUYET_VIEN_PHI = "Bệnh nhân chưa duyệt viện phí!";
        internal static string CHUA_CHON_KHO_THUOC = "Chưa chọn kho thuốc!";
        internal static string CHUA_CHON_PHONG_LUU = "Chưa chọn phòng lưu!";
        internal static string CHUA_CHON_DOI_TUONG_BENH_NHAN = "Chưa chọn đối tượng bệnh nhân!";
        internal static string CHUA_CHON_TEMPLATE = "Chưa chọn template!";
        internal static string LUU_THANH_CONG = "Lưu thành công!";
        internal static string CHUA_CHON_LOAI_BENH_AN = "Chưa chọn loại bệnh án!";
        internal static string BENH_AN_DA_KET_THUC = "Bệnh án đã kết thúc!";
        internal static string BENH_NHAN_CHUA_DUOC_TIEP_NHAN_VAO_PHONG = "Bệnh nhân chưa được tiếp nhận vào phòng!";
        internal static string PHIEU_DUOC_TAO_BOI_KHOA_PHONG_KHAC = "Phiếu được tạo bởi khoa/phòng khác!";
        internal static string KHONG_THE_SU_DUNG_MA_NAY = "Không thể sử dụng mã này!";
        internal static string BENH_AN_DA_DUOC_TAO = "Bệnh án đã được tạo nên không thể sử dụng chức năng này!";
        internal static string XOA_THANH_CONG = "Xóa thành công!";


        internal static void HienThiThongBao(System.Windows.Forms.Timer timerThongBao, DevExpress.XtraEditors.LabelControl lblThongBao, string tenThongBao)
        {
            try
            {
                timerThongBao.Start();
                lblThongBao.Visible = true;
                lblThongBao.Text = tenThongBao;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
