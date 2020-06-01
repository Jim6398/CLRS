using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeapify_NoRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };
            MaxHeapify(inputArray, 2);
            Console.WriteLine(string.Join(",", inputArray));
        }

        static void MaxHeapify(int[] A, int i)
        {

            while (true)
            {
                int leftChildIndex = LeftChildIndex(i);
                int rightChildIndex = RightChildIndex(i);
                if (leftChildIndex > A.Length)
                {
                    break;
                }
                int largestIndex = i;
                if (A[leftChildIndex] > A[i])
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex < A.Length && A[rightChildIndex] > A[i])
                {
                    largestIndex = rightChildIndex;
                }

                if (i == largestIndex) 
                {
                    break;
                }

                Exchange(ref A[i], ref A[largestIndex]);
                i = largestIndex;
            }
        }

        static void Exchange(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int LeftChildIndex(int i)
        {
            return i * 2 +1;
        }

        static int RightChildIndex(int i)
        {
            return i * 2 + 2;
        }
    }
}
