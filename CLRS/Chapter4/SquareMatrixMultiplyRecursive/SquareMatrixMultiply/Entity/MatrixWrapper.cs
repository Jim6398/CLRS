using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive.Entity
{
    public class MatrixWrapper
    {
        int startCol, endCol;
        int startRow, endRow;
        public int[,] Matrix
        { get; set; }


        public MatrixWrapper(int[,] inputMatrix)
        {
            this.Matrix = inputMatrix;
            this.startRow = 0;
            this.endRow = inputMatrix.GetLength(0) - 1;
            this.startCol = 0;
            this.endCol = inputMatrix.GetLength(1) - 1;
        }

        public MatrixWrapper(int[,] inpuMatrix, int startRow, int endRow, int startCol, int endCol)
        {
            this.Matrix = inpuMatrix;
            this.startRow = startRow;
            this.endRow = endRow;
            this.startCol = startCol;
            this.endCol = endCol;
        }

        public int ColCount
        {
            get 
            {
                return endCol - startCol + 1;
            }
        }

        public int RowCount
        {
            get { return endRow - startRow + 1; }
        }

        public int this[int Row, int Col]
        {
            get{
                return this.Matrix[this.startRow + Row, this.startCol + Col];
            }
            set
            {
                this.Matrix[this.startRow + Row, this.startCol + Col] = value;
            }

        }

        public int StartCol { get => startCol; set => startCol = value; }
        public int EndCol { get => endCol; set => endCol = value; }
        public int StartRow { get => startRow; set => startRow = value; }
        public int EndRow { get => endRow; set => endRow = value; }

        public int[,] ToRawMatrix()
        {
            int[,] resultRawMatrix = new int[this.RowCount, this.ColCount];
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColCount; j++)
                {
                    resultRawMatrix[i, j] = this[i, j];
                }
            }
            return resultRawMatrix;
        }
    }
}
