using SquareMatrixMultiplyRecursive.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive
{
    public abstract class MatrixMultplyBase : IMatrixMultiply
    {
        public abstract int[,] Multiply(MatrixWrapper matrixA, MatrixWrapper matrixB);

        /// <summary>
        /// Add two matrix.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        public int[,] MatrixAdd(int[,] matrixA, int[,] matrixB)
        {
            if (!IsHomoMatrix(matrixA, matrixB))
            {
                throw new Exception("Matrix Add requires Homomorphic");
            }

            int[,] resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return resultMatrix;
        }

        /// <summary>
        /// copy a raw sourceMatrix to the specified part of Matrix.
        /// </summary>
        /// <param name="sourceMatrix"></param>
        /// <param name="toMatrix"></param>
        public void CopyTo(int[, ] sourceMatrix, MatrixWrapper toMatrix)
        {
            for (int i = 0; i < sourceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sourceMatrix.GetLength(1); j++)
                {
                    toMatrix[i, j] = sourceMatrix[i, j];
                }
            }
        }


        public static bool IsHomoMatrix(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {
            return matrixA.RowCount == matrixB.RowCount && matrixB.ColCount == matrixB.ColCount;
        }
        public static bool IsHomoMatrix(int[,] matrixA, int[,] matrixB)
        {
            return matrixA.GetLength(0) == matrixB.GetLength(0) && matrixA.GetLength(1) == matrixB.GetLength(1);
        }

        public static void PrintMatrix(int[,] matrixToPrint)
        {
            for (int i = 0; i < matrixToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToPrint.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0,-4}", matrixToPrint[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
