using MatrixLibrary;
using MatrixLibraryTests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleForTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Matrix matrix = new Matrix(8, 8);

            for (int i = 0; i < matrix.NumberOfColumns; i++)
            {
                for (int j = 0; j < matrix.NumberOfRows; j++)
                {
                    matrix.EditMatrix(i, j, 1);
                }
            }

            Console.WriteLine(matrix.ToString());

            //for (int i = 0; i < matrix.NumberOfColumns; i++)
            //{
            //    Console.WriteLine(matrix.FindMatrixMinor(i, 0));
            //}

            var watch = Stopwatch.StartNew();
            Console.WriteLine(matrix.FindDeterminant());
            //Console.WriteLine(matrix.FindInverse());
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            //var watch2 = Stopwatch.StartNew();
            //Console.WriteLine(await matrix.FindAsyncDeterminant());
            ////Console.WriteLine(matrix.FindInverse());
            //watch2.Stop();
            //Console.WriteLine(watch2.ElapsedMilliseconds);

            Console.ReadKey();
        }


    }
}
