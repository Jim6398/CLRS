using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
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
        public LinkedListImplementedBy3Arrays()
        {
            Initialize();
            InitializeFree();
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
            valueArray[index] = int.MinValue;
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
            freeHead = 0;
            int current = freeHead;
            while(current != this.NextArray.Length -1)
            {
                NextArray[current] = current + 1;
                current++;
            }

            this.NextArray[this.NextArray.Length - 1] = int.MaxValue;
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
    }
}
