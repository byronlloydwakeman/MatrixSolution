using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Validation
{
    public static class MatrixSizeValidation
    {
        public static bool IsMatrix2by2(int NumberOfRows, int NumberOfColumns) //Private
        {
            if ((NumberOfRows != 2) || (NumberOfColumns != 2))
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
