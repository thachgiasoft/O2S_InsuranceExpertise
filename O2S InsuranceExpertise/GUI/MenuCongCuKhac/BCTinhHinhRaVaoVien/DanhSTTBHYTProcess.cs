using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.GUI.MenuCongCuKhac
{
    internal static class DanhSTTBHYTProcess
    {
        private static DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        internal static void DanhSTTBHYT_TableBHYT()
        {
            try
            {
                //Lay danh sach can cap nhat STT
                string get_dscancapnhat = "SELECT bh.bhytid,to_char(bhytdate, 'yyyy') as year_bhytid FROM (select bhytid,bhytdate from bhyt where bhytcode<>'' and (stt_dkbhyt is null or stt_dkbhyt='')) bh inner join (select bhytid,vienphiid,vienphidate from vienphi where doituongbenhnhanid=1 and loaivienphiid=0 and vienphidate >= '2017-01-01 00:00:00') vp on vp.bhytid=bh.bhytid order by bh.bhytdate; ";
                DataTable datalstBhytId = condb.GetDataTable_HIS(get_dscancapnhat);
                if (datalstBhytId != null && datalstBhytId.Rows.Count > 0)
                {
                    for (int i = 0; i < datalstBhytId.Rows.Count; i++)
                    {
                        string bhytid = datalstBhytId.Rows[i]["bhytid"].ToString();
                        string year_bhytid = datalstBhytId.Rows[i]["year_bhytid"].ToString();

                        //Cap nhat STT BHYT vao bang BHYT
                        string sql_updateBhytId = "UPDATE bhyt SET stt_dkbhyt=to_char(bhytdate, 'yyyy') || '_' || (SELECT (MAX(cast(substr(stt_dkbhyt, 6, char_length(stt_dkbhyt)) as numeric))+1) as value_stt from bhyt where bhytcode<>'' and stt_dkbhyt is not null and substr(stt_dkbhyt, 6, char_length(stt_dkbhyt))<>'' and to_char(bhytdate, 'yyyy')='" + year_bhytid + "') WHERE bhytid='" + bhytid + "'; ";
                        condb.ExecuteNonQuery_HIS(sql_updateBhytId);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


    }
}
