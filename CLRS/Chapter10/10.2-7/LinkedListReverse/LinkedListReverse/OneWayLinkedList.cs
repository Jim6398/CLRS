using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListReverse
{
    public class Node<T>
    { 
        public T value
        { get; set; }

        public Node<T> next;
    }
    public class OneWayLinkedList<T>
    {
        public Node<T> Head
        { get; set; }
        public Node<T> Tail
        { get; set; }

        public OneWayLinkedList()
        {
            Head = Tail = null;
        }

        public void Insert(T value)
        {
            if (Head == null)
            {
                Head = Tail = new Node<T> { value = value, next = null };
                return;
            }
            Node<T> newNode = new Node<T> { value = value, next = Head };
            Head = newNode;           
        }

        /// <summary>
        /// we can implement Reverse by a stack. Or use below
        /// </summary>
        public void Reverse()
        {
            if (Head == null || Head == Tail)
            {
                return;
            }

            Node<T> currentNode = Head.next;
            Node<T> PreNode = Head;
            Head.next = null;
            while (currentNode != null)
            {
                Node<T> nextNode = currentNode.next;
                currentNode.next = PreNode;

                PreNode = currentNode;
                currentNode = nextNode;
            }

            Tail = Head;
            Head = PreNode;
        }

        public void PrintOneWayLinkedList()
        {
            Node<T> p = Head;

            while (p != null)
            {
                Console.Write($"{p.value.ToString()} ");
                p = p.next;
            }
            Console.WriteLine();
               
        }
    } 
}
