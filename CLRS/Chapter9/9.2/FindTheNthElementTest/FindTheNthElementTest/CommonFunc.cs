using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FindTheNthElementTest
{

    public class RandowWithNoDuplication
    {

        private HashSet<int> existingSet = new HashSet<int>();
        private int from, to;
        public RandowWithNoDuplication(int from, int end)
        {
            this.from = from;
            this.to = end;
        }

        public int GetRandomValue()
        {
            Random r = new Random();
            int value = 0;
            do
            {
                value = r.Next(from, to);

            } while (existingSet.Contains(value));

            return value;
        }
            
    }
   public static class CommonFunc
    {
        public static void Exchange<T>(ref T leftValue, ref T rightValue)
        {
            T temp = rightValue;
            rightValue = leftValue;
            leftValue = temp;
        }

        public static int[] RandomizeArray(int[] inputArray)
        {
            RandowWithNoDuplication randomGeneratorWithNoDuplication = new RandowWithNoDuplication(0, inputArray.Length * 5);
            var inputListWithPriority = inputArray.AsEnumerable()
                .Select(ele=> new { value = ele, priority = randomGeneratorWithNoDuplication.GetRandomValue() });

            return inputListWithPriority.AsEnumerable().OrderBy(ele => ele.priority).Select(ele=>ele.value).ToArray();    

        }
    }
}
