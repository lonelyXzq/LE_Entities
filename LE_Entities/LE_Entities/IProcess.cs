using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{
    interface IProcess
    {
        void OnInit();

        void OnStart();

        void OnUpdate();

        void OnEnd();

        void OnDestory();
    }
}
