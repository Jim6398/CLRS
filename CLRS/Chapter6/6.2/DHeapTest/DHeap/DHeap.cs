using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class ChildrenRange
    { 
        public int FromIndex { get; set; }

        public int ToIndex { get; set; }

        public bool IsEmptyChildren
        {
            get 
            {
                return FromIndex == -1;
            }
        }
    }
    public class DHeap
    {
        private int ChildrenCount;
        private int[] insideArray = new int[1024];

        private int _heapSize;

        /// <summary>
        /// Childcount is d for a d fork heap.
        /// </summary>
        /// <param name="childCount"></param>
        public DHeap(int childCount)
        {
            this.ChildrenCount = childCount;
        }


        /// <summary>
        /// Build n heap with an array. 
        /// </summary>
        /// <param name="intputArray"></param>
        /// <param name="childCount"></param>
        public DHeap(int[] intputArray, int childCount):this(childCount)
        {
            intputArray.CopyTo(insideArray, 0);
            this._heapSize = intputArray.Length;

            for (int i = this.HeapSize / 2; i >= 0; i--)
            {
                this.Heapfy(i);
            }
        }

        public int HeapSize { get => _heapSize; }

        private void ExchangeValue(ref int left,ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }


        public int Heap_Extract_Max()
        {
            int topValue = insideArray[0];
            insideArray[0] = insideArray[this.HeapSize - 1];
            this._heapSize--;
            Heapfy(0);
            return topValue;
        }

        public void Heapfy(int index)
        {
            int i = index;

            while (HasChildren(i))
            {
                int indexOfMaxChildren = FindIndexOfMaxChildren(i);
                if (insideArray[i] < insideArray[indexOfMaxChildren])
                {
                    ExchangeValue(ref insideArray[i], ref insideArray[indexOfMaxChildren]);
                    i = indexOfMaxChildren;
                }
                else
                {
                    break;
                }
            }
        }

        public int FindIndexOfMaxChildren(int index)
        {
            int maxValue = int.MinValue;
            int indexOfMaxChild = -1;
            ChildrenRange range = GetChildIndex(index);
            for (int i = range.FromIndex; i <= range.ToIndex; i++)
            {
                if (this.insideArray[i] > maxValue)
                {
                    maxValue = this.insideArray[i];
                    indexOfMaxChild = i;
                }
            }

            return indexOfMaxChild;
        }

        /// <summary>
        /// check if a node has children
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool HasChildren(int index)
        {
            return index * this.ChildrenCount + 1 < this.HeapSize;
        }

        /// <summary>
        /// put the From and To index to range class. The FromIndex should remain -1 when it is leaf node.
        /// </summary>
        /// <param name="rootIndex"></param>
        /// <param name="range"></param>
        public ChildrenRange GetChildIndex(int rootIndex)
        {
            ChildrenRange range = new ChildrenRange();
            range.FromIndex = -1;
            range.ToIndex = -1;

            for (int j = rootIndex * this.ChildrenCount + 1; j <= rootIndex * this.ChildrenCount + this.ChildrenCount; j++)
            {
                if (j >= this.HeapSize)
                {
                    break;
                }

                if (j == rootIndex * this.ChildrenCount + 1)
                {
                    range.FromIndex = j;
                }

                range.ToIndex = j;
            }

            return range;
        }


        private void Popup(int i)
        {
            int valueToPopup = this.insideArray[i];
            while (i > 0 && valueToPopup > this.insideArray[i])
            {
                this.insideArray[i] = this.insideArray[ParentIndex(i)];
                i = ParentIndex(i);
            }

            this.insideArray[i] = valueToPopup;
        }

        public void Insert(int value)
        {
            this.insideArray[_heapSize++] = value;
            Popup(this.HeapSize - 1);
        }

        public void IncreaseKey(int i, int key)
        {
            if (insideArray[i] > key)
            {
                throw new Exception("increase should greater than original value.");
            }

            this.insideArray[i] = key;
            Popup(i);
        }

        public int ParentIndex(int i)
        {
            return (i - 1) / this.ChildrenCount;
        }
    }
}
