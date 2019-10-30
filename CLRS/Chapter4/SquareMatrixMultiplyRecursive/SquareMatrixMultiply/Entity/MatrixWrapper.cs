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
    }
}
