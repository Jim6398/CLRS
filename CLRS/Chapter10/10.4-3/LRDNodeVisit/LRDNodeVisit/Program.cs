using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRDNodeVisit
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryNodeTable<int>[] table = new BinaryNodeTable<int>[]
            {
               new BinaryNodeTable<int>{ currentNodeIndex=1, key=12, LeftChildIndex=7, rightChildIndex=3 },
               new BinaryNodeTable<int>{ currentNodeIndex=2, key=15, LeftChildIndex=8, rightChildIndex=int.MaxValue },
               new BinaryNodeTable<int>{ currentNodeIndex=3, key=4, LeftChildIndex=10, rightChildIndex=int.MaxValue },
               new BinaryNodeTable<int>{ currentNodeIndex=4,key=10, LeftChildIndex=5, rightChildIndex=9 },
               new BinaryNodeTable<int>{ currentNodeIndex=5,key=2, LeftChildIndex=int.MaxValue, rightChildIndex=int.MaxValue},
               new BinaryNodeTable<int>{ currentNodeIndex=6,key=18, LeftChildIndex=1, rightChildIndex=4 },
               new BinaryNodeTable<int>{ currentNodeIndex=7,key=7, LeftChildIndex=int.MaxValue, rightChildIndex=int.MaxValue},
               new BinaryNodeTable<int>{ currentNodeIndex=8,key=14, LeftChildIndex=6, rightChildIndex=2 },
               new BinaryNodeTable<int>{ currentNodeIndex=9,key=21, LeftChildIndex=int.MaxValue, rightChildIndex=int.MaxValue },
               new BinaryNodeTable<int>{ currentNodeIndex=10,key=5, LeftChildIndex=int.MaxValue, rightChildIndex=int.MaxValue }
            };

            BinaryTree<int> binaryTree = new BinaryTree<int>(table, 6);
            Console.WriteLine(binaryTree.LRDByAStack().ToString());
            binaryTree.LRDRecursive(binaryTree.rootNode);
        }
    }
}
