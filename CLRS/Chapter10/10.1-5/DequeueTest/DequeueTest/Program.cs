using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> dq = new Deque<int>(10);

            for (int i = 0; i < 7; i++)
            {
                dq.HeadEnqueue(i);
            }

            for (int i = 0; i < 3; i++)
            {
                dq.TailDequeue();
            }

            for (int i = 7; i < 13; i++)
            {
                dq.TailEnqueue(i);
            }

            Console.WriteLine(string.Join(",", dq.GetAllElement()));
        }
    }
}
