using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePriorityQueue
{
    public enum CompareType
    {
        Maximum,
        Minimum
    }

    public delegate bool Comparer(int left, int right);


    public class PriorityQueue
    {

        public static bool MaximumComparer(int left, int right)
        {
            return left > right;
        }

        public static bool MinimumComparer(int left, int right)
        {
            return left < right;
        }

        public int[] GetRawArray()
        {
            int[] returnArray = new int[heapSize];
            int i = 0;
            while (i < this.heapSize)
            {
                returnArray[i] = this.arrayData[i];
                i++;
            }

            return returnArray;
        }

        private int[] arrayData = new int[1024];

        private int heapSize = 0;

        private Comparer comparer;


        public int HeapSize
        {
            get
            {
                return heapSize;
            }
        }

        public PriorityQueue(Comparer comparer)
        { 
            this.comparer = comparer;
        }

        public PriorityQueue(int[] inputArray, Comparer comparer)
            : this(comparer)
        {
            this.heapSize = inputArray.Length;
            inputArray.CopyTo(this.arrayData, 0);           
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }


        /// <summary>
        /// 对应于算法导论的Heap-Maximum
        /// </summary>
        /// <returns></returns>
        public int Heap_Top()
        {
            return arrayData[0];
        }

        /// <summary>
        /// 对应于算法导论的Heap-Extract-Max
        /// </summary>
        /// <returns></returns>
        public int Heap_Extract_Top()
        {
            int popUpValue = Heap_Top();
            arrayData[0] = arrayData[heapSize - 1];
            heapSize--;
            Heapify(0);
            return popUpValue;
        }

        public void Delete(int i)
        {
            if (i >= HeapSize)
            {
                throw new ArgumentException($"{i} out of range");
            }

            int valueToDelete = arrayData[i];
            int lastElement = arrayData[this.heapSize - 1];
            this.heapSize--;
            if (lastElement == valueToDelete)
            {
                return;
            }

            arrayData[i] = lastElement;
            if (lastElement > valueToDelete)
            {
                PopupValue(i);
            }
            else
            {
                Heapify(i);
            }
        }


        /// <summary>
        /// Set the ith value to key
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public void SetPriority(int i, int key)
        {
            if (arrayData[i] == key)
                return;

            arrayData[i] = key;
            if (comparer(key, arrayData[i]))
            {
                PopupValue(i);
            }
            else
            {
                Heapify(i);
            }
        }


        /// <summary>
        /// 对应于算法导论的Insert.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void Insert(int value)
        {
            arrayData[heapSize++] = value;
            PopupValue(heapSize - 1);
        }

        /// <summary>
        /// 从位置i向上popup.
        /// </summary>
        /// <param name="i"></param>
        private void PopupValue(int i)
        {
            int valueToPopup = this.arrayData[i];
            while (i > 0 && comparer(valueToPopup, this.arrayData[ParentIndex(i)]))
            {
                this.arrayData[i] = this.arrayData[ParentIndex(i)];
                i = ParentIndex(i);
            }

            this.arrayData[i] = valueToPopup;
        }


        /// <summary>
        /// Move element i to keep a heap character.
        /// </summary>
        /// <param name="i"></param>
        private void Heapify(int i)
        {
            while (true)
            {
                int leftChildIndex = LeftChildIndex(i);
                int rightChildIndex = RightChildIndex(i);
                if (leftChildIndex >= heapSize)
                {
                    break;
                }
                int largestIndex = i;
                if (this.comparer(arrayData[leftChildIndex],arrayData[i]))
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex < this.heapSize && this.comparer(arrayData[rightChildIndex], arrayData[largestIndex]))
                {
                    largestIndex = rightChildIndex;
                }

                if (i == largestIndex)
                {
                    break;
                }

                Exchange(ref arrayData[i], ref arrayData[largestIndex]);
                i = largestIndex;
            }
        }

        static void Exchange(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Left Child Index.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int LeftChildIndex(int i)
        {
            return i * 2 + 1;
        }

        /// <summary>
        /// right child index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int RightChildIndex(int i)
        {
            return i * 2 + 2;
        }

        private int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }


    }
}
