using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class DeterminantDimensionError : Exception
    {
        public DeterminantDimensionError(int NumberOfColumns, int NumberOfRows) : base(String.Format($"The determinant of this matrix could not be found due to its dimension R : {NumberOfRows}, C : {NumberOfColumns}"))
        {

        }

        public DeterminantDimensionError()
        {

        }
    }
}
