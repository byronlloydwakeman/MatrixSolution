using MatrixLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixIndexValidationTests
    {
        [Theory]
        [InlineData(0, 2, true)]
        [InlineData(-1, 2, false)]
        [InlineData(3, 2, false)]
        public void IsColumnInRangeShouldWork(int ColumnIndex, int NumberOfColumns, bool Expected)
        {
            bool Actual = MatrixIndexValidation.IsColumnInRange(ColumnIndex, NumberOfColumns);

            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData(0, 2, true)]
        [InlineData(-1, 2, false)]
        [InlineData(3, 2, false)]
        public void IsRowInRangeShouldWork(int RowIndex, int NumberOfRows, bool Expected)
        {
            bool Actual = MatrixIndexValidation.IsRowInRange(RowIndex, NumberOfRows);

            Assert.Equal(Expected, Actual);
        }
    }
}
