using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public static class MatrixFactory
    {
        public static Matrix MatrixForTesting()
        {
            return new Matrix(2, 2);
        }

        public static Matrix GeneralMatrix(int Column, int Row)
        {
            return new Matrix(Column, Row);
        }

        public static Matrix IdentityMatrix(int size)
        {
            Matrix matrixModelForTesting = new Matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                matrixModelForTesting.EditMatrix(i, i, 1);
            }
            return matrixModelForTesting;
        }

        
    }
}
