using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class VisitStatus
    {
        public bool IsLeftVisited
        { get; set; }

        public bool IsRightVisited
        { get; set; }

        public bool IsNodeVisited
        { get; set; }

        public BinaryTreeNode Node
        { get; set; }
    }
}
