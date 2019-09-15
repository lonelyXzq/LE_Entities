using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    class DataBlockManager<T> : IDataBlockManager where T : IData
    {
        private readonly SList<DataBlock<T>> list;

        public DataBlockManager()
        {
            list = new SList<DataBlock<T>>();
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
    }
}
