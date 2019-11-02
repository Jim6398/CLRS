using SquareMatrixMultiplyRecursive.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixMultiplyRecursive
{
    /// <summary>
    /// this algorithem seems only support 2n * 2n matrix... 
    /// </summary>
    public class MatrixMultiplyStrassen : MatrixMultplyBase
    {
        public override int[,] Multiply(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {
           return MultiplyByStrassen(matrixA, matrixB);
        }

        private int[,] MultiplyByStrassen(MatrixWrapper matrixA, MatrixWrapper matrixB)
        {

            // if any of matrix cannot be divided any more. Just use normal Algorithem to do the calculation.
            if (matrixA.RowCount == 1 || matrixA.ColCount == 1
                || matrixB.RowCount == 1 || matrixB.ColCount == 1)
            {
                MatrixMultiplyNormal normalAlgorithem = new MatrixMultiplyNormal();
                return normalAlgorithem.Multiply(matrixA, matrixB);
            }

            // Step 1 Divide matrix.
            MatrixDivideResult matrixDividedA = new MatrixDivideResult(matrixA);
            MatrixDivideResult matrixDividedB = new MatrixDivideResult(matrixB);

            // step 2 create the 10 S matrixs.
            int[,] S1 = new int[matrixDividedA.A11.RowCount,matrixDividedA.A11.ColCount];
            int[,] S2 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S3 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S4 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S5 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S6 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S7 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S8 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S9 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            int[,] S10 = new int[matrixDividedA.A11.RowCount, matrixDividedA.A11.ColCount];
            S1 = MatrixSubtract(matrixDividedB.A12.ToRawMatrix(),matrixDividedB.A22.ToRawMatrix());
            S2 = MatrixAdd(matrixDividedA.A11.ToRawMatrix(), matrixDividedA.A12.ToRawMatrix());
            S3 = MatrixAdd(matrixDividedA.A21.ToRawMatrix(), matrixDividedA.A22.ToRawMatrix());
            S4 = MatrixSubtract(matrixDividedB.A21.ToRawMatrix(), matrixDividedB.A11.ToRawMatrix());
            S5 = MatrixAdd(matrixDividedA.A11.ToRawMatrix(), matrixDividedA.A22.ToRawMatrix());
            S6 = MatrixAdd(matrixDividedB.A11.ToRawMatrix(), matrixDividedB.A22.ToRawMatrix());
            S7 = MatrixSubtract(matrixDividedA.A12.ToRawMatrix(), matrixDividedA.A22.ToRawMatrix());
            S8 = MatrixAdd(matrixDividedB.A21.ToRawMatrix(), matrixDividedB.A22.ToRawMatrix());
            S9 = MatrixSubtract(matrixDividedA.A11.ToRawMatrix(), matrixDividedA.A21.ToRawMatrix());
            S10 = MatrixAdd(matrixDividedB.A11.ToRawMatrix(), matrixDividedB.A12.ToRawMatrix());

            // step3 call multiply Recursive.
            int[,] P1= MultiplyByStrassen(matrixDividedA.A11, new MatrixWrapper(S1));
            int[,] P2 = MultiplyByStrassen(new MatrixWrapper(S2), matrixDividedB.A22);
            int[,] P3 = MultiplyByStrassen(new MatrixWrapper(S3), matrixDividedB.A11);
            int[,] P4 = MultiplyByStrassen(matrixDividedA.A22, new MatrixWrapper(S4));
            int[,] P5 = MultiplyByStrassen(new MatrixWrapper(S5), new MatrixWrapper(S6));
            int[,] P6 = MultiplyByStrassen(new MatrixWrapper(S7), new MatrixWrapper(S8));
            int[,] P7 = MultiplyByStrassen(new MatrixWrapper(S9), new MatrixWrapper(S10));

            // step4 matrix add
            int[,] C11 = MatrixListAdd(new List<int[,]>() { P5, P4, MatrixMultiplyConst(P2, -1),P6 });
            int[,] C12 = MatrixAdd(P1, P2);
            int[,] C21 = MatrixAdd(P3, P4);
            int[,] C22 = MatrixListAdd(new List<int[,]>() { P5, P1, MatrixMultiplyConst(P3, -1), MatrixMultiplyConst(P7, -1) });
            int[,] resultRawMatrix = new int[matrixA.RowCount, matrixB.ColCount];
            // step5 merge all the partial matrix to a whole
            // 11
            this.CopyTo(C11, new MatrixWrapper(resultRawMatrix, 0, matrixDividedA.A11.RowCount - 1, 0, matrixDividedA.A11.ColCount - 1));
            // 12
            this.CopyTo(C12, new MatrixWrapper(resultRawMatrix, 0, matrixDividedA.A11.RowCount - 1, matrixDividedA.A11.ColCount, matrixDividedA.A11.ColCount + matrixDividedA.A12.ColCount - 1));
            // 21
            this.CopyTo(C21, new MatrixWrapper(resultRawMatrix, matrixDividedA.A11.RowCount, matrixDividedA.A11.RowCount + matrixDividedA.A21.RowCount - 1, 0, matrixDividedA.A11.ColCount - 1));
            // 22
            this.CopyTo(C22, new MatrixWrapper(resultRawMatrix, matrixDividedA.A11.RowCount, matrixDividedA.A11.RowCount + matrixDividedA.A21.RowCount - 1, matrixDividedA.A11.ColCount, matrixDividedA.A11.ColCount + matrixDividedA.A12.ColCount - 1));
            return resultRawMatrix;
        }


        
    }
}
