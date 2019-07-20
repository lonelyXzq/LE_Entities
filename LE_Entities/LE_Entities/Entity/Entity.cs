using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LE_Entities.Data;

namespace LE_Entities.Entity
{
    public class Entity:IEntity
    {
        private readonly string name;
        private readonly int id;
        private readonly int[] datas;
        private readonly int groupId;

        private int mark;

        public Entity(string name,int groupId)
        {
            this.groupId = groupId;
            this.name = name;
            this.datas = new int[DataManager.Count];
            this.mark = 0;
        }

        public string Name => name;

        public int Id => id;

        public int GroupId => groupId;

        public T GetData<T>() where T : IData
        {
            return DataInfo<T>.DataChain.GetData(datas[DataInfo<T>.DataId]);
        }

        public bool TryGetData<T>(out T data) where T : IData
        {
            data = default;
            return false;
            //if(Interlocked.CompareExchange(ref mark, 1, 0) == 0)
            //{
            //    data = GetData<T>();
            //    mark = 0;
            //    return true;
            //}
            //else
            //{
            //    data = default;
            //    return false;
            //}
        }

        public bool AddData<T>(T data) where T : IData
        {
            if (datas[DataInfo<T>.DataId] > 0)
            {
                return false;
            }
            datas[DataInfo<T>.DataId] = DataInfo<T>.DataChain.Add(data);
            return true;
        }

        public void RemoveData<T>() where T : IData
        {
            DataInfo<T>.DataChain.RemoveData(datas[DataInfo<T>.DataId]);
            datas[DataInfo<T>.DataId] = 0;
        }

    }
}
