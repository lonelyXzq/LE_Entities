using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    interface ISafetyQueue<T>
    {
        bool Enqueue(T data);
        bool Dequeue(out T data);

        int Count { get; }
    }
}
