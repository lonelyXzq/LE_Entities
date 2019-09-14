using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Listener
{
    static class ActionListener<T> where T:IData
    {
        private static readonly ListenerAction<T>[] listeners;


        static ActionListener()
        {
            listeners = new ListenerAction<T>[5];
        }

        public static ListenerAction<T>[] Listeners => listeners;

        public static void AddListener(bool[] ids, IListener<T> listener)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!ids[i])
                {
                    continue;
                }
                if (Listeners[i] == null)
                {
                    Listeners[i] = listener.Execute;
                }
                else
                {
                    Listeners[i] += listener.Execute;
                }
            }

        }
    }
}
