using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    interface IBaseEntityGroup : IObject, IProcess
    {

    }

    interface IEntityGroup : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3, T4> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3, T4, T5> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3, T4, T5, T6> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3, T4, T5, T6, T7> : IBaseEntityGroup
    {

    }

    interface IEntityGroup<T1, T2, T3, T4, T5, T6, T7, T8> : IBaseEntityGroup
    {

    }
}
