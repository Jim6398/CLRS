using SquareMatrixMultiplyRecursive.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive
{
    public class MatrixMultiplyNormal : MatrixMultplyBase
    {
        public override int[,] Multiply(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {
            if (matrixA == null || matrixB == null)
            {
                return null;
            }
            if (matrixA.ColCount != matrixB.RowCount)
            {
                throw new Exception("matrix cannot multiply");
            }
            int row = matrixA.RowCount;
            int column = matrixB.ColCount;
            int kLength = matrixA.ColCount;

            int[,] resultMatrix = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < kLength; k++)
                    {
                        resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}
