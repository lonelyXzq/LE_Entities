using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.EventSystem
{
    interface IEventPool<T>:IProcess where T:EventArgs
    {
        int Count { get; }

        bool Add(int id, EventHandler<T> handler);

        void Remove(int id);

        bool Check(int id);

        void Subscribe(int id, EventHandler<T> handler);

        void UnSubscribe(int id, EventHandler<T> handler);

        void Fire(int id, object sender, T e);

        void FireNow(int id, object sender, T e);

    }
}
