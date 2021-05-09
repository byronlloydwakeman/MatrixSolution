using MatrixLibrary.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Operations
{
    public static class Transpose
    {
        public static Matrix FindTranspose(int NumberOfColumns, int NumberOfRows, List<int> DataValues)
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
                    ListOfColumns[cI].Add(DataValues[MatrixIndexConverter.OldMatrixIndexToNewMatrixIndex(cI, rI, NumberOfColumns)]);
                }
            }

            int IndexCounter = 0;
            //Loop through the columns
            for (int i = 0; i < ListOfColumns.Count; i++)
            {
                for (int j = 0; j < ListOfColumns[i].Count; j++)
                {
                    ReturnMatrix.EditMatrix(IndexCounter, ListOfColumns[i][j]);
                    IndexCounter++;
                }
            }

            return ReturnMatrix;
        }
    }
}
