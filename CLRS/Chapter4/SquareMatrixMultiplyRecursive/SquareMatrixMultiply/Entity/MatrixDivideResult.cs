using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive.Entity
{
    public class MatrixDivideResult
    {
        private MatrixWrapper inputMatrix;
        public MatrixDivideResult(MatrixWrapper inputMatrix)
        {
            this.inputMatrix = inputMatrix;
            Divide();
        }

        private void Divide()
        {
            int middleRowIndex = (inputMatrix.StartRow + inputMatrix.EndRow) / 2;
            int middleColIndex = (inputMatrix.StartCol + inputMatrix.EndCol) / 2;
            A11 = new MatrixWrapper() { 
                Matrix = this.inputMatrix.Matrix, 
                StartRow = this.inputMatrix.StartRow, 
                EndRow = middleRowIndex,
                StartCol = inputMatrix.StartCol,
                EndCol = middleColIndex
            };
            A12 = new MatrixWrapper() { 
                Matrix = this.inputMatrix.Matrix,
                StartRow = this.inputMatrix.StartRow,
                EndRow = middleRowIndex,
                StartCol = middleColIndex+1,
                EndCol = this.inputMatrix.EndCol
            };
            A21 = new MatrixWrapper()
            {
                Matrix = this.inputMatrix.Matrix,
                StartRow = middleRowIndex + 1,
                EndRow = this.inputMatrix.EndRow,
                StartCol = inputMatrix.StartCol,
                EndCol = middleColIndex
            };
            A22 = new MatrixWrapper()
            {
                Matrix = this.inputMatrix.Matrix,
                StartRow = middleRowIndex + 1,
                EndRow = this.inputMatrix.EndRow,
                StartCol = middleColIndex + 1,
                EndCol = this.inputMatrix.EndCol
            };
        }

       public MatrixWrapper A11
        { get; set; }
       public MatrixWrapper A12
        { get; set; }
       public MatrixWrapper A21
        { get; set; }
       public MatrixWrapper A22
        { get; set; }
    }
}
