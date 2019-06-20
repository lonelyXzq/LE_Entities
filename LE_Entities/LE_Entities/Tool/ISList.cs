using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    interface ISList<T>
    {
        bool Check(int index);
        void Add(T data);
        void Remove(int index);
        void Clear();

    }


}
