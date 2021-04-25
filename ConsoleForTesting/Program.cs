using MatrixLibrary;
using MatrixLibraryTests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VectorLibrary;

namespace ConsoleForTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Matrix matrix = MatrixFactory.IdentityMatrix(10);
            Console.WriteLine(matrix);
            var watch = Stopwatch.StartNew();
            Console.WriteLine(matrix.FindDeterminant());
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            matrix.EditMatrix(0, 0, "jello");
            Console.WriteLine(matrix);
            //Console.WriteLine(matrix.FindDeterminant());

            Console.ReadKey();
        }   


    }
}
