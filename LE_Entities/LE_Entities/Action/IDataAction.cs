using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{
    public interface ILE_Data
    {

    }

    public interface IDataAction:ILE_Data
    {
        void Execute(int id);
    }
    public interface IDataAction<T1> : ILE_Data where T1 : IData
    {
        void Execute(int id, T1 t1);
    }

    public interface IDataAction<T1, T2> : ILE_Data
        where T1 : IData where T2 : IData
    {
        void Execute(int id, T1 t1, T2 t2);
    }

    public interface IDataAction<T1, T2, T3> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3);
    }

    public interface IDataAction<T1, T2, T3, T4> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4);
    }

    public interface IDataAction<T1, T2, T3, T4, T5> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }

    public interface IDataAction<T1, T2, T3, T4, T5, T6> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    }

    public interface IDataAction<T1, T2, T3, T4, T5, T6, T7> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    }

    public interface IDataAction<T1, T2, T3, T4, T5, T6, T7, T8> : ILE_Data
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData where T8 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
    }
}
