using MatrixLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests
{
    public class MatrixTypeValidationTests
    {
        [Theory]
        [InlineData(12, true)] //int
        [InlineData(12.0, true)] //double
        [InlineData(12L, true)] //64bit int
        public void IsIntegerShouldWork<T>(T genericType, bool Expected)
        {
            bool Actual = MatrixTypeValidation.IsInteger(genericType);

            Assert.Equal(Expected, Actual);
        }
    }
}
