﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortDuplication
{

    public class IndexResult
    {
        public int equalStartIndex
        { get; set; }

        public int equalEndIndex
        {get;set;}

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayTest = new int[] { 1, 11, 2, 12, 13, 5, 7, 10, 10, 8, 10, 17, 19, 10 };
            IndexResult partitionResult = Partition(arrayTest, 0, arrayTest.Length - 1);
            Console.WriteLine(string.Join(",", arrayTest));
        }

        private static IndexResult Partition(int[] arrayToSort, int startIndex, int endIndex)
        {
            // all the elements are less than pivot value between start index and lessThanIndex [startIndex, lessThanIndex]
            int lessThanIndex = startIndex - 1;
            // all the equal than index are between [lessThanIndex + 1, equalThanIndex]
            int equalThanIndex = startIndex - 1;
            //all the  great Than pivot index are between [equalThanIndex + 1, greatThanIndex]
            int greatThanIndex = startIndex - 1;

            int pivotValue = arrayToSort[endIndex];

            for (greatThanIndex = startIndex; greatThanIndex < endIndex; greatThanIndex ++)
            {
                if (arrayToSort[greatThanIndex] == pivotValue)
                {
                    Exchange(ref arrayToSort[greatThanIndex], ref arrayToSort[++equalThanIndex]);
                }
                else if (arrayToSort[greatThanIndex] < pivotValue)
                {
                    int temp = arrayToSort[greatThanIndex];
                    arrayToSort[greatThanIndex] = arrayToSort[++equalThanIndex];
                    arrayToSort[equalThanIndex] = arrayToSort[++lessThanIndex];
                    arrayToSort[lessThanIndex] = temp;
                }
            }

            Exchange(ref arrayToSort[++equalThanIndex], ref arrayToSort[endIndex]);
            return new IndexResult { equalStartIndex = lessThanIndex+1, equalEndIndex = equalThanIndex };
        }

        private static void Exchange(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
    }
}
