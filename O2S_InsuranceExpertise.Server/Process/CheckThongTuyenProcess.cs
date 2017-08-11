using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Server.Process
{
    public class CheckThongTuyenProcess
    {
        internal List<LichSuKhamChuaBenhDTO> LayDSHosobenhanDaCheckThongTuyen(TieuChiCheckDTO filter)
        {
            List<LichSuKhamChuaBenhDTO> results = new List<LichSuKhamChuaBenhDTO>();
            try
            {
                LichSuKhamChuaBenhDTO lichsu = new LichSuKhamChuaBenhDTO();
                lichsu.maKetQua = "00";
                lichsu.tenKetQua = "Chinh xac";
                IEBhytCheckDTO _thongTinHoSo = new IEBhytCheckDTO();
                List<LichSuKCBDTO> _dsLichSuKCB = new List<LichSuKCBDTO>();


                //lichsu.thongTinHoSo = _thongTinHoSo;
                lichsu.dsLichSuKCB = _dsLichSuKCB;
                results.Add(lichsu);
            }
            catch (Exception)
            {
            }
            return results;
        }
    }
}