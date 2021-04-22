using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class ColumnIndexOutOfRangeException : Exception
    {
        public ColumnIndexOutOfRangeException()
        {

        }

        public ColumnIndexOutOfRangeException(int ColumnIndex) : base(String.Format($"Invalid column index {ColumnIndex}"))
        {

        }
    }
}
