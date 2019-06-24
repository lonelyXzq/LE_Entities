using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public interface IEntityAction
    {
        void Execute(int id);
    }
    public interface IEntityAction<T1>
    {
        void Execute(int id, T1 t1);
    }

    public interface IEntityAction<T1, T2>
    {
        void Execute(int id, T1 t1, T2 t2);
    }

    public interface IEntityAction<T1, T2, T3>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3);
    }

    public interface IEntityAction<T1, T2, T3, T4>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    }

    public interface IEntityAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Execute(int id, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
    }
}
