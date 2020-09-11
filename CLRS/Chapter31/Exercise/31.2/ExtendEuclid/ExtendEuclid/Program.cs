using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtendEuclid
{
    public class EuclidEntity
    {
        public int D
        { get; set;}
        public int X
        { get; set; }
        public int Y
        { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EuclidEntity euclidEntity = ExtendEuclid(99, 78);
            Console.WriteLine($"{euclidEntity.X}*99 + {euclidEntity.Y}*78 = {euclidEntity.D}");
        }

        public static EuclidEntity ExtendEuclid(int a, int b)
        {
            if (b == 0)
            {
                return new EuclidEntity { D = a, X = 1, Y = 0 };
            }

            EuclidEntity preEuclidEntity = ExtendEuclid(b, a % b);

            return new EuclidEntity { X=preEuclidEntity.Y, D = preEuclidEntity.D, Y = preEuclidEntity.X - (a/b) * preEuclidEntity.Y };
        }
    }
}
