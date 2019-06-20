using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    class DataChain<T> : IDataChain<T>
    {


        public bool CheckData(int id)
        {
            throw new NotImplementedException();
        }

        public T[] FindData(Seek<T> seek)
        {
            throw new NotImplementedException();
        }

        public T[] GetAllData()
        {
            throw new NotImplementedException();
        }

        public T GetData(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(T data)
        {
            throw new NotImplementedException();
        }

        public void RemoveData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
