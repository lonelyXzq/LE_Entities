#define ThreadTrack

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Entities.Tool
{
    class SafetyQueue<T> : ISafetyQueue<T>
    {
        private readonly Queue<T> queue;

        private int mark;

        public int Count => mark == 1 ? -1 : queue.Count;

        public SafetyQueue()
        {
            queue = new Queue<T>();
            mark = 0;
        }

        private bool Get()
        {
            if (Interlocked.CompareExchange(ref mark, 1, 0) == 0)
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
            while (true)
            {
                if (Get())
                {
                    if (queue.Count > 0)
                    {
                        data = queue.Dequeue();
                        mark = 0;
                        return true;
                    }
                    else
                    {
                        data = default;
                        mark = 0;
                        return false;
                    }
                }
                else
                {
#if ThreadTrack
                    ThreadTracker.ThreadTracker.AddTimes(string.Format("id:{0},name:{1}"
                        , Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
#endif
                }
            }
        }

        public bool Enqueue(T data)
        {
            while (true)
            {
                if (Get())
                {
                    queue.Enqueue(data);
                    mark = 0;
                    return true;
                }
                else
                {
#if ThreadTrack
                    ThreadTracker.ThreadTracker.AddTimes(string.Format("id:{0},name:{1}"
                        , Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
#endif
                }
            }
        }

    }
}
