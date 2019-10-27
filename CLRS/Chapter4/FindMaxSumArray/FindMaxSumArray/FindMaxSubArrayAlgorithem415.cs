using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxSumArray
{
    public class FindMaxSubArrayAlgorithem415
    {
        public FindMaxSubArrayAlgorithem415(int[] inputArray)
        {
            this.inputArray = inputArray;
        }

        private int[] inputArray;

        /// <summary>
        /// Solutions for  4.1-5
        /// </summary>
        /// <returns></returns>
        public SubArrayProp FindMaximumSubArray()
        {
            int lastMaxSum = int.MinValue;
            SubArrayProp lastMaxSubPop = null;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int sum = 0;
                for (int j = i; j >= 0; j--)
                {
                    sum += inputArray[j];
                    if (sum >= lastMaxSum)
                    {
                        lastMaxSubPop = new SubArrayProp { left = j, right = i, value = sum };
                        lastMaxSum = sum;
                    }
                }
            }

            return lastMaxSubPop;
        }
    }
}
