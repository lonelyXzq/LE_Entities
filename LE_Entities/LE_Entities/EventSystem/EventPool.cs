using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.EventSystem
{
    public class EventPool<T> : IEventPool<T> where T : EventArgs
    {

        private int count;

        private readonly int maxOperatorNumber;

        private readonly Dictionary<int, EventHandler<T>> events;

        private readonly EventPoolMode eventPoolMode;

        private readonly SafetyQueue<LE_Event<T>> eventList;

        public int Count => count;

        public EventPool(EventPoolMode eventPoolMode,int maxOperatorNumber=64)
        {
            events = new Dictionary<int, EventHandler<T>>();
            eventList = new SafetyQueue<LE_Event<T>>();
            this.eventPoolMode = eventPoolMode;
            this.maxOperatorNumber = maxOperatorNumber;
        }

        public void OnInit()
        {
            
        }

        public void OnStart()
        {
            
        }

        public void OnUpdate()
        {
            for (int i = 0; i < maxOperatorNumber; i++)
            {
                if(eventList.Dequeue(out LE_Event<T> e))
                {
                    FireNow(e.Id, e.Sender, e.E);
                }
            }
        }

        public void OnEnd()
        {
            
        }

        public void OnDestory()
        {
            
        }

        public bool Add(int id, EventHandler<T> handler)
        {
            if (Check(id))
            {
                count++;
                events.Add(id, handler);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Remove(int id)
        {
            count--;
            events.Remove(id);
        }

        public bool Check(int id)
        {
            return events.ContainsKey(id);
        }

        public void Subscribe(int id, EventHandler<T> handler)
        {
            if (Check(id))
            {
                switch (eventPoolMode)
                {
                    case EventPoolMode.Single:
                        if (events[id].GetInvocationList().Length==1)
                        {
                            events[id] += handler;
                        }
                        else
                        {
                            //TODO:
                        }
                        break;
                    case EventPoolMode.Multiple:
                        events[id] += handler;
                        break;
                    default:
                        break;
                }
                events[id] += handler;
            }
            else
            {
                //TODO:
            }
        }

        public void UnSubscribe(int id, EventHandler<T> handler)
        {
            if (Check(id))
            {
                events[id] -= handler;
            }
        }

        public void Fire(int id, object sender, T e)
        {
            eventList.Enqueue(new LE_Event<T>(id, sender, e));
        }

        public void FireNow(int id, object sender, T e)
        {
            if (Check(id))
            {
                events[id]?.Invoke(sender, e);
            }
        }

    }
}
