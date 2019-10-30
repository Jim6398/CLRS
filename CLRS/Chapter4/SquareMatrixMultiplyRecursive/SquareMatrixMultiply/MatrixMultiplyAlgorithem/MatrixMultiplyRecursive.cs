using SquareMatrixMultiplyRecursive.Entity;
using System;

namespace SquareMatrixMultiplyRecursive
{
    public class MatrixMultiplyRecursive : MatrixMultplyBase
    {
        public override int[,] Multiply(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {
           return MatrixMultipleByRecursive(matrixA, matrixB);
        }

        private int[,] MatrixMultipleByRecursive(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {
            if (matrixA.ColCount != matrixB.RowCount)
            {
                throw new Exception($"cannot multiply two matrix. MatrixA column:{matrixA.ColCount} MatrixB Row: {matrixB.RowCount}");
            }

            // if any of matrix cannot be divided any more. Just use normal Algorithem to do the calculation.
            if (matrixA.RowCount == 1 || matrixA.ColCount == 1
                || matrixB.RowCount == 1 || matrixB.ColCount == 1)
            {
                MatrixMultiplyNormal normalAlgorithem = new MatrixMultiplyNormal();
                return normalAlgorithem.Multiply(matrixA, matrixB);
            }

            int[,] resultRawMatrix = new int[matrixA.RowCount, matrixB.ColCount];
            MatrixDivideResult dividedMatrixA = new MatrixDivideResult(matrixA);
            MatrixDivideResult dividedMatrixB = new MatrixDivideResult(matrixB);
            // 11
            this.CopyTo(this.MatrixAdd(MatrixMultipleByRecursive(dividedMatrixA.A11, dividedMatrixB.A11), MatrixMultipleByRecursive(dividedMatrixA.A12, dividedMatrixB.A21))
                , new MatrixWrapper() { Matrix = resultRawMatrix,
                    StartRow = 0,
                    EndRow = 0 + dividedMatrixA.A11.RowCount - 1, 
                    StartCol = 0, 
                    EndCol = 0 + dividedMatrixA.A11.ColCount - 1
                });
            // 12
            this.CopyTo(this.MatrixAdd(MatrixMultipleByRecursive(dividedMatrixA.A11, dividedMatrixB.A12), MatrixMultipleByRecursive(dividedMatrixA.A12, dividedMatrixB.A22))
    , new MatrixWrapper()
    {
        Matrix = resultRawMatrix,
        StartRow = 0,
        EndRow = 0 + dividedMatrixA.A11.RowCount - 1,
        StartCol = dividedMatrixA.A11.ColCount,
        EndCol = dividedMatrixA.A11.ColCount + dividedMatrixA.A12.ColCount - 1
    }) ;
            // 21
            this.CopyTo(this.MatrixAdd(MatrixMultipleByRecursive(dividedMatrixA.A21, dividedMatrixB.A11), MatrixMultipleByRecursive(dividedMatrixA.A22, dividedMatrixB.A21))
    , new MatrixWrapper()
    {
        Matrix = resultRawMatrix,
        StartRow = dividedMatrixA.A11.RowCount,
        EndRow = dividedMatrixA.A11.RowCount + dividedMatrixA.A21.RowCount - 1,
        StartCol = 0,
        EndCol = 0 + dividedMatrixA.A11.ColCount - 1
    });

            // 22
            this.CopyTo(this.MatrixAdd(MatrixMultipleByRecursive(dividedMatrixA.A21, dividedMatrixB.A12), MatrixMultipleByRecursive(dividedMatrixA.A22, dividedMatrixB.A22))
    , new MatrixWrapper()
    {
        Matrix = resultRawMatrix,
        StartRow = dividedMatrixA.A11.RowCount,
        EndRow = dividedMatrixA.A11.RowCount + dividedMatrixA.A21.RowCount - 1,
        StartCol = dividedMatrixA.A11.ColCount,
        EndCol = dividedMatrixA.A11.ColCount + dividedMatrixA.A12.ColCount - 1
    });
            return resultRawMatrix;
        }
    }
}
