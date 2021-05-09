using MatrixExceptions;
using MatrixLibrary.Converters;
using MatrixLibrary.Operations;
using MatrixLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorLibrary;

namespace MatrixLibrary
{
    public class Matrix
    {
        private List<int> DataValues { get; set; } = new List<int>();
        public int NumberOfColumns { get; }
        public int NumberOfRows { get; }

        public Matrix(int NumberOfColumns, int NumberOfRows)
        {
            //Check Columns and Rows are valid
            if(!(MatrixInputValidation.IsNumberOfRowsValid(NumberOfRows)))
            {
                throw new InvalidNumberOfRowsException(NumberOfRows);
            }
            if(!(MatrixInputValidation.IsNumberOfColumnsValid(NumberOfColumns)))
            {
                throw new InvalidNumberOfColumnsException(NumberOfColumns);
            }

            this.NumberOfColumns = NumberOfColumns;
            this.NumberOfRows = NumberOfRows;
            SetupEmptyMatrix();
        }

        private void SetupEmptyMatrix()  //Private
        {
            //The number of elements should be the product of the NumberOfRows and NumberOfColumns
            for (int i = 0; i < (NumberOfRows * NumberOfColumns); i++)
            {
                DataValues.Add(0); //Add 0, effectively a null value
            }
        }

        public void EditMatrix(int ColumnIndex, int RowIndex, int NewValue)
        {
            //Check the column and row index values are within range
            if(!(MatrixIndexValidation.IsColumnInRange(ColumnIndex, NumberOfColumns)))
            {
                throw new ColumnIndexOutOfRangeException(ColumnIndex);
            }

            if(!(MatrixIndexValidation.IsRowInRange(RowIndex, NumberOfRows)))
            {
                throw new RowIndexOutOfRangeException(RowIndex);
            }

            //Find actual index
            int ActualIndex = MatrixIndexConverter.OldMatrixIndexToNewMatrixIndex(ColumnIndex, RowIndex, NumberOfColumns);
            DataValues[ActualIndex] = NewValue;
        }

        public void EditMatrix(int Index, int NewValue)
        {
            if (!MatrixIndexValidation.IsDataIndexInRange(Index, NumberOfColumns, NumberOfRows))
            {
                throw new IndexOutOfRangeException("Given index is out of bounds");
            }

            DataValues[Index] = NewValue;

        }
        
        public double FindDeterminant()
        {
            return Determinant.FindDeterminant(NumberOfColumns, NumberOfRows, DataValues);
        }

        public Matrix FindInverse()
        {
            Matrix ReturnMatrix = new Matrix(NumberOfColumns, NumberOfRows);
            double Determinant = FindDeterminant();

            //Loop through every element and find its matrix minor
            for (int cI = 0; cI < NumberOfColumns; cI++)
            {
                for (int rI = 0; rI < NumberOfRows; rI++)
                {
                    ReturnMatrix.DataValues[MatrixIndexConverter.OldMatrixIndexToNewMatrixIndex(cI, rI, NumberOfColumns)] = (int)MatrixMinor.FindMatrixMinor(cI, rI, NumberOfColumns, NumberOfRows, DataValues).FindDeterminant();
                }
            }

            //Find the cofactor of the matrix
            for (int i = 0; i < NumberOfColumns * NumberOfRows; i++)
            {
                if (i % 2 != 0)
                {
                    ReturnMatrix.DataValues[i] = ReturnMatrix.DataValues[i] * -1;
                }
            }

            //Find Transpose
            ReturnMatrix = ReturnMatrix.FindTranspose();

            return (int)(1 / Determinant) * ReturnMatrix;
        }

        public Matrix FindTranspose()
        {
             return Transpose.FindTranspose(NumberOfColumns, NumberOfRows, DataValues);
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
            if(!(MatrixArithmeticValidation.CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows)))
            {
                throw new BasicArithmeticDimensionException();
            }

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
            if(!(MatrixArithmeticValidation.CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows)))
            {
                throw new BasicArithmeticDimensionException();
            }

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
            if(!(MatrixArithmeticValidation.CanMatriciesBeMultiplied(m1.NumberOfRows, m2.NumberOfColumns)))
            {
                throw new MultiplicationDimensionException();
            }

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

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            //Check matricies are the same size
            if (!(MatrixArithmeticValidation.CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows)))
            {
                throw new BasicArithmeticDimensionException();
            }

            bool output = true;

            //Loop through data values if not equal then return false
            for (int i = 0; i < m1.DataValues.Count; i++)
            {
                if(!(m1.DataValues[i] == m2.DataValues[i]))
                {
                    output = false;
                }
            }

            return output;
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            //Check matricies are the same size
            if (!(MatrixArithmeticValidation.CanMatriciesPerformBasicArithmetic(m1.NumberOfColumns, m1.NumberOfRows, m2.NumberOfColumns, m2.NumberOfRows)))
            {
                throw new BasicArithmeticDimensionException();
            }

            bool output = false;

            //Loop through data values if not equal then return false
            for (int i = 0; i < m1.DataValues.Count; i++)
            {
                if(!(m1.DataValues[i] == m2.DataValues[i]))
                {
                    output = true;
                }
            }

            return output;
        }

        /// <summary>
        /// Converts a Vector Type to a Matrix Type
        /// </summary>
        public static explicit operator Matrix(Vector vector)
        {
            List<int> VectorDataValues = vector.ReturnDataValues();
            Matrix ReturnMatrix = new Matrix(1, VectorDataValues.Count);

            for (int i = 0; i < VectorDataValues.Count; i++)
            {
                ReturnMatrix.DataValues[i] = VectorDataValues[i];
            }

            return ReturnMatrix;
        }
    }
}
