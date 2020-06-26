using System;
using System.Linq;

namespace RangeCountTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 6, 0, 2, 0, 1, 3, 4, 6, 1, 3, 2 };
            Console.WriteLine(CountBetweenRange(inputArray, 3, 6));
        }

        /// <summary>
        /// 这个问题本质上是Count-Sort的变种
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int CountBetweenRange(int[] inputData, int left, int right)
        {
            if (left <= 0)
            {
                return inputData[right];
            }

            if (right > inputData.Max())
            {
                right = inputData.Max();
            }

            int[] preparedArray = PrepareData(inputData);
            Console.WriteLine(string.Join(",", preparedArray));
            return preparedArray[right] - preparedArray[left - 1];
        }

        public static int[] PrepareData(int[] inputData)
        {
            int maxValue = inputData.AsEnumerable().Max();
            int[] preparedDataArray = new int[maxValue + 1];
            // i 是索引，对应于inputData的Value. preparedDataArray[i]为具体的数字。
            for (int i = 0; i < inputData.Length; i++)
            {
                preparedDataArray[inputData[i]]++;
            }

            // 让prepareDataArray[i]里面存储的是 <=i 元素的个数。
            for (int i = 1; i < preparedDataArray.Length; i++)
            {
                preparedDataArray[i] += preparedDataArray[i - 1];
            }

            return preparedDataArray;
        }
    }
}
