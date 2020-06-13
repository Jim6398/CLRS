using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoungMatrixLibrary;

namespace YoungMatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] inputArray = new int[4, 4] {
                                                { 20, 18, 16, 14},
                                                {12, 10, 8, 6 },
                                                {4, 2, int.MaxValue, int.MaxValue},
                                                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue}
                                               };
            YoungMatrix yMatrix = new YoungMatrix(inputArray);
        }
    }
}
