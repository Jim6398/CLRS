using Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHeapTest
{
    class Program
    {
         public static void Main(string[] args)
        {
            HashSet<int> randomValueSet = new HashSet<int>();
            Random r = new Random(0);
            while (randomValueSet.Count < 20)
            {
                int newValue = r.Next(0, 10000);
                if (!randomValueSet.Contains(newValue))
                {
                    randomValueSet.Add(newValue);
                }
            }

            DHeap heap = new DHeap(randomValueSet.ToArray(), 3);
        }
    }
}
