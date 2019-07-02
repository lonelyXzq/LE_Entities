using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    interface IEntity:IObject
    {
        bool AddData<T>(T data) where T : IData;

        void RemoveData<T>() where T : IData;

        T GetData<T>() where T : IData;

        bool TryGetData<T>(out T data) where T : IData;
    }
}
