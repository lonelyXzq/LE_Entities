using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Action
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EntityActionCycleAttribute : Attribute
    {
        private readonly int cycle;
        public EntityActionCycleAttribute(int cycle)
        {
            this.cycle = cycle;
        }

        public int Cycle => cycle;
    }
}
