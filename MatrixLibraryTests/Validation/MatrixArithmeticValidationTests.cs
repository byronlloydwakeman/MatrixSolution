using MatrixLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests.Validation
{
    public class MatrixArithmeticValidationTests
    {
        [Theory]
        [InlineData(1, 1, 2, 2, true)]
        [InlineData(1, 2, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 1, 1, 2, false)]
        public void CanMatriciesPerformBasicArithmeticShouldWork(int ColumnNumber1, int ColumnNumber2, int RowNumber1, int RowNumber2, bool Expected)
        {
            bool Actual = MatrixArithmeticValidation.CanMatriciesPerformBasicArithmetic(ColumnNumber1, ColumnNumber2, RowNumber1, RowNumber2);

            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, false)]
        public void CanMatriciesBeMultipliedShouldWork(int RowNumber1, int ColumnNumber2, bool Expected)
        {
            bool Actual = MatrixArithmeticValidation.CanMatriciesBeMultiplied(RowNumber1, ColumnNumber2);

            Assert.Equal(Expected, Actual);
        }
    }
}
