using MatrixLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixInputValidationTests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsNumberOfRowsValidShouldWork(int NumberOfRows, bool Expected)
        {
            bool Actual = MatrixInputValidation.IsNumberOfRowsValid(NumberOfRows);

            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsNumberOfColumnsValidShouldWork(int NumberOfColumns, bool Expected)
        {
            bool Actual = MatrixInputValidation.IsNumberOfColumnsValid(NumberOfColumns);

            Assert.Equal(Expected, Actual);
        }
    }
}
