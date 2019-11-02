using SquareMatrixMultiplyRecursive.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive
{
   public class Program
    {
        public static void Main(string[] args)
        {
            int[,] matrixA = { { 1, 2,3,4 }, { 3, 4,5,6 }, { 6, 7, 8, 9 }, {6,1,8,4 } };
            int[,] matrixB = { { 4, 5,6,7 }, { 6, 7,8,9 } , { 3, 4, 5, 6 }, { 1, 2, 3, 4 } };
            MatrixWrapper mA = new MatrixWrapper(matrixA, 0, matrixA.GetLength(0) - 1,0, matrixA.GetLength(1) - 1);
            MatrixWrapper mB = new MatrixWrapper(matrixB, 0, matrixB.GetLength(0) - 1, 0, matrixB.GetLength(1) - 1);
            int[,] result = new MatrixMultiplyNormal().Multiply(mA, mB);
            MatrixMultplyBase.PrintMatrix(result);

            int[,] result2 = new MatrixMultiplyRecursive().Multiply(mA, mB);
            MatrixMultplyBase.PrintMatrix(result2);

            int[,] result3 = new MatrixMultiplyStrassen().Multiply(mA, mB);
            MatrixMultplyBase.PrintMatrix(result3);
        }
    }
}
