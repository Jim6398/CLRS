using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointerImplementationBy3Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListImplementedBy3Arrays lList = new LinkedListImplementedBy3Arrays();
            for (int i = 0; i < 20; i++)
            {
                lList.Insert(i);
            }
            lList.PrintArray();
            for (int i = 0; i < 5; i++)
            {
                lList.Delete(i);
            }
            lList.PrintArray();
            lList.CompactifyList();
            lList.PrintArray();
        }
    }
}
