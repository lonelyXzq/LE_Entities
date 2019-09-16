using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    internal class DataBlock<T>
    {

        public T[] Datas;

        public DataBlock()
        {
            Datas = new T[DataBlockInfo.BlockSize];
        }


        public T this[int index]
        {
            get
            {
                return Datas[index];
            }
        }

        public T GetData(int i)
        {
            return Datas[i];
        }

        public void ChangeData(int i, int entityId, Execute<T> execute)
        {
            execute?.Invoke(entityId, ref Datas[i]);
        }

        public void SetData(int i, T data)
        {
            Datas[i] = data;
        }

    }
}
