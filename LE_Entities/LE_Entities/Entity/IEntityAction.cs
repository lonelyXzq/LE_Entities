using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public delegate void Execute(int id);
    public delegate void Execute<T1>(int id, T1 t1);
    public delegate void Execute<T1, T2>(int id, T1 t1, T2 t2);
    public delegate void Execute<T1, T2, T3>(int id, T1 t1, T2 t2, T3 t3);
    public delegate void Execute<T1, T2, T3, T4>(int id, T1 t1, T2 t2, T3 t3, T4 t4);
    public delegate void Execute<T1, T2, T3, T4, T5>(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    public delegate void Execute<T1, T2, T3, T4, T5, T6>(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    public delegate void Execute<T1, T2, T3, T4, T5, T6, T7>(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    public delegate void Execute<T1, T2, T3, T4, T5, T6, T7, T8>(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);

    public interface IEntityAction
    {
        void Execute(int id);
    }
    public interface IEntityAction<T1> where T1 : IData
    {
        void Execute(int id, T1 t1);
    }

    public interface IEntityAction<T1, T2>
        where T1 : IData where T2 : IData
    {
        void Execute(int id, T1 t1, T2 t2);
    }

    public interface IEntityAction<T1, T2, T3>
        where T1 : IData where T2 : IData where T3 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3);
    }

    public interface IEntityAction<T1, T2, T3, T4>
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5>
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6>
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6, T7>
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6, T7, T8>
        where T1 : IData where T2 : IData where T3 : IData where T4 : IData where T5 : IData where T6 : IData where T7 : IData where T8 : IData
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
    }
}
