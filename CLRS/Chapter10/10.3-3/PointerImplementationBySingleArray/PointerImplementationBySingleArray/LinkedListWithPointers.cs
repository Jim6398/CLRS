using PointerImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointerImplementationBySingleArray
{
    public class LinkedListWithPointers : ILinkedListWithPointer
    {
        private int freeHead;
        private int LinkListHead;
        public int Capacity
        {
            get;
            private set;
        }
        public LinkedListWithPointers(int capacity = 20)
        {
            insideArray = new int[capacity * 3];
            this.Capacity = capacity;
            Initialize();
            InitializeFree();
        }
        private void Initialize()
        {
            LinkListHead = int.MaxValue;
        }
        
        private int[] insideArray;
        public int AllocateObject()
        {
            if (freeHead == int.MaxValue)
            {
                throw new Exception("there is no more space");
            }

            int spaceToAllocate = freeHead;
            freeHead = insideArray[NextIndex(freeHead)];
            return spaceToAllocate;
        }

        public void Delete(int value)
        {
            int indexOfValue = this.FindIndexByValue(value);
            if (indexOfValue == -1)
            {
                // value does not exist. DO NOTHING. 
                return;
            }

            if (indexOfValue != LinkListHead)
            {
                int preValueIndex = this.insideArray[PreIndex(indexOfValue)];
                int nextValueIndex = this.insideArray[NextIndex(indexOfValue)];
                insideArray[NextIndex(preValueIndex)] = nextValueIndex;
            }
            else
            {
                LinkListHead = this.insideArray[NextIndex(LinkListHead)];            
            }
            FreeObject(indexOfValue);

        }

        public void FreeObject(int index)
        {
            insideArray[NextIndex(index)] = freeHead;
            freeHead = index;
        }


        /// <summary>
        /// 所有的空间都是Free的。初始化Free链表
        /// </summary>
        public void InitializeFree()
        {
            freeHead = 0;
            int lastNextIndex = int.MaxValue;
            for (int i = Capacity * 3 - 3; i >=0; i=i-3)
            {
                this.insideArray[NextIndex(i)] = lastNextIndex;
                lastNextIndex = i;
            }
        }

        public void Insert(int value)
        {
            int allocatedIndex = this.AllocateObject();
            insideArray[allocatedIndex] = value;
            if (LinkListHead != int.MaxValue)
            {
                insideArray[NextIndex(allocatedIndex)] = LinkListHead;
                insideArray[PreIndex(LinkListHead)] = allocatedIndex;
            }
            else
            {
                insideArray[NextIndex(allocatedIndex)] = int.MaxValue;
            }
            LinkListHead = allocatedIndex;
        }

        private int NextIndex(int valueIndex)
        {
            return valueIndex + 1;
        }

        private int PreIndex(int valueIndex)
        {
            return valueIndex + 2;
        }

        /// <summary>
        /// 找到指定Value的Index
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int FindIndexByValue(int value)
        {
            int currentIndex = LinkListHead;
            while (currentIndex != int.MaxValue 
                && this.insideArray[currentIndex] != value)
            {
                currentIndex = this.insideArray[NextIndex(currentIndex)];
            }
            if (currentIndex == int.MaxValue)
            {
                return -1;
            }

            return currentIndex;
        }

        public void PrintArray()
        {
            int currentIndex = this.LinkListHead;
            while (currentIndex != int.MaxValue)
            {
                Console.Write($"{this.insideArray[currentIndex]} ");
                currentIndex = this.insideArray[NextIndex(currentIndex)];
            }

            Console.WriteLine();
        }
    }
}
