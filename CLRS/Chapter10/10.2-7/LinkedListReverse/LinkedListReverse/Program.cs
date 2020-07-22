using System;

namespace LinkedListReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            OneWayLinkedList<int> newLinkedList = new OneWayLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                newLinkedList.Insert(i);
            }

            newLinkedList.PrintOneWayLinkedList();
            newLinkedList.Reverse();
            newLinkedList.PrintOneWayLinkedList();
        }
    }
}
