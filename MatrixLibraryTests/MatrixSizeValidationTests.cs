using MatrixLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixSizeValidationTests
    {
        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, false)]
        public void IsMatrix2by2ShouldWork(int NumberOfRows, int NumberOfColumns, bool Expected)
        {
            bool Actual = MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumns);

            Assert.Equal(Expected, Actual);
        }
    }
}
