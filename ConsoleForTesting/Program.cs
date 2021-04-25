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
        static void Main(string[] args)
        {
            Matrix tranMatrix = MatrixTransformationFactory.ReflectionInXAxis();
            Console.WriteLine(tranMatrix);
            Console.WriteLine(tranMatrix.FindInverse());
            Console.WriteLine(tranMatrix.FindDeterminant());



            Console.ReadKey();
        }


    }
}
