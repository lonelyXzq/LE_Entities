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
        private readonly EntityData entityData;

        internal Entity(EntityData entityData)
        {
            this.entityData = entityData;
            AddData(entityData);
        }

        internal Entity(int id,EntityBlock entityBlock)
        {
            entityData = entityBlock.GetData<EntityData>(id & (DataBlockInfo.BlockSize - 1));
        }

        public string Name => entityData.Name;

        public int Id => entityData.Id;

        public T GetData<T>() where T : IData
        {
            return entityData.EntityBlock.GetData<T>(entityData.LocalId);
        }

        internal bool AddData<T>(T data) where T : IData
        {
            entityData.EntityBlock.AddData(entityData.LocalId,data);
            return true;
            //if (datas[DataInfo<T>.DataId] > 0)
            //{
            //    return false;
            //}
            //datas[DataInfo<T>.DataId] = DataInfo<T>.DataChain.Add(data);
            //return true;
        }

        internal void RemoveData<T>() where T : IData
        {
            //DataInfo<T>.DataChain.RemoveData(datas[DataInfo<T>.DataId]);
            //datas[DataInfo<T>.DataId] = 0;
        }

    }
}
