using MatrixLibrary.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Operations
{
    public static class MatrixMinor
    {
        public static Matrix FindMatrixMinor(int ColumnIndex, int RowIndex, int NumberOfColumns, int NumberOfRows, List<int> DataValues) //Private
        {
            //Create instance to return
            Matrix MatrixMinor = new Matrix(NumberOfColumns - 1, NumberOfRows - 1);

            int MatrixMinorCounter = 0;

            //Loop through rows
            for (int rI = 0; rI < NumberOfRows; rI++)
            {
                //Loop through columns
                for (int cI = 0; cI < NumberOfColumns; cI++)
                {
                    if ((cI == ColumnIndex) || (rI == RowIndex))
                    {
                        //Ignore
                    }
                    else
                    {
                        //MatrixMinor.EditMatrix(MatrixMinorColumnCounter, MatrixMinorRowCounter, DataValues[MatrixIndexConverter.OldMatrixIndexToNewMatrixIndex(cI, rI, NumberOfColumns)]);
                        MatrixMinor.EditMatrix(MatrixMinorCounter, DataValues[MatrixIndexConverter.OldMatrixIndexToNewMatrixIndex(cI, rI, NumberOfColumns)]);
                        MatrixMinorCounter++;
                    }
                }
            }

            MatrixMinorCounter = 0; //reset its value

            return MatrixMinor;
        }
    }
}
