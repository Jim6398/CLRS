using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRDNodeVisit
{
    public class BinaryTreeNode<T>
    {
        public T KeyValue
        {
            get; set;
        }

        public BinaryTreeNode<T> LeftChild
        { get; set; }
        public BinaryTreeNode<T> RightChild
        { get; set; }
        public BinaryTreeNode<T> ParentNode
        {get;set;}     
    }

    public class BinaryNodeTable<T>
    {
        public int currentNodeIndex
        {
            get;set;
        }
        public T key
        {
            get; set;
        }

        public int LeftChildIndex
        {get;set;}

        public int rightChildIndex
        { get; set; }
    }

    public class BinaryTree<T>
    {
        class stackNode
        {

            public stackNode()
                {
                this.isRightChildPushed = false;
            }
            public BinaryTreeNode<T> node
            { get; set; }

            public bool isRightChildPushed
            { get; set; }

            public bool isLeftChildPushed
            { get; set; }
        }

        public BinaryTreeNode<T> rootNode
        { get; set; }

        public BinaryTree(BinaryNodeTable<T>[] binaryNodeTableList, int rootIndex)
        {
            Dictionary<int, BinaryNodeTable<T>> nodesDict = binaryNodeTableList.AsEnumerable()
                .ToDictionary(ele => ele.currentNodeIndex,ele=> ele);
           this.rootNode = ConstructBinaryTreeFromTreeNode(nodesDict, rootIndex);
        }

        public BinaryTreeNode<T> ConstructBinaryTreeFromTreeNode(Dictionary<int, BinaryNodeTable<T>> nodesDict, int rootIndex)
        {
            return new BinaryTreeNode<T>
            {
                KeyValue = nodesDict[rootIndex].key
                ,
                LeftChild = nodesDict[rootIndex].LeftChildIndex == int.MaxValue? null : ConstructBinaryTreeFromTreeNode(nodesDict, nodesDict[rootIndex].LeftChildIndex)
                ,
                RightChild = nodesDict[rootIndex].rightChildIndex == int.MaxValue ? null : ConstructBinaryTreeFromTreeNode(nodesDict, nodesDict[rootIndex].rightChildIndex)
            };
        }
   
        /// <summary>
        /// 这个算法完全模拟递归调用过程。
        /// </summary>
        /// <returns></returns>
        public string LRDByAStack()
        {
            StringBuilder resultSB = new StringBuilder();
            Stack<stackNode> stackUnvisited = new Stack<stackNode>();
            stackUnvisited.Push(new stackNode { node = rootNode,isLeftChildVisited=false, isRightChildPushed = false });
            while (stackUnvisited.Count() != 0)
            {
                var currentNode = stackUnvisited.Peek();

                if (!currentNode.isLeftChildPushed)
                {
                    currentNode.isLeftChildPushed = true;
                    if (currentNode.node.LeftChild == null)
                    {
                        continue;
                    }
                    stackUnvisited.Push(new stackNode { node = currentNode.node.LeftChild, isLeftChildPushed = false, isRightChildPushed = false });
                }
                else if (!currentNode.isRightChildPushed)
                {
                    currentNode.isRightChildPushed = true;
                    if (currentNode.node.RightChild == null)
                    {
                        continue;
                    }
                    stackUnvisited.Push(new stackNode { node = currentNode.node.RightChild, isLeftChildPushed = false, isRightChildPushed = false });
                }
                else
                {
                    var node = stackUnvisited.Pop();
                    resultSB.Append(node.node.KeyValue.ToString());
                }
            };
            return resultSB.ToString();
        }

        public void LRDRecursive(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            LRDRecursive(node.LeftChild);
            LRDRecursive(node.RightChild);
            Console.Write(node.KeyValue.ToString());
             

        }
    }
}
