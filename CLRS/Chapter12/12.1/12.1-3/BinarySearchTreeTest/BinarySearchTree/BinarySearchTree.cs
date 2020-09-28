using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree
    {
        private BinaryTreeNode _rootNode;
        private int _count;
        public BinaryTreeNode RootNode
        {
            get
            {
                return _rootNode;
            }
        }

        public int Count { get => _count;  }

        public BinarySearchTree(int[] inputArray)
        {
            foreach (int key in inputArray)
            {
                InsertWithoutRotation(key);
            }
        }

        /// <summary>
        /// Left Tree <. Right Tree >=
        /// </summary>
        /// <param name="key"></param>
        private void InsertWithoutRotation(int key)
        {
            this._count++;
            if (_rootNode == null)
            {
                _rootNode = new BinaryTreeNode { Key = key, Parent = null};
                return;
            }
            BinaryTreeNode currentNode = RootNode;
            BinaryTreeNode parentNode = null;
            bool isInsertLeft = true;
            while (currentNode != null)
            {
                parentNode = currentNode;
                if (key < currentNode.Key)
                {
                    currentNode = currentNode.LeftChild;
                    if (currentNode == null)
                    {
                        isInsertLeft = true;
                    }
                }
                else
                {
                    currentNode = currentNode.RightChild;
                    if (currentNode == null)
                    {
                        isInsertLeft = false;
                    }
                }
            }

            BinaryTreeNode newNode = new BinaryTreeNode { Parent = parentNode, LeftChild = null, RightChild = null, Key = key };
            if (isInsertLeft)
            {
                parentNode.LeftChild = newNode;
            }
            else
            {
                parentNode.RightChild = newNode;
            }
        }

        public int[] InOrderVisitNoRecursive()
        {
            if (this.RootNode == null)
            {
                return null;
            }
            int[] resultArray = new int[this.Count];
            int index = 0;
            Stack<VisitStatus> contextStack = new Stack<VisitStatus>();
            contextStack.Push(new VisitStatus { IsLeftVisited = false, IsRightVisited = false, IsNodeVisited = false, Node = this.RootNode });
            while (contextStack.Count() != 0)
            {
                VisitStatus currentContext = contextStack.Peek();
                if (!currentContext.IsLeftVisited)
                {
                    BinaryTreeNode leftChild = currentContext.Node.LeftChild;
                    if (leftChild != null)
                    {
                        contextStack.Push(new VisitStatus { IsLeftVisited = false, IsRightVisited = false, IsNodeVisited = false, Node = leftChild });
                    }
                    else
                    {
                        currentContext.IsLeftVisited = true;
                    }

                }
                else if (!currentContext.IsNodeVisited)
                {
                    resultArray[index++] = currentContext.Node.Key;
                    currentContext.IsNodeVisited = true;
                }
                else if (!currentContext.IsRightVisited)
                {
                    BinaryTreeNode rightChild = currentContext.Node.RightChild;
                    if (rightChild != null)
                    {
                        contextStack.Push(new VisitStatus { IsLeftVisited = false, IsRightVisited = false, IsNodeVisited = false, Node = rightChild });
                    }
                    else
                    {
                        currentContext.IsRightVisited = true;
                    }
                }
                else
                {
                    // All the elements are visited just popup.
                    var popUpNode = contextStack.Pop();
                    if (contextStack.Count() == 0)
                    {
                        continue;
                    }
                    if (!contextStack.Peek().IsLeftVisited)
                    {
                        contextStack.Peek().IsLeftVisited = true;
                    }
                    else
                    {
                        contextStack.Peek().IsRightVisited = true;
                    }
                }
            }
            return resultArray;
        }

        public int[] InOrderVisitWithoutUsingStack()
        {
            int[] resultArray = new int[this.Count];
            int index = 0;
            BinaryTreeNode currentNode = this.RootNode;
            BinaryTreeNode lastChildNode = null;

            do
            {
                if (lastChildNode == null)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        lastChildNode = null;
                    }
                    else
                    {
                        // visited
                        resultArray[index++] = currentNode.Key;
                        if (currentNode.RightChild != null)
                        {
                            currentNode = currentNode.RightChild;
                            lastChildNode = null;
                        }
                        else
                        {
                            lastChildNode = currentNode;
                            currentNode = currentNode.Parent;
                        }
                    }
                }
                else
                {
                    if (currentNode.LeftChild == lastChildNode)
                    {
                        // we just visited left child.
                        resultArray[index++] = currentNode.Key;
                        if (currentNode.RightChild == null)
                        {
                            lastChildNode = currentNode;
                            currentNode = currentNode.Parent;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                            lastChildNode = null;
                        }
                    }
                    else
                    {
                        lastChildNode = currentNode;
                        currentNode = currentNode.Parent;
                    }
                }
            } while (currentNode != null);
           
            return resultArray;
        }
    }
}
