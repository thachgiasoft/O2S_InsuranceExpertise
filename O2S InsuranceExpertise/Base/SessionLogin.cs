﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using System.Diagnostics;


namespace O2S_InsuranceExpertise.Base
{
    /// <summary>
    /// Clast lưu biến tên user đăng nhập hệ thống để sử dụng cho mọi nơi trong chương trình
    /// </summary>
    public static class SessionLogin
    {
        public static long SessionUserID { get; set; }  // ID user
        public static string SessionUsercode { get; set; }  // code user
        public static string SessionUsername { get; set; }  // Tên user
        public static string SessionMachineName { get; set; }   // Tên máy
        public static string SessionMyIP { get; set; }  // Địa chỉ IP máy
        public static string SessionVersion { get; set; } // Version phần mềm
        public static bool KiemTraLicenseSuDung { get; set; } //kiem tra license: neu false thi out phan mem, neu true thi cho su dung tiep
        public static string License_KeyDB { get; set; } //License lay tu DB
        public static string MaDatabase { get; set; }//Lay thong tin database
        public static string UserName_GDBHYT { get; set; }//username dang nhap cong BHYT
        public static string Password_GDBHYT { get; set; }//pass dang nhap cong BHYT
        public static string Password_GDBHYT_MD5 { get; set; }
        public static string UrlFullServer { get; set; }


        public static List<DTO.classPermission> SessionLstPhanQuyenNguoiDung { get; set; }
        public static List<DTO.classUserDepartment> SessionlstPhanQuyen_KhoaPhong { get; set; }
        //public static List<DTO.classPermission> SessionLstPhanQuyen_ChucNang { get; set; }
        //public static List<DTO.classPermission> SessionLstPhanQuyen_Report { get; set; }
        //public static List<DTO.classPermission> SessionLstPhanQuyen_Dashboard { get; set; }
        //public static List<DTO.classPermission> SessionLstPhanQuyen_BaoCao { get; set; }
        //public static List<DTO.classUserMedicineStore> SessionLstPhanQuyen_KhoThuoc { get; set; }
        //public static List<DTO.classUserMedicinePhongLuu> SessionLstPhanQuyen_PhongLuu { get; set; }
    }


}

