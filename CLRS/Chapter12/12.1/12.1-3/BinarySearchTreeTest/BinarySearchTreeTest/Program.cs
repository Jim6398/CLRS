using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] inputArray = new int[] { 10, 5, 15, 2, 7, 12, 17, 1,3, 6,8,11, 13,16,18,4,9};
            BinarySearchTree.BinarySearchTree bst = new BinarySearchTree.BinarySearchTree(inputArray);
            int[] result = bst.InOrderVisitNoRecursive();
            Console.WriteLine(string.Join(",", result));
        }
    }
}
