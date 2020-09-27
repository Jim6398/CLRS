using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTreeNode
    {
        public int Key
        { get; set; }

        public int data
        { get; set; }

        public BinaryTreeNode Parent
        { get; set;}

        public BinaryTreeNode LeftChild
        { get; set; }

        public BinaryTreeNode RightChild
        { get; set; }
    }
}
