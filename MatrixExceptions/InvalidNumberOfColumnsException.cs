using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class InvalidNumberOfColumnsException : Exception
    {
        public InvalidNumberOfColumnsException()
        {

        }

        public InvalidNumberOfColumnsException(int NumberOfColumns) : base(String.Format($"Invalid number of columns : {NumberOfColumns}"))
        {

        }
    }
}
