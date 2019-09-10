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

        int ThreadId { get; set; }

        void SetAction(IProcess process);

        void SetAction(VThreadState state,VThreadAction vThreadAction);
    }
}
