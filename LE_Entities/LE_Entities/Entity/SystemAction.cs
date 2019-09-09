using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Entities.Entity
{
    interface ISystemAction : IObject
    {
        BitArray DataInfo { get; }

        void Update(EntityBlock entityBlock);

        void Execute(EntityBlock entityBlock);

    }

    abstract class BaseSystemAction : ISystemAction
    {
        protected readonly string name;

        private readonly int id;

        private readonly BitArray dataInfo;

        protected int cycle = 0;

        public string Name => name;

        public int Id => id;

        public BitArray DataInfo => dataInfo;

        internal int Cycle => cycle;

        private int nowCycle = 0;


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

        public abstract void Execute(EntityBlock entityBlock);

        public void Update(EntityBlock entityBlock)
        {
            if (nowCycle == cycle)
            {
                Execute(entityBlock);
                nowCycle = 0;
            }
            else
            {
                nowCycle++;
            }
        }
    }
    class SystemAction : BaseSystemAction
    {
        private Execute actions;

        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i);
                }
            }
        }

        public void SetAction(IDataAction dataAction)
        {
            actions = dataAction.Execute;
        }
    }

    class SystemAction<T1> : BaseSystemAction where T1 : IData
    {
        private Execute<T1> actions;

        public void SetAction(IDataAction<T1> dataAction)
        {
            actions = dataAction.Execute;
        }

        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i, ref d1[i]);
                }
            }
        }
    }

    class SystemAction<T1, T2> : BaseSystemAction
        where T1 : IData where T2 : IData
    {
        private Execute<T1, T2> actions;


        public override void Execute(EntityBlock entityBlock)
        {
            //Console.WriteLine(entityBlock.BlockId);
            //Console.WriteLine(entityBlock.EntityType.Name);
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i, ref d1[i], ref d2[i]);
                }
            }
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


        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i, ref d1[i], ref d2[i], ref d3[i]);
                }
            }
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

        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            T4[] d4 = entityBlock.GetDataBlock<T4>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i, ref d1[i], ref d2[i], ref d3[i], ref d4[i]);
                }
            }
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


        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            T4[] d4 = entityBlock.GetDataBlock<T4>().Datas;
            T5[] d5 = entityBlock.GetDataBlock<T5>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i,
                        ref d1[i], ref d2[i], ref d3[i], ref d4[i],
                        ref d5[i]);
                }
            }
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


        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            T4[] d4 = entityBlock.GetDataBlock<T4>().Datas;
            T5[] d5 = entityBlock.GetDataBlock<T5>().Datas;
            T6[] d6 = entityBlock.GetDataBlock<T6>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i,
                        ref d1[i], ref d2[i], ref d3[i], ref d4[i],
                        ref d5[i], ref d6[i]);
                }
            }
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


        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            T4[] d4 = entityBlock.GetDataBlock<T4>().Datas;
            T5[] d5 = entityBlock.GetDataBlock<T5>().Datas;
            T6[] d6 = entityBlock.GetDataBlock<T6>().Datas;
            T7[] d7 = entityBlock.GetDataBlock<T7>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i,
                        ref d1[i], ref d2[i], ref d3[i], ref d4[i],
                        ref d5[i], ref d6[i], ref d7[i]);
                }
            }
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


        public override void Execute(EntityBlock entityBlock)
        {
            int bid = entityBlock.BlockId << DataBlockInfo.BlockSizePow;
            T1[] d1 = entityBlock.GetDataBlock<T1>().Datas;
            T2[] d2 = entityBlock.GetDataBlock<T2>().Datas;
            T3[] d3 = entityBlock.GetDataBlock<T3>().Datas;
            T4[] d4 = entityBlock.GetDataBlock<T4>().Datas;
            T5[] d5 = entityBlock.GetDataBlock<T5>().Datas;
            T6[] d6 = entityBlock.GetDataBlock<T6>().Datas;
            T7[] d7 = entityBlock.GetDataBlock<T7>().Datas;
            T8[] d8 = entityBlock.GetDataBlock<T8>().Datas;
            int[] mark = entityBlock.DataBlockInfo.Marks;
            for (int i = 0; i < DataBlockInfo.BlockSize; i++)
            {
                if (mark[i] == -1)
                {
                    actions?.Invoke(bid + i,
                        ref d1[i], ref d2[i], ref d3[i], ref d4[i],
                        ref d5[i], ref d6[i], ref d7[i], ref d8[i]);
                }
            }
        }

        public void SetAction(IDataAction<T1, T2, T3, T4, T5, T6, T7, T8> dataAction)
        {
            actions = dataAction.Execute;
        }
    }
}
