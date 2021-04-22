using MatrixExceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix
    {
        private List<int> DataValues { get; } = new List<int>();
        public int NumberOfColumns { get; }
        public int NumberOfRows { get; }

        public Matrix(int NumberOfColumns, int NumberOfRows)
        {
            this.NumberOfColumns = NumberOfColumns;
            this.NumberOfRows = NumberOfRows;
            SetupEmptyMatrix();
        }

        public void SetupEmptyMatrix()  //Private
        {
            //The number of elements should be the product of the NumberOfRows and NumberOfColumns
            for (int i = 0; i < (NumberOfRows * NumberOfRows); i++)
            {
                DataValues.Add(0); //Add 0, effectively a null value
            }
        }

        /// <summary>
        /// Returns the index required to access the data value from a single list
        /// </summary>
        /// <param name="ColumnIndex">The column index of the element we want</param>
        /// <param name="RowIndex">The row index of the element we want</param>
        /// <returns></returns>
        public int OldMatrixIndexToNewMatrixIndex(int ColumnIndex, int RowIndex) //Private
        {
            return (NumberOfColumns * RowIndex) + ColumnIndex;
        }

        /// <summary>
        /// As number of rows cant be negative or 0, we could also change this in the future to have a max limit
        /// </summary>
        public void IsNumberOfRowsValid(int NumberOfRows) //Private
        {
            if (NumberOfRows < 1)
            {
                throw new InvalidNumberOfRowsException(NumberOfRows);
            }
        }

        /// <summary>
        /// As number of columns can't be negative
        /// </summary>
        public void IsNumberOfColumnsValid(int NumberOfColumns) //Private
        {
            if (NumberOfColumns < 1)
            {
                throw new InvalidNumberOfColumnsException(NumberOfColumns);
            }
        }

        /// <summary>
        /// Throws an exception if the column index passed through isn't in range
        /// </summary>
        public void IsColumnInRange(int ColumnIndex) //Private
        {
            if ((ColumnIndex + 1) > NumberOfColumns || ColumnIndex < 0)
            {
                throw new ColumnIndexOutOfRangeException(ColumnIndex);
            }
        }

        /// <summary>
        /// Throws an exception if the row index passed through isnt in range
        /// </summary>
        public void IsRowInRange(int RowIndex) //Private
        {
            if ((RowIndex + 1) > NumberOfColumns || RowIndex < 0)
            {
                throw new RowIndexOutOfRangeException(RowIndex);
            }
        }

        /// <summary>
        /// Checks whether two matricies can perform basic arithmetic (addition, subtraction) passing the values through as their individual values as its more efficient than passing a
        /// reference type through
        /// </summary>
        public static void CanMatriciesPerformBasicArithmetic(int ColumnNumber1, int ColumnNumber2, int RowNumber1, int RowNumber2) //Private
        {
            if (!((ColumnNumber1 == ColumnNumber2) && (RowNumber1 == RowNumber2)))
            {
                throw new BasicArithmeticDimensionException();
            }
        }

        public static void CanMatriciesBeMultiplied(int RowNumber1, int ColumnNumber2) //Private
        {
            if (!(RowNumber1 == ColumnNumber2))
            {
                throw new MultiplicationDimensionError();
            }
        }

        public void EditMatrix(int ColumnIndex, int RowIndex, int NewValue)
        {
            //Check the column and row index values are within range
            IsColumnInRange(ColumnIndex);
            IsRowInRange(RowIndex);

            //Find actual index
            int ActualIndex = OldMatrixIndexToNewMatrixIndex(ColumnIndex, RowIndex);
            DataValues[ActualIndex] = NewValue;
        }

        public static void CanMatrixDeterminantBeFound(int NumberOfColumns, int NumberOfRows) //Private
        {
            if (NumberOfColumns != NumberOfRows)
            {
                throw new DeterminantDimensionError(NumberOfColumns, NumberOfRows);
            }
        }

        public static void IsMatrix2by2(int NumberOfRows, int NumberOfColumns) //Private
        {
            if ((NumberOfRows != 2) || (NumberOfColumns != 2))
            {
                throw new DeterminantDimensionError(NumberOfColumns, NumberOfRows);
            }
        }

        public static int Find2by2Determinant(Matrix m) //Private
        {
            //Make sure given matrix is 2by2
            IsMatrix2by2(m.NumberOfRows, m.NumberOfColumns);

            return (m.DataValues[0] * m.DataValues[3]) - (m.DataValues[1] * m.DataValues[2]);
        }

        public static void IsMatrix3by3(int NumberOfRows, int NumberOfColumns)
        {
            if ((NumberOfColumns != 3) || (NumberOfColumns != 3))
            {
                throw new DeterminantDimensionError(NumberOfColumns, NumberOfRows);
            }
        }

        public static int Find3by3Determinant(Matrix m)
        {
            IsMatrix3by3(m.NumberOfRows, m.NumberOfColumns);

            //Setup three matrix minors and pass them through to the find 2by2 determinant
            Matrix MatrixMinor1 = new Matrix(2, 2);
            MatrixMinor1.DataValues[0] = m.DataValues[4];
            MatrixMinor1.DataValues[1] = m.DataValues[5];
            MatrixMinor1.DataValues[2] = m.DataValues[7];
            MatrixMinor1.DataValues[3] = m.DataValues[8];

            Matrix MatrixMinor2 = new Matrix(2, 2);
            MatrixMinor2.DataValues[0] = m.DataValues[3];
            MatrixMinor2.DataValues[1] = m.DataValues[5];
            MatrixMinor2.DataValues[2] = m.DataValues[6];
            MatrixMinor2.DataValues[3] = m.DataValues[8];

            Matrix MatrixMinor3 = new Matrix(2, 2);
            MatrixMinor3.DataValues[0] = m.DataValues[3];
            MatrixMinor3.DataValues[1] = m.DataValues[4];
            MatrixMinor3.DataValues[2] = m.DataValues[6];
            MatrixMinor3.DataValues[3] = m.DataValues[7];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int a = m.DataValues[0] * Find2by2Determinant(MatrixMinor1);

            int b = m.DataValues[1] * Find2by2Determinant(MatrixMinor2);

            int c = m.DataValues[2] * Find2by2Determinant(MatrixMinor3);
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed : {stopwatch.ElapsedMilliseconds}");

            return a - b + c;
        }
        

        public override string ToString()
        {
            string StringToReturn = "";
            //Loop through each row and then print a new line then print the next row and so on...
            for (int i = 0; i < DataValues.Count; i++)
            {
                if (i % NumberOfColumns == 0)
                {
                    StringToReturn += $"\n{DataValues[i]} ";
                }
                else
                {
                    StringToReturn += $"{DataValues[i]} ";
                }
            }

            return StringToReturn;
        }


        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            //Check whether m1 and m2 are compatible to be added
            CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows);

            Matrix matrixToReturn = new Matrix(m1.NumberOfColumns, m1.NumberOfRows);

            //Add individual elements of each matrix at its respective index
            for (int i = 0; i < m1.DataValues.Count; i++)
            {
                matrixToReturn.DataValues[i] = m1.DataValues[i] + m2.DataValues[i];
            }

            return matrixToReturn;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            //Check whether m1 and m2 are compatible to be subtracted
            CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows);

            Matrix matrixToReturn = new Matrix(m1.NumberOfColumns, m1.NumberOfRows);

            //Add individual elements of each matrix at its respective index
            for (int i = 0; i < m1.DataValues.Count; i++)
            {
                matrixToReturn.DataValues[i] = m1.DataValues[i] - m2.DataValues[i];
            }

            return matrixToReturn;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix matrixToReturn = new Matrix(m2.NumberOfColumns, m1.NumberOfRows);
            //Check whether matricies can be multiplied
            CanMatriciesBeMultiplied(m1.NumberOfRows, m2.NumberOfColumns);

            int indexCounter = -1;
            //Loop through m1 rows
            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                //Loop through m2 columns
                for (int j = 0; j < m2.NumberOfColumns; j++)
                {
                    indexCounter += 1; //As the return matrix index is dependant on how many times we've looped through the m2 columns, so we have a counter to track that
                    int cellSumation = 0;
                    for (int k = 0; k < m1.NumberOfColumns; k++)
                    {
                        cellSumation += m1.DataValues[(m1.NumberOfColumns * i) + k] * m2.DataValues[((k * m2.NumberOfColumns) + j)];
                        matrixToReturn.DataValues[indexCounter] = cellSumation;
                    }
                }
            }
            return matrixToReturn;
        }

        public static Matrix operator *(int Multiplier, Matrix m1)
        {
            Matrix matrixToReturn = new Matrix(m1.NumberOfColumns, m1.NumberOfRows);
            for (int i = 0; i < m1.DataValues.Count; i++)
            {
                matrixToReturn.DataValues[i] = Multiplier * m1.DataValues[i];
            }

            return matrixToReturn;
        }
    }
}
