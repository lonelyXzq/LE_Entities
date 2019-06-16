using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.EventSystem
{
    class EventManager<T> where T:EventArgs
    {
        private EventPool<T> eventPool;
        private VThread.VThread thread;

        public EventManager(EventPoolMode mode)
        {
            eventPool = new EventPool<T>(mode);
            thread = new VThread.VThread();
            thread.SetAction(VThread.VThreadState.Update, eventPool.OnUpdate);
        }
    }
}
