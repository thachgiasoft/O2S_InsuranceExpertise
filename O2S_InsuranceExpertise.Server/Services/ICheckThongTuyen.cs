using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Server.Services
{
    public interface ICheckThongTuyen
    {
        IEnumerable<LichSuKhamChuaBenhDTO> GetCheckListHosobenhan(TieuChiCheckDTO tieuchicheck);

    }

}
