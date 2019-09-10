using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.EventSystem
{
    class LE_Event<T> where T : EventArgs
    {
        private readonly int id;

        private readonly T e;

        private readonly object sender;

        public LE_Event(int id, object sender, T e)
        {
            this.id = id;
            this.sender = sender;
            this.e = e;
        }

        public int Id => id;

        public T E { get => e; }

        public object Sender { get => sender; }

    }
}
