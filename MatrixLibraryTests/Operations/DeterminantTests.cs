using MatrixLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixLibraryTests.Operations
{
    public class DeterminantTests
    {
        [Fact]
        public void Find2by2DeterminantShouldWork()
        {
            List<int> DataValues = new List<int>()
            {
                1, 2, 3, 4
            };

            int Actual = Determinant.Find2by2Determinant(2, 2, DataValues);

            int Expected = -2;

            Assert.Equal(Expected, Actual);
        }

        [Fact]
        public void FindDeterminantShouldWork()
        {
            List<int> DataValues = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            double Actual = Determinant.FindDeterminant(3, 3, DataValues);

            double Expected = 0;

            Assert.Equal(Expected, Actual);
        }
    }
}
