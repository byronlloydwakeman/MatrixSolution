using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Converters
{
    public static class MatrixIndexConverter
    {
        public static int OldMatrixIndexToNewMatrixIndex(int columnIndex, int rowIndex, int numberOfColumns) //Private
        {
            return (numberOfColumns * rowIndex) + columnIndex;
        }
    }
}
