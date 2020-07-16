using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeueTest
{
    public class Deque<T>
    {
        const int defaultSize = 1024;
        private T[] insideArray = new T[1024];
        int head, tail;
        int count;
        public Deque(int size = defaultSize)
        {
            head  = 0; 
            tail = 0;
            count = 0;
            insideArray = new T[size];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsFull
        {
            get
            { 
                return this.insideArray.Length == count;
            }           
        }

        public void TailEnqueue(T value)
        {
            if (IsFull)
            {
                Resize();
            }

            this.insideArray[tail++] = value;
            if (tail == this.insideArray.Length)
            {
                tail = 0;
            }

            this.count++;
        }

        public void HeadEnqueue(T value)
        {
            if (IsFull)
            {
                Resize();
            }

            head--;
            if (head < 0)
            {
                head = this.insideArray.Length - 1;
            }

            this.insideArray[head] = value;
            this.count++;
        }

        public bool IsEmpty
        {
            get
            {
                return this.count == 0;
            }
        }

        public T HeadDequeue()
        {
            if (this.count == 0)
            {
                throw new Exception("there is no element to dequeue");
            }

            T dequeueValue = this.insideArray[head++];
            if (head == this.insideArray.Length)
            {
                head = 0;
            }

            this.count--;

            return dequeueValue;
        }

        public T TailDequeue()
        {
            if (this.count == 0)
            {
                throw new Exception("there is no element to dequeue");
            }

            this.tail--;
            if (this.tail < 0)
            {
                this.tail = this.insideArray.Length - 1;
            }
            this.count--;
            return this.insideArray[this.tail];
        }

        private void Resize()
        {
            T[] oldArray = this.insideArray;
            T[] newArray = new T[oldArray.Length * 2];
            int i = head;
            int newIndex = 0;
            while (i != tail)
            {
                newArray[newIndex++] = oldArray[i++];
                if (i == oldArray.Length)
                {
                    i = 0;
                }             
            }

            this.head = 0;
            this.tail = newIndex;
            this.insideArray = newArray;
        }

        public IEnumerable<T> GetAllElement()
        {
            int i = this.head;       
            do
            {
                T value = this.insideArray[i];
                i++;
                if (i == this.insideArray.Length)
                {
                    i = 0;
                }
                yield return value;
            } while (i != tail) ;
        }
    }
}
