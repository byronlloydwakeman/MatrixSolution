using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Validation
{
    public static class MatrixArithmeticValidation
    {
        public static bool CanMatriciesPerformBasicArithmetic(int ColumnNumber1, int ColumnNumber2, int RowNumber1, int RowNumber2) //Private
        {
            if (!((ColumnNumber1 == ColumnNumber2) && (RowNumber1 == RowNumber2)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CanMatriciesBeMultiplied(int RowNumber1, int ColumnNumber2) //Private
        {
            if (!(RowNumber1 == ColumnNumber2))
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
