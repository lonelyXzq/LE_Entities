using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LE_Entities.Data;
using LE_Entities.Tool;

namespace LE_Entities.Entity
{
    public class Entity:IEntity
    {
        private readonly string name;
        private readonly int id;
        private readonly EntityBlock entityBlock;

        public Entity(string name,int id)
        {
            this.name = name;
            this.id = id;
            entityBlock = EntityBlockManager.
                GetEntityBlock(id >> DataBlockInfo.BlockSizePow);
        }

        public string Name => name;

        public int Id => id;

        public T GetData<T>() where T : IData
        {
            return entityBlock.GetData<T>(id&(DataBlockInfo.BlockSize-1));
        }

        //public bool TryGetData<T>(out T data) where T : IData
        //{
        //    data = default;
        //    return false;
        //    //if(Interlocked.CompareExchange(ref mark, 1, 0) == 0)
        //    //{
        //    //    data = GetData<T>();
        //    //    mark = 0;
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    data = default;
        //    //    return false;
        //    //}
        //}

        public bool AddData<T>(T data) where T : IData
        {
            entityBlock.AddData(id & (DataBlockInfo.BlockSize - 1),data);
            return true;
            //if (datas[DataInfo<T>.DataId] > 0)
            //{
            //    return false;
            //}
            //datas[DataInfo<T>.DataId] = DataInfo<T>.DataChain.Add(data);
            //return true;
        }

        public void RemoveData<T>() where T : IData
        {
            //DataInfo<T>.DataChain.RemoveData(datas[DataInfo<T>.DataId]);
            //datas[DataInfo<T>.DataId] = 0;
        }

    }
}
