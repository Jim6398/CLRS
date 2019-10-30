using SquareMatrixMultiplyRecursive.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive
{
    interface IMatrixMultiply
    {
        int[,] Multiply(MatrixWrapper matrixA, MatrixWrapper matrixB);
    }
}
