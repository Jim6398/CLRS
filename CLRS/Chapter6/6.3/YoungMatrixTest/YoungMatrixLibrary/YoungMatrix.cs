using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungMatrixLibrary
{

    public class Position
    {
        private int rowLength;
        private int columnLength;

        public Position(int rowLength, int columnLength, int rowIndex, int columnIndex)
        {
            this.rowLength = rowLength;
            this.columnLength = columnLength;
            this._rowIndex = rowIndex;
            this._columnIndex = columnIndex;
        }

        private int _rowIndex;
        private int _columnIndex;

        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
        }

        public int ColumnIndex
        {
            get 
            {
                return _columnIndex;
            }
        }

        /// <summary>
        /// Get the next position.
        /// </summary>
        /// <returns></returns>
        public Position Next()
        {
            if (this.ColumnIndex == columnLength - 1 && this.RowIndex == rowLength - 1)
            {
                return null;
            }

            if (ColumnIndex == columnLength - 1)
            {
                return new Position(rowLength, columnLength, this.RowIndex + 1, 0);
            }
            else
            {
                return new Position(rowLength, columnLength, this.RowIndex, this.ColumnIndex + 1);
            }
        }


        public Position Right()
        {
            if (this.ColumnIndex == columnLength - 1)
            {
                return null;
            }

            return new Position(rowLength, columnLength, this.RowIndex, this.ColumnIndex + 1);
        }

        /// <summary>
        /// Get the Previous Element.
        /// </summary>
        /// <returns></returns>
        public Position Pre()
        {
            if (ColumnIndex == 0 && RowIndex == 0)
            {
                return null;
            }
            if (ColumnIndex == 0)
            {
                return new Position(rowLength, columnLength, this.RowIndex - 1, this.columnLength - 1);
            }
            else
            {
                return new Position(rowLength, columnLength, this.RowIndex, this.ColumnIndex - 1);
            }
        }

        public Position Down()
        {
            if (this.RowIndex == this.rowLength - 1)
            {
                return null;
            }

            return new Position(rowLength, columnLength, this.RowIndex + 1, this.ColumnIndex);
        }

        public Position Upper()
        {
            if (this.RowIndex == 0)
            {
                return null;
            }

            return new Position(rowLength, columnLength, this.RowIndex - 1, this.ColumnIndex);
        }
    }

    public class YoungMatrix
    {
        private int[,] insideArray = null;
        private Position currentPosition = null;
        public YoungMatrix(int[,] insideArray)
        {
            this.insideArray = insideArray;
            this.SetCurrentPosition();
            BuildYoungMatrixFromInputArray();
        }

        /// <summary>
        /// Check whether the input is an empty matrix.
        /// </summary>
        /// <returns></returns>
        public bool IsMatrixEmpty()
        {
            return currentPosition == null;
        }


        /// <summary>
        /// Get the position of last element.
        /// </summary>
        private void SetCurrentPosition()
        {
            if (insideArray[0, 0] == int.MaxValue)
            {
                currentPosition = null;
                return;
            }

            int i = 0;
            int j = 0;
            bool isBreak = false;
            for (i = 0; i < this.insideArray.GetLength(0); i++)
            {
                for (j = 0; j < this.insideArray.GetLength(1); j++)
                {
                    if (this.insideArray[i, j] == int.MaxValue)
                    {
                        isBreak = true;
                        break;
                    }
                }

                if (isBreak)
                {
                    break;
                }
            };           

            if (i == this.insideArray.GetLength(0) && j == this.insideArray.GetLength(1))
            {
                // The matrix is full of element.
                currentPosition = new Position(this.insideArray.GetLength(0), this.insideArray.GetLength(1), this.insideArray.GetLength(0) - 1, this.insideArray.GetLength(1)-1).Pre();
            }
            else
            {
                currentPosition = new Position(this.insideArray.GetLength(0), this.insideArray.GetLength(1), i, j).Pre();
            }
                       
        }

        private void  BuildYoungMatrixFromInputArray()
        {
            Position startPosition = currentPosition;
            while (startPosition != null)
            {
                Heapify(startPosition);
                startPosition = startPosition.Pre();
            }
        }

        private bool IsSpecifiedPositionValid(Position inputPosition, Position downPosition, Position rightPosition)
        {
            if (downPosition == null && rightPosition == null)
            {
                return true;
            }

            if(downPosition == null)
            {
                return this[inputPosition] <= this[rightPosition];
            }

            if (rightPosition == null)
            {
                return this[inputPosition] <= this[downPosition];
            }

            return (this[inputPosition] <= this[downPosition]) && (this[inputPosition] <= this[rightPosition]);
        }

        private void Heapify(Position position)
        {
            Position rightPosition = position.Right();
            Position downPosition = position.Down();
            while (position != null && !IsSpecifiedPositionValid(position, downPosition, rightPosition))
            {
                if (rightPosition != null
                    && downPosition != null
                    && this[position] > this[rightPosition]
                    && this[position] > this[downPosition])
                {
                    if (this[rightPosition] < this[downPosition])
                    {
                        Exchange(ref insideArray[position.RowIndex, position.ColumnIndex], ref insideArray[rightPosition.RowIndex, rightPosition.ColumnIndex]);
                        position = rightPosition;
                    }
                    else
                    {
                        Exchange(ref insideArray[position.RowIndex, position.ColumnIndex], ref insideArray[downPosition.RowIndex, downPosition.ColumnIndex]);
                        position = downPosition;
                    }
                }

                else if (rightPosition != null && this[position] > this[rightPosition])
                {
                    Exchange(ref insideArray[position.RowIndex, position.ColumnIndex], ref insideArray[rightPosition.RowIndex, rightPosition.ColumnIndex]);
                    position = rightPosition;
                }
                else 
                {
                    // if (downPosition !=null && this[position] > this[downPosition])
                    Exchange(ref insideArray[position.RowIndex, position.ColumnIndex], ref insideArray[downPosition.RowIndex, downPosition.ColumnIndex]);
                    position = downPosition;
                }

                rightPosition = position.Right();
                downPosition = position.Down();
            }
        }

        public int ColumnLength
        {
            get
            {
                return this.insideArray.GetLength(1);
            }
        }

        public int RowLength
        {
            get
            {
                return this.insideArray.GetLength(0);
            }
        }

        public int this[Position p]
        {
            get
            {
                if (p.RowIndex < this.RowLength && p.ColumnIndex < this.ColumnLength)
                {
                    return this.insideArray[p.RowIndex, p.ColumnIndex];
                }

                return int.MaxValue;
            }

            set
            {
                this.insideArray[p.RowIndex, p.ColumnIndex] = value;
            }
        }

        private static void Exchange(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
    }
}