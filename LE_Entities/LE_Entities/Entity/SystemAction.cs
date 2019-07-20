using LE_Entities.Action;
using LE_Entities.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Entities.Entity
{
    public interface ISystemAction : IObject
    {
        BitArray DataInfo { get; }
        void Execute(Entity entity,int id);
    }

    abstract class BaseSystemAction : ISystemAction
    {
        protected readonly string name;

        private readonly int id;

        private readonly BitArray dataInfo;

        public string Name => name;

        public int Id => id;

        public BitArray DataInfo => dataInfo;

        public BaseSystemAction()
        {
            id = IdManager.IdDeliverer<ISystemAction>.GetNextId();
            Type type = GetType();
            dataInfo = new BitArray(DataManager.Count);
            Type[] dataTypes = type.GetGenericArguments();
            Type dataIn = typeof(DataInfo<>);
            //for (int i = 0; i < dataTypes.Length; i++)
            //{
            //    Console.WriteLine("dataType:" + dataTypes[i].Name);
            //}
            for (int i = 0; i < dataTypes.Length; i++)
            {
                int id = (int)dataIn.MakeGenericType(dataTypes[i]).GetField("dataId", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);
                dataInfo.Set(id, true);
            }
            //Console.WriteLine();
            //for (int i = 0; i < dataInfo.Length; i++)
            //{
            //    Console.Write(dataInfo[i]);
            //}
            //Console.WriteLine();
        }

        public abstract void Execute(Entity entity, int id);
    }
    class SystemAction : BaseSystemAction
    {
        private Execute actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(id);
        }

        public void SetAction(IDataAction dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1> : BaseSystemAction where T1 : IData
    {
        private Execute<T1> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(id, entity.GetData<T1>());
        }

        public void SetAction(IDataAction<T1> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2> : BaseSystemAction
        where T1 : IData where T2 : IData
    {
        private Execute<T1, T2> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>());
        }

        public void SetAction(IDataAction<T1, T2> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3> : BaseSystemAction
        where T1 : IData where T2 : IData where T3 : IData
    {
        private Execute<T1, T2, T3> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>());
        }

        public void SetAction(IDataAction<T1, T2, T3> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3, T4> : BaseSystemAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData
    {
        private Execute<T1, T2, T3, T4> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>(), entity.GetData<T4>());
        }

        public void SetAction(IDataAction<T1, T2, T3, T4> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3, T4, T5> : BaseSystemAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData
    {
        private Execute<T1, T2, T3, T4, T5> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>());
        }

        public void SetAction(IDataAction<T1, T2, T3, T4, T5> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3, T4, T5, T6> : BaseSystemAction
         where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData
    {
        private Execute<T1, T2, T3, T4, T5, T6> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>());
        }
        public void SetAction(IDataAction<T1, T2, T3, T4, T5, T6> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3, T4, T5, T6, T7> : BaseSystemAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData
    {
        private Execute<T1, T2, T3, T4, T5, T6, T7> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>()
                , entity.GetData<T7>());
        }

        public void SetAction(IDataAction<T1, T2, T3, T4, T5, T6, T7> dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1, T2, T3, T4, T5, T6, T7, T8> : BaseSystemAction
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData where T8 : IData
    {
        private Execute<T1, T2, T3, T4, T5, T6, T7, T8> actions;

        public override void Execute(Entity entity, int id)
        {
            actions?.Invoke(
                id, entity.GetData<T1>(), entity.GetData<T2>(), entity.GetData<T3>()
                , entity.GetData<T4>(), entity.GetData<T5>(), entity.GetData<T6>()
                , entity.GetData<T7>(), entity.GetData<T8>());
        }

        public void SetAction(IDataAction<T1, T2, T3, T4, T5, T6, T7, T8> dataAction)
        {
            actions = dataAction.Execute;
        }
    }
}
