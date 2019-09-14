
using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Listener
{
    public delegate void ListenerAction<T>(int id, ref T data);

    public interface IListen:IBaseObject
    {

    }

    public interface IListener<T>:IListen where T : IData
    {
        void Execute(int id, ref T data);
    }


}
