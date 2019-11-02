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
            A11 = new MatrixWrapper(this.inputMatrix.Matrix, this.inputMatrix.StartRow, middleRowIndex, inputMatrix.StartCol, middleColIndex);
            A12 = new MatrixWrapper(this.inputMatrix.Matrix, this.inputMatrix.StartRow, middleRowIndex, middleColIndex + 1, this.inputMatrix.EndCol);
            A21 = new MatrixWrapper(this.inputMatrix.Matrix, middleRowIndex + 1, this.inputMatrix.EndRow, inputMatrix.StartCol, middleColIndex);
            A22 = new MatrixWrapper(this.inputMatrix.Matrix, middleRowIndex + 1, this.inputMatrix.EndRow, middleColIndex + 1, this.inputMatrix.EndCol);
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
