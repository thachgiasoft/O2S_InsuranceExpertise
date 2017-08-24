using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Server
{
    public class GlobalStore
    {
        public static TokenDTO tokenSession { get; set; }
        public static string UserName_GDBHYT {get;set;}
        public static string Password_GDBHYT { get; set; }
        public static string Password_GDBHYT_MD5 { get; set; }
        public static string MaTinh { get; set; }
        public static string MaCSKCB { get; set; }
        public static List<Model.Models.TheFileXMLDTO> lstTheFileXML1Global { get; set; }
        public static List<Model.Models.DanhMucDichVu_DVKTDTO> lstDVKTBenhVienPheDuyet { get; set; }
        public static List<Model.Models.DanhMucDichVu_ThuocDTO> lstThuocBenhVienPheDuyet { get; set; }
        public static List<Model.Models.DanhMucDichVu_VatTuDTO> lstVatTuBenhVienPheDuyet { get; set; }
        public static List<Model.Models.DanhMucDichVu_GiuongDTO> lstGiuongBenhVienPheDuyet { get; set; }

        //Chia 15 nhom tai bang 6: danh muc nhom theo chi phi
        public static List<Model.Models.DanhMucDichVu_ThuocDTO> lstThuocBenhVienPheDuyet_Nhom4 { get; set; }
        public static List<Model.Models.DanhMucDichVu_ThuocDTO> lstThuocBenhVienPheDuyet_Nhom6 { get; set; }
        public static List<Model.Models.DanhMucDichVu_DVKTDTO> lstDVKTBenhVienPheDuyet_Nhom1 { get; set; }
        public static List<Model.Models.DanhMucDichVu_DVKTDTO> lstDVKTBenhVienPheDuyet_Nhom2 { get; set; }

    }
}