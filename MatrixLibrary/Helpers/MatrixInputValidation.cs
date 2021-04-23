using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Helpers
{
    public class MatrixInputValidation
    {
        public static bool IsNumberOfRowsValid(int NumberOfRows) //Private
        {
            if (NumberOfRows < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsNumberOfColumnsValid(int NumberOfColumns) //Private
        {
            if (NumberOfColumns < 1)
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
