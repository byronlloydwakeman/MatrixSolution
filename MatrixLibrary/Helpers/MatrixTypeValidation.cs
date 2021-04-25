using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Helpers
{
    public static class MatrixTypeValidation
    {
        public static bool IsInteger<T>(T genericType)
        {
            if((typeof(T) == typeof(Int16) ||
                (typeof(T) == typeof(Int32))) ||
                (typeof(T) == typeof(Int64)) ||
                (typeof(T) == typeof(UInt16)) ||
                (typeof(T) == typeof(UInt32)) ||
                (typeof(T) == typeof(UInt64)) ||
                (typeof(T) == typeof(int)) ||
                (typeof(T) == typeof(double)) ||
                (typeof(T) == typeof(long)) ||
                (typeof(T) == typeof(decimal)) ||
                (typeof(T) == typeof(float)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
