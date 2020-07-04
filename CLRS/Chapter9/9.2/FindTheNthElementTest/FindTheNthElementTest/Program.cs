using System;

namespace FindTheNthElementTest
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
            Console.WriteLine(RandomSelect(randomizedArray, 0, randomizedArray.Length - 1, 50));
        }

        public static int RandomSelect(int[] inputArray, int startIndex, int endIndex, int ith)
        {
            if (startIndex == endIndex)
            {
                return inputArray[startIndex];
            }

            // 第i个元素总是相对于当前的startIndex
            int pivotIndex = RandomPartition(inputArray, startIndex, endIndex);
            int currentPivotOrder = pivotIndex - startIndex + 1;
            if (currentPivotOrder == ith)
            {
                return inputArray[pivotIndex];
            }

            if (ith < currentPivotOrder)
            {
                return RandomSelect(inputArray, startIndex, pivotIndex - 1, ith);
            }
            else
            {
                return RandomSelect(inputArray, pivotIndex + 1, endIndex, ith - currentPivotOrder);
            }
        }

        public static int RandomPartition(int[] inputArray, int startIndex, int endIndex)
        {
            int pivotValue = inputArray[endIndex];
            int lessThanIndex = startIndex - 1;
            for (int i = startIndex; i < endIndex - 1; i++)
            {
                if (inputArray[i] <= pivotValue)
                {
                    lessThanIndex++;
                    CommonFunc.Exchange(ref inputArray[i], ref inputArray[lessThanIndex]);
                }
            }

            CommonFunc.Exchange(ref inputArray[lessThanIndex + 1], ref inputArray[endIndex]);

            return lessThanIndex + 1;
        }




    }
}
