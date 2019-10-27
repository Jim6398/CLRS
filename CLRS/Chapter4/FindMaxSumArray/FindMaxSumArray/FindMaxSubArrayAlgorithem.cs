using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxSumArray
{
    public class FindMaxSubArrayAlgorithem
    {
        public FindMaxSubArrayAlgorithem(int[] inputArray)
        {
            this.inputArray = inputArray;
        }

        private int[] inputArray;
        public SubArrayProp FindMaxCrosssingSubArray(int low, int mid, int high)
        {
            int currentLeftMaxSum = int.MinValue;
            int currentLeftIndex = 0;
            int sum = 0;
            for (int i = mid; i >= 0; i--)
            {
                sum += inputArray[i];
                if (sum > currentLeftMaxSum)
                {
                    currentLeftMaxSum = sum;
                    currentLeftIndex = i;
                }
            }

            int currentRightMaxSum = int.MinValue;
            int currentRightIndex = 0;
            sum = 0;
            for (int i = mid + 1; i < this.inputArray.Length; i++)
            {
                sum += inputArray[i];
                if (sum > currentRightMaxSum)
                {
                    currentRightMaxSum = sum;
                    currentRightIndex = i;
                }
            }

            return new SubArrayProp() { left = currentLeftIndex, right = currentRightIndex, value = currentLeftMaxSum + currentRightMaxSum };
        }

        public SubArrayProp FindMaximumSubArray(int low, int high)
        {
            if (low == high)
            {
                return new SubArrayProp { left = low, right = low, value = this.inputArray[low] };
            }

            int mid = (low + high) / 2;
            SubArrayProp leftArrayProps = FindMaximumSubArray(low, mid);
            SubArrayProp rightArrayProp = FindMaximumSubArray(mid + 1, high);
            SubArrayProp crossArrayProps = FindMaxCrosssingSubArray(low, mid, high);
            return FindMaxCrossingSubArray(leftArrayProps, rightArrayProp, crossArrayProps);
        }

        public static SubArrayProp FindMaxCrossingSubArray(params SubArrayProp[] subArrayProps) 
        {
            if (subArrayProps == null 
                || subArrayProps.Count() == 0)
            {
                return null;
            }
            int maxValue = int.MinValue;
            SubArrayProp maxArrayProp = subArrayProps[0];
            foreach(SubArrayProp prop in subArrayProps)
            {
                if (prop.value > maxValue)
                {
                    maxValue = prop.value;
                    maxArrayProp = prop;
                }
            }
            return maxArrayProp;
        }
    }
}
