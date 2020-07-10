using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CLRS.Common
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

        public static T[] RandomizeArray<T>(T[] inputArray)
        {
            RandowWithNoDuplication randomGeneratorWithNoDuplication = new RandowWithNoDuplication(0, inputArray.Length * 5);
            var inputListWithPriority = inputArray.AsEnumerable()
                .Select(ele=> new { value = ele, priority = randomGeneratorWithNoDuplication.GetRandomValue() });

            return inputListWithPriority.AsEnumerable().OrderBy(ele => ele.priority).Select(ele=>ele.value).ToArray();    

        }

        public static int RandomPartition<T>(T[] inputArray, int startIndex, int endIndex) 
            where T : IComparable<T>
        {
            T pivotValue = inputArray[endIndex];
            int lessThanIndex = startIndex - 1;
            for (int i = startIndex; i <= endIndex - 1; i++)
            {
                if (inputArray[i].CompareTo(pivotValue) <= 0)
                {
                    CommonFunc.Exchange(ref inputArray[i], ref inputArray[++lessThanIndex]);
                }
            }

            CommonFunc.Exchange(ref inputArray[lessThanIndex + 1], ref inputArray[endIndex]);

            return lessThanIndex + 1;
        }
    }
}
