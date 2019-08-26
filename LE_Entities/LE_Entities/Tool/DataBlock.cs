using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    public class DataBlock<T>
    {
        //private readonly DataBlockInfo blockInfo;
        private readonly T[] datas;
        private int id;

        public DataBlock()
        {
            datas = new T[DataBlockInfo.BlockSize];
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public T this[int index]
        {
            get
            {
                return datas[index];
            }
        }

        public T GetData(int i)
        {
            return datas[i];
        }

        public void SetData(int i,T data)
        {
            datas[i] = data;
        }

        public T[] Datas => datas;

        public int Id => id;
    }
}
