using CLRS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindmiddleWeight
{
    public class ValueIndex
    { 
        public double Value
        { get; set; }

        public int Index
        { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            double[] inputArray = new double[] { 0.1,0.3,0.02, 0.03,0.05,0.1,0.07,0.08, 0.05,0.2};
            if (inputArray.AsEnumerable().Sum() != 1)
            {
                throw new Exception("total length should be 1");
            }
            inputArray = CommonFunc.RandomizeArray(inputArray);
            Console.WriteLine(inputArray[GetMiddleWeightIndex(inputArray, 0, inputArray.Length-1)]);
            Console.WriteLine(string.Join(",", inputArray.AsEnumerable().OrderBy(e=>e)));
        }

        public static int GetMiddleWeightIndex(double[] inputArray, int startIndex, int endIndex)
        {
            int pivotIndex = CommonFunc.RandomPartition(inputArray, startIndex, endIndex);
            double leftAmount, RightAmount;
            if (pivotIndex == startIndex)
            {
                leftAmount = 0;
            }
            else
            {
                leftAmount = GetAmount(inputArray, startIndex, pivotIndex-1);
            }

            if (pivotIndex == endIndex)
            {
                RightAmount = 0;
            }
            else
            {
                RightAmount = GetAmount(inputArray, pivotIndex+1, inputArray.Length-1);
            }

            if (leftAmount < 0.5 && RightAmount <= 0.5)
            {
                return pivotIndex;
            }
            else if (leftAmount < 0.5)
            {
                return GetMiddleWeightIndex(inputArray, pivotIndex + 1, endIndex);
            }
            else
            {
                return GetMiddleWeightIndex(inputArray, startIndex, pivotIndex - 1);
            }
        }

        private static double GetAmount(double[] inputArray, int sIndex, int eIndex)
        {
            double sumValue = 0;
            for (int i = sIndex; i <= eIndex; i++)
            {
                sumValue += inputArray[i];
            }
            return sumValue;
        }
    }
}
