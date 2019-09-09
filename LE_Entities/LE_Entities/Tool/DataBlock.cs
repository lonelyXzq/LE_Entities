using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    public class DataBlock<T>
    {
        private int id;

        public T[] Datas;

        public DataBlock()
        {
            Datas = new T[DataBlockInfo.BlockSize];
        }

        public void SetId(int id)
        {
            this.id = id;
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

        public void SetData(int i,T data)
        {
            Datas[i] = data;
        }

        public int Id => id;
    }
}
