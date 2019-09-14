using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Listener
{
    [Flags]
    public enum ActiveChance
    {
        OnCreate,
        OnAdd,
        OnChange,
        OnRemove,
        OnDestory
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ActiveTimeAttribute:Attribute
    {
        private readonly ActiveChance activeChance;

        public ActiveTimeAttribute(ActiveChance activeChance)
        {
            this.activeChance = activeChance;
        }

        public ActiveChance ActiveChance => activeChance;
    }
}
