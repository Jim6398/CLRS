using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxSumArray
{h
    class Program
    {
        public static void Main(string[] args)
        {
            int[] inputArray = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            FindMaxSubArrayAlgorithem findMaxArray = new FindMaxSubArrayAlgorithem(inputArray);

            SubArrayProp prop = findMaxArray.FindMaximumSubArray(0, inputArray.Length - 1);

            Console.WriteLine(prop.value);
            for (int i= prop.left; i<= prop.right;i++)
            {
                Console.Write(inputArray[i] + " ");
            }
        }
    }
}
