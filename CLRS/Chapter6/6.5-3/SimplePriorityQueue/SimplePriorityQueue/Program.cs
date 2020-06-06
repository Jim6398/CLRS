using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };

            PriorityQueue pQueue = new PriorityQueue(inputArray, PriorityQueue.MaximumComparer);

            Console.WriteLine(string.Join(",", pQueue.GetRawArray()));

            pQueue.Insert(100);

            Console.WriteLine(string.Join(",", pQueue.GetRawArray()));
            Console.WriteLine(IsInputMaximumHeap(pQueue.GetRawArray(), 0));

            pQueue.SetPriority(pQueue.HeapSize/3, 5);
            Console.WriteLine(IsInputMaximumHeap(pQueue.GetRawArray(), 0));
            Console.WriteLine(string.Join(",", pQueue.GetRawArray()));

            pQueue.Delete(2);
            Console.WriteLine(IsInputMaximumHeap(pQueue.GetRawArray(), 0));
            Console.WriteLine(string.Join(",", pQueue.GetRawArray()));
        }

        static bool IsInputMaximumHeap(int[] inputArray, int nodeIndex)
        {
            int leftChildIndex = (nodeIndex << 1) + 1;
            int rightChildIndex = (nodeIndex << 1) + 2;

            if (leftChildIndex > inputArray.Length - 1)
            {
                return true;
            }

            if (rightChildIndex > inputArray.Length - 1)
            {
                if (inputArray[leftChildIndex] <= inputArray[nodeIndex])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (inputArray[leftChildIndex] <= inputArray[nodeIndex] && inputArray[rightChildIndex] <= inputArray[nodeIndex])
            {
                return IsInputMaximumHeap(inputArray, leftChildIndex) && IsInputMaximumHeap(inputArray, rightChildIndex);
            }
            else
            {
                return false;
            }
        }

    }
}
