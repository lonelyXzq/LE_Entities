using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Entities.Tool
{
    class SafetyQueue<T>:ISafetyQueue<T>
    {
        private readonly Queue<T> queue;
        private int mark;

        public int Count => queue.Count;

        public SafetyQueue()
        {
            queue = new Queue<T>();
            mark = 0;
        }

        private bool Get()
        {
            if(Interlocked.CompareExchange(ref mark,1, 0)==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Dequeue(out T data)
        {
            if (Get())
            {
                if (queue.Count > 0)
                {
                    data = queue.Dequeue();
                    
                }
                else
                {
                    data = default;
                }
                mark = 0;
                return true;
            }
            else
            {
                data = default;
                return false;
            }
        }

        public bool Enqueue(T data)
        {
            if (Get())
            {
                queue.Enqueue(data);
                mark = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
