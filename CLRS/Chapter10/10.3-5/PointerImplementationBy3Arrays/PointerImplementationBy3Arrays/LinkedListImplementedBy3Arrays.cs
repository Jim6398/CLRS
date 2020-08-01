using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using Utility.Commmon;

namespace PointerImplementationBy3Arrays
{
    public class LinkedListImplementedBy3Arrays: ILinkedListWithPointer
    {
        const int defaultArraySize = 20;

        private int[] previousArray = new int[defaultArraySize];
        private int[] NextArray = new int[defaultArraySize];
        private int[] valueArray = new int[defaultArraySize];

        private int freeHead;
        private int LinkListHead;
        private int currentCount = 0;
        public LinkedListImplementedBy3Arrays()
        {
            Initialize();
            InitializeFree();
        }

        /// <summary>
        ///  当前元素的数量
        /// </summary>
        public int Count
        {
            get 
            {
                return this.currentCount;
            }
        }

        /// <summary>
        /// 返回
        /// </summary> 
        /// <returns></returns>
        public int AllocateObject()
        {
            if (freeHead == int.MaxValue)
            {
                throw new Exception("there is no space for allocation");
            }
            int spaceToAllocate = freeHead;
            freeHead = NextArray[freeHead];
            if (freeHead != int.MaxValue)
            {
                previousArray[freeHead] = int.MaxValue;
            }
            return spaceToAllocate;
        }

        private void Initialize()
        {
            LinkListHead = int.MaxValue;
            previousArray = previousArray.AsEnumerable().Select(ele => int.MaxValue).ToArray();
            NextArray = previousArray.AsEnumerable().Select(ele => int.MaxValue).ToArray();
            valueArray = valueArray.AsEnumerable().Select(ele => int.MinValue).ToArray();
        }

        public void FreeObject(int index)
        {
            NextArray[index] = freeHead;
            if (freeHead != int.MaxValue)
            {
                previousArray[freeHead] = index;
            }

            valueArray[index] = int.MinValue;
            // The free head's pre is an empty value.
            previousArray[index] = int.MaxValue;
            freeHead = index;
        }

        public void Delete(int value)
        {
            int indexValueToDelete = FindIndexByValue(value);
            if (indexValueToDelete == -1)
            {
                return;
            }
            this.currentCount--;
            if (indexValueToDelete == LinkListHead)
            {
                LinkListHead = Next(indexValueToDelete);
                FreeObject(indexValueToDelete);
                return;
            }

            int previsoIndex = Previous(indexValueToDelete);
            int nextIndex = Next(indexValueToDelete);
            NextArray[previsoIndex] = nextIndex;
            if (nextIndex != int.MaxValue)
            {
                previousArray[nextIndex] = previsoIndex;
            }

            FreeObject(indexValueToDelete);
            return;
        }

        private int Next(int currentIndex)
        {
            return NextArray[currentIndex];
        }

        private int Previous(int currentIndex)
        {
            return previousArray[currentIndex];
        }


        /// <summary>
        /// 找到指定Value的Index
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int FindIndexByValue(int value)
        {
            for (int i = 0; i < valueArray.Length; i++)
            {
                if (valueArray[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int value)
        {
            int allocateIndex = AllocateObject();
            this.currentCount++;
            valueArray[allocateIndex] = value;
            if (LinkListHead != int.MaxValue)
            {
                NextArray[allocateIndex] = LinkListHead;
                previousArray[LinkListHead] = allocateIndex;
            }
            else
            {
                NextArray[allocateIndex] = int.MaxValue;
                previousArray[allocateIndex] = int.MaxValue ;
            }

            LinkListHead = allocateIndex;
        }

        public void InitializeFree()
        {
            int lastValue = int.MaxValue;
            for (int i = NextArray.Length - 1; i >= 0; i--)
            {
                NextArray[i] = lastValue;
                lastValue = i;
                if (lastValue != int.MaxValue)
                {
                    previousArray[lastValue] = i;
                }
            }
            previousArray[0] = int.MaxValue;
        }

        public void PrintArray()
        {
            if (LinkListHead == int.MaxValue)
            {
                return;
            }

            int currentIndex = LinkListHead;
            while (currentIndex != int.MaxValue)
            {
                Console.Write($"{valueArray[currentIndex]} ");
                currentIndex = NextArray[currentIndex];
            }
            Console.WriteLine();
        }

        public void CompactifyList()
        {
            int lastValueIndex = this.Count - 1;
            int currentIndex = this.LinkListHead;
            int lastFreeIndex = this.freeHead;
            while (currentIndex != int.MaxValue)
            {
                //  find a value out of the range.
                if (currentIndex > lastValueIndex)
                {
                    // Find a free space that is with 0 to lastValueIndex
                    GetFreeWithLastValueIndex(ref lastFreeIndex, lastValueIndex);
                    SwitchIndex(currentIndex, lastFreeIndex);
                    // after switch the lastFreeIndex actually points to the current value index.
                    CommonFunc.Exchange(ref currentIndex, ref lastFreeIndex);
                }

                currentIndex = NextArray[currentIndex];
            }
        }



        private void SwitchIndex(int valueIndex, int freeIndex)
        {
            valueArray[freeIndex] = valueArray[valueIndex];
            valueArray[valueIndex] = int.MinValue;
            int preValueIndex = previousArray[valueIndex];
            int nextValueIndex = NextArray[valueIndex];
            int preFreeIndex = previousArray[freeIndex];
            int nextFreeIndex = NextArray[freeIndex];

            #region 使指向valueIndex的前后指针，指向freeIndex.
            if (preValueIndex == int.MaxValue)
            {
                this.LinkListHead = freeIndex;
                if (nextValueIndex != int.MaxValue)
                {
                    NextArray[this.LinkListHead] = nextValueIndex;
                    previousArray[nextValueIndex] = this.LinkListHead;
                }
            }
            else
            {
                NextArray[preValueIndex] = freeIndex;
                previousArray[freeIndex] = preValueIndex;
                NextArray[freeIndex] = nextValueIndex;
                if (nextValueIndex != int.MaxValue)
                {
                    previousArray[nextValueIndex] = freeIndex;
                }
            }
            #endregion

            #region 把valueIndex 放进FreeLinkedList表里面
            if (preFreeIndex == int.MaxValue)
            {
                freeHead = valueIndex;
                NextArray[valueIndex] = nextFreeIndex;
                if (nextFreeIndex != int.MaxValue)
                {
                    previousArray[nextFreeIndex] = valueIndex;
                }
            }
            else
            {
                NextArray[preFreeIndex] = valueIndex;
                previousArray[valueIndex] = preFreeIndex;
                NextArray[valueIndex] = nextFreeIndex;
                if (nextFreeIndex != int.MaxValue)
                {
                    previousArray[nextFreeIndex] = valueIndex;
                }
            }
            #endregion

        }

        private void GetFreeWithLastValueIndex(ref int lastFreeIndex, int lastValueIndex)
        {
            while (lastFreeIndex > lastValueIndex)
            {
                lastFreeIndex = NextArray[lastFreeIndex];
            }
        }
    }
}
