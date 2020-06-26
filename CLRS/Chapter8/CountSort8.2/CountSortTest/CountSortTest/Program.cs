using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 6,0, 2, 0, 1, 3, 4, 6, 1, 3, 2 };
            int[] inputB = inputA.AsEnumerable().Select(ele => ele + 555).ToArray();
            CountingSort(ref inputA);
            Console.WriteLine(string.Join(",", inputA));

            CountingSortImprove(ref inputB);
            Console.WriteLine(string.Join(",", inputB));
        }

        public static void CountingSort(ref int[] inputA)
        {
            // Find max value of Input Array A to initialize Array C.
            int maxValue = inputA.AsEnumerable().Max();
            int[] cArray = new int[maxValue + 1];
            int[] resultArray = new int[inputA.Length];
            // Calculate value count for Array A. 
            for (int i = 0; i < inputA.Length; i++)
            {
                cArray[inputA[i]]++;
            }

            // 让cArray[i] <= i;
            for (int i = 1; i < cArray.Length; i++)
            {
                cArray[i] = cArray[i - 1] + cArray[i];
            }

            Console.WriteLine(string.Join(",", cArray));

            for (int i = inputA.Length - 1; i >= 0; i--)
            {
                int currentValue = inputA[i];
                resultArray[cArray[currentValue] - 1] = inputA[i];
                cArray[currentValue]--;
            }

            inputA = resultArray;
        }

        public static void CountingSortImprove(ref int[] inputA)
        {
            // Find max value of Input Array A to initialize Array C.
            int maxValue = inputA.AsEnumerable().Max();
            int minValue = inputA.AsEnumerable().Min();

            int[] cArray = new int[maxValue - minValue + 1];
            int[] resultArray = new int[inputA.Length];
            // Calculate value count for Array A. 
            for (int i = 0; i < inputA.Length; i++)
            {
                cArray[inputA[i] - minValue]++;
            }

            // 让cArray[i] <= i;
            for (int i = 1; i < cArray.Length; i++)
            {
                cArray[i] = cArray[i - 1] + cArray[i];
            }

            Console.WriteLine(string.Join(",", cArray));

            for (int i = inputA.Length - 1; i >= 0; i--)
            {
                int currentValue = inputA[i];
                resultArray[cArray[currentValue - minValue] - 1] = inputA[i];
                cArray[currentValue - minValue]--;
            }

            inputA = resultArray;
        }
    }
}
