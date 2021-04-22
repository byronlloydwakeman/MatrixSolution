using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class RowIndexOutOfRangeException : Exception
    {
        public RowIndexOutOfRangeException()
        {

        }

        public RowIndexOutOfRangeException(int RowIndex) : base(String.Format($"Invalid column index {RowIndex}"))
        {

        }
    }
}
