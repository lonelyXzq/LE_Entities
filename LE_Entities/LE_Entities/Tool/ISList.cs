using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{

    interface ISList<T>
    {
        int Count { get; }

        int Length { get; }

        T this[int index] { get; set; }

        bool Check(int index);
        int Add(T data);
        void Remove(int index);
        void Clear();

        T[] GetAllDatas();

        T[] FindData(Seek<T> seek);
    }


}
