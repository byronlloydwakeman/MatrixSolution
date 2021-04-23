using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Helpers
{
    public static class MatrixIndexValidation
    {
        public static bool IsColumnInRange(int ColumnIndex, int NumberOfColumns) //Private
        {
            if ((ColumnIndex + 1) > NumberOfColumns || ColumnIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsRowInRange(int RowIndex, int NumberOfRows) //Private
        {
            if ((RowIndex + 1) > NumberOfRows || RowIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
