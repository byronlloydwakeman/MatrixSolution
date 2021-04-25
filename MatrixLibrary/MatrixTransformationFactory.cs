using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class MatrixTransformationFactory
    {
        public static Matrix ReflectionInYAxis()
        {
            Matrix ReturnMatrix = MatrixFactory.IdentityMatrix(2);
            ReturnMatrix.EditMatrix(0, 0, -1);

            return ReturnMatrix;
        }

        public static Matrix ReflectionInXAxis()
        {
            Matrix ReturnMatrix = MatrixFactory.IdentityMatrix(2);
            ReturnMatrix.EditMatrix(1, 1, -1);

            return ReturnMatrix;
        }
    }
}
