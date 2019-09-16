using LE_Entities.Entity;
using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    class DataBlockManager<T> : IDataBlockManager where T : IData
    {
        private readonly ISList<DataBlock<T>> list;

        public DataBlockManager()
        {
            list = new SteadyList<DataBlock<T>>();
        }

        public bool CheckBlock(int id)
        {
            return list.Check(id);
        }

        public int AddBlock()
        {
            var t = new DataBlock<T>();
            int id = list.Add(t);
            return id;
        }

        public DataBlock<T> GetBlock(int blockId)
        {
            if (CheckBlock(blockId))
            {
                return list[blockId];
            }
            return null;
        }

        public void RemoveBlock(int blockId)
        {
            list.Remove(blockId);
        }

        public void RemoveData(int blockId, int localId)
        {

            var datas = GetBlock(blockId);
            if (datas != null)
            {
                Listener.ActionListener<T>.Listeners[4]?.Invoke(localId, ref datas.Datas[localId]);
                datas.Datas[localId] = default;
            }

        }

        public void RemoveDatas(int blockId, List<int> localIds)
        {
            var datas = GetBlock(blockId);
            if (datas != null)
            {
                foreach (var localId in localIds)
                {
                    Listener.ActionListener<T>.Listeners[4]?.Invoke(localId, ref datas.Datas[localId]);
                    datas.Datas[localId] = default;
                }
            }

        }

        //public void ChanngeData(int blockId, int localId, int entityId, Execute<T> execute)
        //{
        //    var datas = GetBlock(blockId);
        //    if (datas != null)
        //    {
        //        execute?.Invoke(entityId, ref datas.Datas[localId]);
        //        Listener.ActionListener<T>.Listeners[2]?.Invoke(localId, ref datas.Datas[localId]);
        //    }
        //}

        public void SetData(int blockId, int localId, IData data)
        {
            var datas = GetBlock(blockId);
            if (datas != null)
            {
                //Listener.ActionListener<T>.Listeners[4]?.Invoke(localId, ref datas.Datas[localId]);
                //datas.Datas[localId] = (T)data;
                if (data is T d)
                {
                    Listener.ActionListener<T>.Listeners[2]?.Invoke(localId, ref d);
                    datas.Datas[localId] = d;
                }
                else
                {

                    LE_Log.Log.Error("data set error", "dataType : {0} is not type : {1}", data.GetType(), typeof(T));
                }
            }
        }

    }
}
