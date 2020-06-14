using System;

namespace QuickSortOriginalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 13,19,9,5,12,8,7,4,21,2,6,11 };
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine(string.Join(',', array));
        }

        public static void QuickSort(int[] arrayToSort, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            int middleIndex = Partition(arrayToSort, startIndex, endIndex);
            QuickSort(arrayToSort, startIndex, middleIndex - 1);
            QuickSort(arrayToSort, middleIndex + 1, endIndex);

        }

        private static int Partition(int[] arrayToSort, int startIndex, int endIndex)
        {
            int i = startIndex - 1;
            int x = arrayToSort[endIndex];
            for (int j = startIndex; j < endIndex; j++)
            {
                if (arrayToSort[j] <= x)
                {
                    Exchange(ref arrayToSort[j], ref arrayToSort[++i]);
                }
            }

            Exchange(ref arrayToSort[i + 1], ref arrayToSort[endIndex]);
            return i + 1;
        }

        private static void Exchange(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
    }
}
