using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class BasicArithmeticDimensionException : Exception
    {
        public BasicArithmeticDimensionException() : base(String.Format($"Unable to perform basic arithmetic as matrix dimensions aren't equal"))
        {

        }
    }
}
