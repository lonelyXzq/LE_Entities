using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.VThread
{
    public delegate void VThreadAction();

    interface IVThread : IProcess
    {
        string Name { get; }

        int Id { get; }

        void SetAction(VThreadState state,VThreadAction vThreadAction);
    }
}
