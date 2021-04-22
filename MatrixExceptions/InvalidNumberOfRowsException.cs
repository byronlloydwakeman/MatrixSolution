using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    public class InvalidNumberOfRowsException : Exception
    {
        public InvalidNumberOfRowsException()
        {

        }

        public InvalidNumberOfRowsException(int NumberOfRows) : base(string.Format($"Invalid number of rows : {NumberOfRows}"))
        {

        }
    }
}
