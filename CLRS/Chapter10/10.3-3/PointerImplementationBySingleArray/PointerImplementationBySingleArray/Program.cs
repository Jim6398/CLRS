using System;

namespace PointerImplementationBySingleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListWithPointers lList = new LinkedListWithPointers();
            for (int i = 0; i < 15; i++)
            {
                lList.Insert(i);
            }
            lList.PrintArray();
            for (int i = 0; i < 5; i++)
            {
                lList.Delete(i);
            }
            lList.PrintArray();

            for (int i = 20; i < 30; i++)
            {
                lList.Insert(i);
            }
            lList.PrintArray();
        }
    }
}
