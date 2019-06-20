using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.VThread
{
    class VThread : IVThread
    {
        private readonly string name;
        private readonly int id;
        private readonly VThreadAction[] vThreadActions;
        private int threadId;

        public string Name => name;

        public int Id => id;

        public int ThreadId { get => threadId; set => threadId = value; }

        public VThread(string name = null)
        {
            this.name = name;
            vThreadActions = new VThreadAction[5];
            id = IdManager.IdDeliverer<VThread>.GetNextId();
        }


        public void SetAction(IProcess process)
        {
            vThreadActions[0] = process.OnInit;
            vThreadActions[1] = process.OnStart;
            vThreadActions[2] = process.OnUpdate;
            vThreadActions[3] = process.OnEnd;
            vThreadActions[4] = process.OnDestory;
        }

        public void SetAction(VThreadState state, VThreadAction vThreadAction)
        {
            vThreadActions[(int)state] = vThreadAction;
        }

        public void OnInit()
        {
            vThreadActions[0]?.Invoke();
        }

        public void OnStart()
        {
            vThreadActions[1]?.Invoke();
        }

        public void OnUpdate()
        {
            vThreadActions[2]?.Invoke();
        }

        public void OnEnd()
        {
            vThreadActions[3]?.Invoke();
        }

        public void OnDestory()
        {
            vThreadActions[4]?.Invoke();
        }

    }
}
