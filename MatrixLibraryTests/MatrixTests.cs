using MatrixExceptions;
using MatrixLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixTests
    {
        #region Version 1.0.0
        //[Theory]
        //[InlineData(1, true)]
        //[InlineData(0, true)]
        //[InlineData(2, false)]
        //public void ColumnIndexInRangeShouldWork(int ColumnIndex, bool Expected)
        //{
        //    //Note the matrix returned from the factory has 2 rows and 2 columns
        //    Matrix matrix = MatrixFactory.MatrixForTesting();
        //    bool Actual = matrix.ColumnIndexInRange(ColumnIndex);
        //    Assert.Equal(Expected, Actual);
        //}

        //[Theory]
        //[InlineData(0, true)]
        //[InlineData(1, true)]
        //[InlineData(2, false)]
        //public void RowIndexInRangeShouldWork(int RowIndex, bool Expected)
        //{
        //    //Note the matrix returned from the factory has 2 rows and 2 columns 
        //    Matrix matrix = MatrixFactory.MatrixForTesting();
        //    bool Actual = matrix.ColumnIndexInRange(RowIndex);
        //    Assert.Equal(Expected, Actual);
        //}

        //[Fact]
        //public void CheckIfMatrixDimensionsAreEqualShouldThrowException()
        //{
        //    Matrix matrix = new Matrix(3, 4);
        //    Matrix matrix2 = new Matrix(2, 1);

        //    Assert.Throws<BasicArithmeticDimensionException>(() => Matrix.CheckMatrixDimensionAreEqual(matrix.ColumnN, matrix2.ColumnN, matrix.RowN, matrix2.RowN));
        //}

        //[Fact]
        //public void CheckIfMatrixDimensionsAreEqualShouldNotThrowException()
        //{
        //    Matrix matrix = new Matrix(2, 2);
        //    Matrix matrix2 = new Matrix(2, 2);

        //    Matrix.CheckMatrixDimensionAreEqual(matrix.ColumnN, matrix2.ColumnN, matrix.RowN, matrix2.RowN);
        //}

        //[Fact]
        //public void CheckMatrixDimensionAreValidForMultiplicationShouldThrowException()
        //{
        //    Matrix matrix = new Matrix(3, 4);
        //    Matrix matrix2 = new Matrix(2, 1);

        //    Assert.Throws<BasicArithmeticDimensionException>(() => Matrix.CheckMatrixDimensionAreValidForMultiplication(matrix.ColumnN, matrix2.RowN));
        //}

        //[Fact]
        //public void CheckMatrixDimensionAreValidForMultiplicationShouldNotThrowException()
        //{
        //    Matrix matrix = new Matrix(2, 5);
        //    Matrix matrix2 = new Matrix(7, 2);

        //    Matrix.CheckMatrixDimensionAreValidForMultiplication(matrix.ColumnN, matrix2.RowN);
        //}
        #endregion
    }
}
