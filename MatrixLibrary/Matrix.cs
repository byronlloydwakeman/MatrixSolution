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
        private List<int> DataValues { get; set; } = new List<int>();
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

        public int Find2by2Determinant() //Private
        {
            //Make sure given matrix is 2by2
            IsMatrix2by2(NumberOfRows, NumberOfColumns);

            return (DataValues[0] * DataValues[3]) - (DataValues[1] * DataValues[2]);
        }

        /// <summary>
        /// Returns the matrix minor of this matrix
        /// </summary>
        public Matrix FindMatrixMinor(int ColumnIndex, int RowIndex)
        {
            //Create instance to return
            Matrix MatrixMinor = new Matrix(NumberOfColumns - 1, NumberOfRows - 1);

            int MatrixMinorCounter = 0;

            //Loop through rows
            for (int rI = 0; rI < NumberOfRows; rI++)
            {
                //Loop through columns
                for (int cI = 0; cI < NumberOfColumns; cI++)
                {
                    if ((cI == ColumnIndex) || (rI == RowIndex))
                    {
                        //Ignore
                    }
                    else
                    {
                        MatrixMinor.DataValues[MatrixMinorCounter] = DataValues[OldMatrixIndexToNewMatrixIndex(cI, rI)];
                        MatrixMinorCounter++;
                    }
                }
            }

            return MatrixMinor;
        }
        
        public int FindDeterminant()
        {
            //If matrix is 1by1
            if (NumberOfColumns == 1)
            {
                return DataValues[0];
            }

            //If matrix is 2by2
            if (NumberOfColumns == 2)
            {
                return this.Find2by2Determinant();
            }

            int sum = 0;

            //If not

            //Loop through columns
            for (int i = 0; i < NumberOfColumns; i++)
            {
                //Loop through each column and find the matrix minor for the first row
                int multiplier = i % 2 == 0 ? 1 : -1;

                sum += multiplier * DataValues[i] * FindMatrixMinor(i, 0).FindDeterminant();
            }

            return sum;
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
