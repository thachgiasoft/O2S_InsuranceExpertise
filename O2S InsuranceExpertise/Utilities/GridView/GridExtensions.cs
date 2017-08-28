using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Utilities.GridView
{
    public static class GridExtensions
    {
        public static int GetRowGroupIndexByRowHandle(this DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            int parentRowHandle = view.GetParentRowHandle(rowHandle);
            int childCount = view.GetChildRowCount(parentRowHandle);
            int lastRowHandle = view.GetChildRowHandle(parentRowHandle, childCount - 1);
            return (childCount - 1) - Math.Abs(lastRowHandle - rowHandle);
        }
    }
}
