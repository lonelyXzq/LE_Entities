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

        public void SetData<T>(T data) where T : IData
        {
            //Listener.ActionListener<T>.Listeners[2]?.Invoke(Id, ref data);
            entityData.EntityBlock.SetData(entityData.LocalId, data);

        }

        public void ChangeData<T>(Execute<T> execute) where T : IData
        {
            entityData.EntityBlock.ChangeData(entityData.LocalId, execute);
        }

        public void SetData_UnSafy(int datatTypeId,IData data)
        {
            entityData.EntityBlock.SetData_UnSafy(datatTypeId,entityData.LocalId, data);
        }

        public void SetName(string name)
        {
            entityData.Name = name;
        }

        public bool AddData<T>(T data) where T : IData
        {
            //Listener.ActionListener<T>.Listeners[0]?.Invoke(Id, ref data);
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
