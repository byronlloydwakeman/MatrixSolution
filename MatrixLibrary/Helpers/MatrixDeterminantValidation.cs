using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Helpers
{
    public static class MatrixDeterminantValidation
    {
        public static bool CanMatrixDeterminantBeFound(int NumberOfColumns, int NumberOfRows) //Private
        {
            if (NumberOfColumns != NumberOfRows)
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
