﻿using O2S_InsuranceExpertise.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Base
{
    public class listChucNang
    {
        public static List<DTO.classPermission> getDanhSachChucNang()
        {
            List<DTO.classPermission> lstresult = new List<classPermission>();
            try
            {
                //permissiontype = 1 system
                //permissiontype = 2 Tools
                //permissiontype = 3 report
                //permissiontype = 4 phan quyen thao tac
                //permissiontype = 5 Dashboard
                //permissiontype = 10 Bao cao in ra

                //tabMenuId: // 1=Trang chu; 2=cau hinh; 3=giam dinh XML; 4=giam dinh hsba; 5=cong cu khac
                //System
                DTO.classPermission SYS_01 = new DTO.classPermission();
                SYS_01.permissioncheck = false;
                SYS_01.permissioncode = "SYS_01";
                SYS_01.permissionname = "Kết nối cơ sở dữ liệu";
                SYS_01.permissiontype = 1;
                SYS_01.tabMenuId = 1;
                SYS_01.permissionnote = "Kết nối cơ sở dữ liệu";
                lstresult.Add(SYS_01);

                DTO.classPermission SYS_02 = new DTO.classPermission();
                SYS_02.permissioncheck = false;
                SYS_02.permissioncode = "SYS_02";
                SYS_02.permissionname = "Quản lý người dùng";
                SYS_02.permissiontype = 1;
                SYS_02.tabMenuId = 1;
                SYS_02.permissionnote = "Quản lý người dùng";
                lstresult.Add(SYS_02);

                DTO.classPermission SYS_03 = new DTO.classPermission();
                SYS_03.permissioncheck = false;
                SYS_03.permissioncode = "SYS_03";
                SYS_03.permissionname = "Danh sách nhân viên";
                SYS_03.permissiontype = 1;
                SYS_03.tabMenuId = 1;
                SYS_03.permissionnote = "Danh sách nhân viên";
                lstresult.Add(SYS_03);

                DTO.classPermission SYS_04 = new DTO.classPermission();
                SYS_04.permissioncheck = false;
                SYS_04.permissioncode = "SYS_04";
                SYS_04.permissionname = "Danh sách tùy chọn";
                SYS_04.permissiontype = 1;
                SYS_04.tabMenuId = 1;
                SYS_04.permissionnote = "Danh sách tùy chọn";
                lstresult.Add(SYS_04);

                DTO.classPermission SYS_05 = new DTO.classPermission();
                SYS_05.permissioncheck = false;
                SYS_05.permissioncode = "SYS_05";
                SYS_05.permissionname = "Quản trị hệ thống";
                SYS_05.permissiontype = 1;
                SYS_05.tabMenuId = 1;
                SYS_05.permissionnote = "Quản trị hệ thống";
                lstresult.Add(SYS_05);

                //DTO.classPermission SYS_06 = new DTO.classPermission();
                //SYS_06.permissioncheck = false;
                //SYS_06.permissioncode = "SYS_06";
                //SYS_06.permissionname = "Danh mục dịch vụ PTTT";
                //SYS_06.permissiontype = 1;
                //SYS_06.permissionnote = "Danh mục dịch vụ PTTT";
                //lstresult.Add(SYS_06);

                //DTO.classPermission SYS_07 = new DTO.classPermission();
                //SYS_07.permissioncheck = false;
                //SYS_07.permissioncode = "SYS_07";
                //SYS_07.permissionname = "Danh mục bệnh án";
                //SYS_07.permissiontype = 1;
                //SYS_07.permissionnote = "Danh mục bệnh án";
                //lstresult.Add(SYS_07);

                //DTO.classPermission SYS_08 = new DTO.classPermission();
                //SYS_08.permissioncheck = false;
                //SYS_08.permissioncode = "SYS_08";
                //SYS_08.permissionname = "Danh mục hội chẩn thuốc *";
                //SYS_08.permissiontype = 1;
                //SYS_08.permissionnote = "Danh mục hội chẩn thuốc *";
                //lstresult.Add(SYS_08);

                //DTO.classPermission SYS_09 = new DTO.classPermission();
                //SYS_09.permissioncheck = false;
                //SYS_09.permissioncode = "SYS_09";
                //SYS_09.permissionname = "Danh mục hội chẩn PTTT";
                //SYS_09.permissiontype = 1;
                //SYS_09.permissionnote = "Danh mục hội chẩn PTTT";
                //lstresult.Add(SYS_09);

                //DTO.classPermission SYS_10 = new DTO.classPermission();
                //SYS_10.permissioncheck = false;
                //SYS_10.permissioncode = "SYS_10";
                //SYS_10.permissionname = "Danh mục hội chẩn chuyển viện";
                //SYS_10.permissiontype = 1;
                //SYS_10.permissionnote = "Danh mục hội chẩn chuyển viện";
                //lstresult.Add(SYS_10);

                DTO.classPermission SYS_11 = new DTO.classPermission();
                SYS_11.permissioncheck = false;
                SYS_11.permissioncode = "SYS_11";
                SYS_11.permissionname = "Danh mục dùng chung";
                SYS_11.permissiontype = 1;
                SYS_11.tabMenuId = 1;
                SYS_11.permissionnote = "Danh mục dùng chung";
                lstresult.Add(SYS_11);





                //Tools
                DTO.classPermission TOOL_01 = new DTO.classPermission();
                TOOL_01.permissioncheck = false;
                TOOL_01.permissioncode = "TOOL_01";
                TOOL_01.permissionname = "Cấu hình - Import danh mục";
                TOOL_01.permissiontype = 2;
                TOOL_01.tabMenuId = 2;
                TOOL_01.permissionnote = "Cấu hình - Import danh mục";
                lstresult.Add(TOOL_01);

                DTO.classPermission TOOL_02 = new DTO.classPermission();
                TOOL_02.permissioncheck = false;
                TOOL_02.permissioncode = "TOOL_02";
                TOOL_02.permissionname = "Cấu hình - Tiêu chí giám định";
                TOOL_02.permissiontype = 2;
                TOOL_02.tabMenuId = 2;
                TOOL_02.permissionnote = "Cấu hình - Tiêu chí giám định";
                lstresult.Add(TOOL_02);

                DTO.classPermission TOOL_03 = new DTO.classPermission();
                TOOL_03.permissioncheck = false;
                TOOL_03.permissioncode = "TOOL_03";
                TOOL_03.permissionname = "Cấu hình - Thẻ XML";
                TOOL_03.permissiontype = 2;
                TOOL_03.tabMenuId = 2;
                TOOL_03.permissionnote = "Cấu hình - Thẻ XML";
                lstresult.Add(TOOL_03);

                DTO.classPermission TOOL_04 = new DTO.classPermission();
                TOOL_04.permissioncheck = false;
                TOOL_04.permissioncode = "TOOL_04";
                TOOL_04.permissionname = "Giám định XML - Hiển thị dữ liệu";
                TOOL_04.permissiontype = 2;
                TOOL_04.tabMenuId = 3;
                TOOL_04.permissionnote = "Giám định XML - Hiển thị dữ liệu";
                lstresult.Add(TOOL_04);

                DTO.classPermission TOOL_05 = new DTO.classPermission();
                TOOL_05.permissioncheck = false;
                TOOL_05.permissioncode = "TOOL_05";
                TOOL_05.permissionname = "Giám định XML - Kiểm tra lỗi";
                TOOL_05.permissiontype = 2;
                TOOL_05.tabMenuId = 3;
                TOOL_05.permissionnote = "Giám định XML - Kiểm tra lỗi";
                lstresult.Add(TOOL_05);

                DTO.classPermission TOOL_06 = new DTO.classPermission();
                TOOL_06.permissioncheck = false;
                TOOL_06.permissioncode = "TOOL_06";
                TOOL_06.permissionname = "Giám định HSBA - Hiển thị dữ liệu";
                TOOL_06.permissiontype = 2;
                TOOL_06.tabMenuId = 4;
                TOOL_06.permissionnote = "Giám định HSBA - Hiển thị dữ liệu";
                lstresult.Add(TOOL_06);

                DTO.classPermission TOOL_10 = new DTO.classPermission();
                TOOL_10.permissioncheck = false;
                TOOL_10.permissioncode = "TOOL_10";
                TOOL_10.permissionname = "Công cụ khác - Kiểm tra thông tuyến";
                TOOL_10.permissiontype = 2;
                TOOL_10.tabMenuId = 5;
                TOOL_10.permissionnote = "Công cụ khác - Kiểm tra thông tuyến";
                lstresult.Add(TOOL_10);


                //report
                //DTO.classPermission REPORT_01 = new DTO.classPermission();
                //REPORT_01.permissioncheck = false;
                //REPORT_01.permissioncode = "REPORT_01";
                //REPORT_01.permissionname = "BC danh sách BN sử dụng dịch vụ...";
                //REPORT_01.permissiontype = 3;
                //REPORT_01.permissionnote = "BC danh sách BN sử dụng dịch vụ...";
                //lstresult.Add(REPORT_01);

                //DTO.classPermission REPORT_02 = new DTO.classPermission();
                //REPORT_02.permissioncheck = false;
                //REPORT_02.permissioncode = "REPORT_02";
                //REPORT_02.permissionname = "Thống kê bệnh theo ICD10";
                //REPORT_02.permissiontype = 3;
                //REPORT_02.permissionnote = "Thống kê bệnh theo ICD10";
                //lstresult.Add(REPORT_02);






                //Dashboard
                //DTO.classPermission DASHBOARD_01 = new DTO.classPermission();
                //DASHBOARD_01.permissioncheck = false;
                //DASHBOARD_01.permissioncode = "DASHBOARD_01";
                //DASHBOARD_01.permissionname = "Dashboard BC quản lý tổng thể khoa";
                //DASHBOARD_01.permissiontype = 5;
                //DASHBOARD_01.permissionnote = "Dashboard BC quản lý tổng thể khoa. \n Lấy theo tiêu chí thời gian duyệt viện phí; doanh thu chia theo khoa/phòng bệnh nhân ra viện";
                //lstresult.Add(DASHBOARD_01);

                //DTO.classPermission DASHBOARD_02 = new DTO.classPermission();
                //DASHBOARD_02.permissioncheck = false;
                //DASHBOARD_02.permissioncode = "DASHBOARD_02";
                //DASHBOARD_02.permissionname = "Dashboard BC bệnh nhân nội trú";
                //DASHBOARD_02.permissiontype = 5;
                //DASHBOARD_02.permissionnote = "Dashboard BC bệnh nhân nội trú. \n Lấy theo tiêu chí thời gian duyệt viện phí; doanh thu chia theo khoa/phòng bệnh nhân ra viện";
                //lstresult.Add(DASHBOARD_02);



                //Bao cao in ra
                //DTO.classPermission BAOCAO_001 = new DTO.classPermission();
                //BAOCAO_001.permissioncheck = false;
                //BAOCAO_001.permissioncode = "BAOCAO_001";
                //BAOCAO_001.permissionname = "Báo cáo Phẫu thuật - Khoa Gây mê hồi tỉnh";
                //BAOCAO_001.permissiontype = 10;
                //BAOCAO_001.permissionnote = "Báo cáo Phẫu thuật - Khoa Gây mê hồi tỉnh";
                //lstresult.Add(BAOCAO_001);

                //DTO.classPermission BAOCAO_002 = new DTO.classPermission();
                //BAOCAO_002.permissioncheck = false;
                //BAOCAO_002.permissioncode = "BAOCAO_002";
                //BAOCAO_002.permissionname = "Báo cáo Phẫu thuật - Khoa Tai mũi họng";
                //BAOCAO_002.permissiontype = 10;
                //BAOCAO_002.permissionnote = "Báo cáo Phẫu thuật - Khoa Tai mũi họng";
                //lstresult.Add(BAOCAO_002);


            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Error(ex);
            }
            return lstresult;
        }
    }
}
