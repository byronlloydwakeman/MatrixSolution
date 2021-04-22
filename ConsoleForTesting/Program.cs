using MatrixLibrary;
using MatrixLibraryTests;
using System;
using System.Collections.Generic;

namespace ConsoleForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 3);

            matrix.EditMatrix(0, 0, 4);
            matrix.EditMatrix(1, 0, 3);
            matrix.EditMatrix(2, 0, -1);
            matrix.EditMatrix(0, 1, 2);
            matrix.EditMatrix(1, 1, -2);
            matrix.EditMatrix(2, 1, 0);
            matrix.EditMatrix(0, 2, 0);
            matrix.EditMatrix(1, 2, 4);
            matrix.EditMatrix(2, 2, -2);

            Console.WriteLine(matrix.ToString());

            //for (int i = 0; i < matrix.NumberOfColumns; i++)
            //{
            //    Console.WriteLine(matrix.FindMatrixMinor(i, 0));
            //}

            Console.WriteLine(matrix.FindDeterminant());



            Console.ReadKey();
        }


    }
}
