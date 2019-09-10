using System;
using System.Collections.Generic;
using System.Text;
using LE_Entities.VThread;

namespace LE_Entities.EventSystem
{
    public static class EventManager<T> where T:EventArgs
    {
        private static EventPool<T> eventPool;
        private static readonly VThread.VThread thread;

        static EventManager()
        {
            thread = new VThread.VThread();
            thread.SetAction(eventPool);
        }

        public static void OnInit(EventPoolMode mode)
        {
            eventPool = new EventPool<T>(mode);
        }

        public static EventPool<T> EventPool => eventPool;

    }
}
