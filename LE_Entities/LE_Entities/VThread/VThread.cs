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


        public string Name => name;

        public int Id => id;

        public VThread(string name = null)
        {
            this.name = name;
            vThreadActions = new VThreadAction[5];
            id = IdManager.IdDeliverer<VThread>.GetNextId();
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
