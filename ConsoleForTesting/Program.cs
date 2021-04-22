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

            for (int i = 0; i < matrix.NumberOfColumns; i++)
            {
                for (int j = 0; j < matrix.NumberOfRows; j++)
                {
                    matrix.EditMatrix(i, j, i * j);
                }
            }

            Console.WriteLine(matrix.ToString());

            for (int i = 0; i < matrix.NumberOfColumns; i++)
            {
                Console.WriteLine(matrix.FindMatrixMinor(i, 0));
            }

            Console.ReadKey();
        }


    }
}
