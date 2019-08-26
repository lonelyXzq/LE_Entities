using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    class DataBlockManager<T> : IDataBlockManager
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
            t.SetId(id);
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
    }
}
