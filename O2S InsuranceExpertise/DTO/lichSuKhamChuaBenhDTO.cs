﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.DTO
{
    public class lichSuKhamChuaBenhDTO
    {
        public string maKetQua { get; set; }
        public List<LichSuKCBDTO> dsLichSuKCB { get; set; }
    }

    public class LichSuKCBDTO
    {
        public string maHoSo { get; set; }
        public string maCSKCB { get; set; }
        public string tuNgay {get;set;}
        public string denNgay { get; set; }
        public string tenBenh { get; set; }
        public string tinhTrang { get; set; }
        public string kqDieuTri { get; set; }
    }
}
