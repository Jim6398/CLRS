using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Commmon;

namespace RandomizedSelectByLoopTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArrayTest = new int[100];
            for (int i = 0; i < inputArrayTest.Length; i++)
            {
                inputArrayTest[i] = i;
            }

            int[] randomizedArray = CommonFunc.RandomizeArray(inputArrayTest);
            Console.WriteLine(string.Join(",", randomizedArray));
            Console.WriteLine(RandomSelect(randomizedArray, 0, randomizedArray.Length - 1, 89));
        }


        public static int RandomSelect(int[] inputArray, int startIndex, int endIndex, int ith)
        {
            while (true)
            {
                if (startIndex == endIndex)
                {
                    return inputArray[startIndex];
                }
                int pivotIndex = RandomPartition(inputArray, startIndex, endIndex);
                int currentPivotSequence = pivotIndex - startIndex + 1;
                if (currentPivotSequence == ith)
                {
                    return inputArray[pivotIndex];
                }

                if (currentPivotSequence < ith)
                {
                    startIndex = pivotIndex + 1;
                    ith -= currentPivotSequence;

                }
                else
                {
                    endIndex = pivotIndex - 1;
                }

            }
        }

        public static int RandomPartition(int[] inputArray, int startIndex, int endIndex)
        {
            int pivotValue = inputArray[endIndex];
            int lessThanIndex = startIndex - 1;
            for (int i = startIndex; i <= endIndex - 1; i++)
            {
                if (inputArray[i] <= pivotValue)
                {
                    CommonFunc.Exchange(ref inputArray[i], ref inputArray[++lessThanIndex]);
                }
            }
            CommonFunc.Exchange(ref inputArray[lessThanIndex + 1], ref inputArray[endIndex]);
            return lessThanIndex + 1;
        }
    }
}
