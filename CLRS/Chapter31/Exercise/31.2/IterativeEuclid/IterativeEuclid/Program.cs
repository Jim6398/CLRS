using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeEuclid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Euclid(899, 493));
        }

        public static int Euclid(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }
    }
}
