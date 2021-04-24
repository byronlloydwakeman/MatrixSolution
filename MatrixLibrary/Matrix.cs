using MatrixExceptions;
using MatrixLibrary.Helpers;
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

        private int OldMatrixIndexToNewMatrixIndex(int ColumnIndex, int RowIndex) //Private
        {
            return (NumberOfColumns * RowIndex) + ColumnIndex;
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
            int ActualIndex = OldMatrixIndexToNewMatrixIndex(ColumnIndex, RowIndex);
            DataValues[ActualIndex] = NewValue;
        }

        private int Find2by2Determinant() //Private
        {
            //Make sure given matrix is 2by2
            if(!(MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumns)))
            {
                throw new DeterminantDimensionError("Could not perform 2by2 determinant as matrix was not 2by2");
            }

            return (DataValues[0] * DataValues[3]) - (DataValues[1] * DataValues[2]);
        }

        private Matrix FindMatrixMinor(int ColumnIndex, int RowIndex) //Private
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

            MatrixMinorCounter = 0; //reset its value

            return MatrixMinor;
        }
        
        public double FindDeterminant()
        {
            //If matrix is 1by1
            if (NumberOfColumns == 1)
            {
                return DataValues[0];
            }

            //If matrix is 2by2
            if (MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumns))
            {
                return this.Find2by2Determinant();
            }

            double sum = 0;

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

        public async Task<double> FindAsyncDeterminant()
        {
            //If matrix is 1by1
            if (NumberOfColumns == 1)
            {
                return DataValues[0];
            }

            //If matrix is 2by2
            if (MatrixSizeValidation.IsMatrix2by2(NumberOfRows, NumberOfColumns))
            {
                return this.Find2by2Determinant();
            }

            List<Task<double>> ListOfTasks = new List<Task<double>>();

            //Add tasks to the list
            for (int i = 0; i < NumberOfColumns; i++)
            {
                ListOfTasks.Add(Task.Run(() => Math.Pow(-1, i) * FindMatrixMinor(i, 0).FindDeterminant()));
            }

            var result = await Task.WhenAll(ListOfTasks);

            double sum = 0;

            foreach (var item in result)
            {
                sum += item;
            }

            return sum;
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
                    ReturnMatrix.DataValues[OldMatrixIndexToNewMatrixIndex(cI, rI)] = (int)FindMatrixMinor(cI, rI).FindDeterminant();
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
            Matrix ReturnMatrix = new Matrix(NumberOfColumns, NumberOfRows);

            //Getting a list of all the columns
            List<List<int>> ListOfColumns = new List<List<int>>();

            for (int cI = 0; cI < NumberOfColumns; cI++)
            {
                //Add a new instance of a list
                ListOfColumns.Add(new List<int>());
                for (int rI = 0; rI < NumberOfRows; rI++) //Loop through the rows of a given column and add each value to the list
                {
                    ListOfColumns[cI].Add(DataValues[OldMatrixIndexToNewMatrixIndex(cI, rI)]);
                }
            }

            int IndexCounter = 0; 
            //Loop through the columns
            for (int i = 0; i < ListOfColumns.Count; i++)
            {
                for (int j = 0; j < ListOfColumns[i].Count; j++)
                {
                    ReturnMatrix.DataValues[IndexCounter] = ListOfColumns[i][j];
                    IndexCounter++;
                }
            }

            return ReturnMatrix;
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
