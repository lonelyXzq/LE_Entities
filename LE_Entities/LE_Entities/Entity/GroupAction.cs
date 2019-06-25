using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    interface IGroupAction
    {
        void Execute(int id);
    }



    class GroupAction : IGroupAction
    {
        private readonly Execute actions;

        public GroupAction(Execute actions)
        {
            this.actions = actions;
        }

        public void Execute(int id)
        {
            actions?.Invoke(id);
        }
    }

    class GroupAction<T1> : IGroupAction where T1 : IData
    {
        private readonly Execute<T1> actions;

        public GroupAction(Execute<T1> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(id, entity.GetData<T1>());
        }
    }

    class GroupAction<T1, T2> : IGroupAction
        where T1 : IData where T2 : IData
    {
        private readonly Execute<T1, T2> actions;

        public GroupAction(Execute<T1, T2> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>());
        }
    }

    class GroupAction<T1, T2, T3> : IGroupAction
        where T1 : IData where T2 : IData where T3 : IData
    {
        private readonly Execute<T1, T2, T3> actions;

        public GroupAction(Execute<T1, T2, T3> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>());
        }
    }

    class GroupAction<T1, T2, T3, T4> : IGroupAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData
    {
        private readonly Execute<T1, T2, T3, T4> actions;

        public GroupAction(Execute<T1, T2, T3, T4> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>(), entity.GetData<T4>());
        }
    }

    class GroupAction<T1, T2, T3, T4, T5> : IGroupAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData
    {
        private readonly Execute<T1, T2, T3, T4, T5> actions;

        public GroupAction(Execute<T1, T2, T3, T4, T5> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>());
        }
    }

    class GroupAction<T1, T2, T3, T4, T5, T6> : IGroupAction
         where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData
    {
        private readonly Execute<T1, T2, T3, T4, T5, T6> actions;

        public GroupAction(Execute<T1, T2, T3, T4, T5, T6> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>());
        }
    }

    class GroupAction<T1, T2, T3, T4, T5, T6, T7> : IGroupAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData
    {
        private readonly Execute<T1, T2, T3, T4, T5, T6, T7> actions;

        public GroupAction(Execute<T1, T2, T3, T4, T5, T6, T7> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>()
                , entity.GetData<T7>());
        }
    }

    class GroupAction<T1, T2, T3, T4, T5, T6, T7, T8> : IGroupAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData where T8 : IData
    {
        private readonly Execute<T1, T2, T3, T4, T5, T6, T7, T8> actions;

        public GroupAction(Execute<T1, T2, T3, T4, T5, T6, T7, T8> actions)
        {
            this.actions = actions;
        }
        public void Execute(int id)
        {
            Entity entity = DataInfo<Entity>.DataChain.GetData(id);
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>()
                , entity.GetData<T7>(), entity.GetData<T8>());
        }
    }
}
