using MatrixLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixDeterminantValidationTests
    {
        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, false)]
        public void CanMatrixDeterminantBeFoundShouldWork(int NumberOfColumns, int NumberOfRows, bool Expected)
        {
            bool Actual = MatrixDeterminantValidation.CanMatrixDeterminantBeFound(NumberOfColumns, NumberOfRows);

            Assert.Equal(Expected, Actual);
        }
    }
}
