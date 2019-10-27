using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxSumArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("BEGIN 4.1.3");
            int[] inputArray = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            FindMaxSubArrayAlgorithem findMaxArray = new FindMaxSubArrayAlgorithem(inputArray);

            SubArrayProp prop = findMaxArray.FindMaximumSubArray(0, inputArray.Length - 1);

            Console.WriteLine(prop.value);
            for (int i = prop.left; i <= prop.right; i++)
            {
                Console.Write(inputArray[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("BEGIN 4.1.5");

            // Test Algorithem for 4.1.5
            FindMaxSubArrayAlgorithem415 findMaxArray415 = new FindMaxSubArrayAlgorithem415(inputArray);
            SubArrayProp prop415 = findMaxArray415.FindMaximumSubArray();

            Console.WriteLine(prop415.value);
            for (int i = prop415.left; i <= prop415.right; i++)
            {
                Console.Write(inputArray[i] + " ");
            }
        }
    }
}
