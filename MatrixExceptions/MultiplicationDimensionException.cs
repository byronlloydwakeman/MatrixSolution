using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class MultiplicationDimensionException : Exception
    {
        public MultiplicationDimensionException() : base(String.Format($"These two given matricies cannot be multiplied due to their dimensions"))
        {

        }
    }
}
