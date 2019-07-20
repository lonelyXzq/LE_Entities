using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    class DataBlock<T>
    {
        private readonly DataBlockInfo blockInfo;
        private readonly T[] datas;

        public DataBlock()
        {
            datas = new T[DataBlockInfo.BlockSize];
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
    }
}
