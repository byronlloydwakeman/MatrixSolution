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
            MatrixModelForTesting matrixModelForTesting = new MatrixModelForTesting(5, 5);

            for (int i = 0; i < matrixModelForTesting.NumberOfColumns; i++)
            {
                for (int j = 0; j < matrixModelForTesting.NumberOfRows; j++)
                {
                    if (i == j)
                    {
                        matrixModelForTesting.EditMatrix(i, j, 1);
                    }
                }
            }

            Console.WriteLine(matrixModelForTesting.ToString());

            Console.WriteLine(matrixModelForTesting.Determinant());

            Console.ReadKey();
        }


    }
}
