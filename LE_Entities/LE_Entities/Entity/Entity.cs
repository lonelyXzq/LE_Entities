using System;
using System.Collections.Generic;
using System.Text;
using LE_Entities.Data;

namespace LE_Entities.Entity
{
    class Entity:IEntity
    {
        private readonly string name;
        private readonly int id;
        private readonly int[] datas;

        public Entity(string name, int id)
        {
            this.name = name;
            this.id = id;
            this.datas = new int[DataManager.Count];
        }

        public string Name => name;

        public int Id => id;

        public bool AddData<T>(T data) where T : IData
        {
            if (datas[DataInfo<T>.DataId] > 0)
            {
                return false;
            }
            datas[DataInfo<T>.DataId] = DataInfo<T>.DataChain.Add(data);
            return true;
        }

        public T GetData<T>() where T : IData
        {
            return DataInfo<T>.DataChain.GetData(datas[DataInfo<T>.DataId]);
        }

        public void RemoveData<T>() where T : IData
        {
            DataInfo<T>.DataChain.RemoveData(datas[DataInfo<T>.DataId]);
            datas[DataInfo<T>.DataId] = 0;
        }
    }
}
