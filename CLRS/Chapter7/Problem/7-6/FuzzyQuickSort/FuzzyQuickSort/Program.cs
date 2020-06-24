
using System;

namespace FuzzyQuickSort
{
    public class IndexResult
    {
        public int equalStartIndex
        { get; set; }

        public int equalEndIndex
        { get; set; }

    }

    public class Range
    {
        public int From
        { get; set; }

        public int To
        { get; set; }
    }



    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        /// <summary>
        ///  这个Partition 的逻辑基本上和7-2的问题一样。因为一旦有Range Overlap那么这个两个Range内的元素则无法比较大小。比较则没有意义
        ///  所以一旦出现Overlap则认为两个Range相等。
        /// </summary>
        /// <param name="rangeArray"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static IndexResult Partition(Range[] rangeArray, int startIndex, int endIndex)
        {
            int lessThanIndex = startIndex - 1;
            int equalThanIndex = startIndex - 1;
            Range pivotRange = rangeArray[endIndex];
            for (int i = startIndex; i <= endIndex - 1; i++)
            {
                if (IsRangeOverlapped(rangeArray[i], pivotRange))
                {
                    Exchange(ref rangeArray[++equalThanIndex], ref rangeArray[i]);
                }
                else if (pivotRange.From < rangeArray[i].From)
                {
                    Range lessRange = rangeArray[i];
                    rangeArray[i] = rangeArray[++equalThanIndex];
                    rangeArray[equalThanIndex] = rangeArray[++lessThanIndex];
                    rangeArray[lessThanIndex] = lessRange;
                }
            }

            Exchange(ref rangeArray[equalThanIndex + 1], ref rangeArray[endIndex]);
            return new IndexResult { equalStartIndex = lessThanIndex + 1, equalEndIndex =  equalThanIndex};
        }

        /// <summary>
        /// 判断两个Range是否有重叠的部分
        /// </summary>
        /// <param name="lRange"></param>
        /// <param name="rRange"></param>
        /// <returns></returns>
        public static bool IsRangeOverlapped(Range lRange, Range rRange)
        {
            Range largeRange = lRange.To > rRange.To ? lRange : rRange;
            Range smallRange = lRange == largeRange ? rRange : lRange;

            return largeRange.From < smallRange.To;
        }

        public static void Exchange<T>(ref T leftValue, ref T rightValue) 
        {
            T temp = leftValue;
            leftValue = rightValue;
            rightValue = temp;
        }
    }
}
