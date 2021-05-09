using MatrixExceptions;
using MatrixLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Operations
{
    public static class Determinant
    {
        public static int Find2by2Determinant(int NumberOfRows, int NumberOfColumms, List<int> DataValues) //Private
        {
            //Make sure given matrix is 2by2
            if (!(MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumms)))
            {
                throw new DeterminantDimensionError("Could not perform 2by2 determinant as matrix was not 2by2");
            }

            return (DataValues[0] * DataValues[3]) - (DataValues[1] * DataValues[2]);
        }

        public static double FindDeterminant(int NumberOfColumns, int NumberOfRows, List<int> DataValues)
        {
            //If matrix is 1by1
            if (NumberOfColumns == 1)
            {
                return DataValues[0];
            }

            //If matrix is 2by2
            if (MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumns))
            {
                return Find2by2Determinant(NumberOfColumns, NumberOfRows, DataValues);
            }

            double sum = 0;

            //If not

            //Loop through columns
            for (int i = 0; i < NumberOfColumns; i++)
            {
                //Loop through each column and find the matrix minor for the first row
                int multiplier = i % 2 == 0 ? 1 : -1;

                sum += multiplier * DataValues[i] * MatrixMinor.FindMatrixMinor(i, 0, NumberOfColumns, NumberOfRows, DataValues).FindDeterminant();
            }

            return sum;
        }
    }
}
