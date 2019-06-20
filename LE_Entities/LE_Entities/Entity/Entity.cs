using System;
using System.Collections.Generic;
using System.Text;
using LE_Entities.Data;

namespace LE_Entities.Entity
{
    class Entity:IEntity
    {
        public string Name => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public bool AddData<T>(T data) where T : IData
        {
            throw new NotImplementedException();
        }

        public T GetData<T>() where T : IData
        {
            throw new NotImplementedException();
        }

        public void RemoveData<T>() where T : IData
        {
            throw new NotImplementedException();
        }
    }
}
