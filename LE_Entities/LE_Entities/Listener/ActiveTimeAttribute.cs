using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Listener
{
    [Flags]
    public enum ActiveChance
    {
        OnCreate = 1,
        OnAdd = 2,
        OnChange = 4,
        OnRemove = 8,
        OnDestory = 16
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ActiveTimeAttribute : Attribute
    {
        private readonly ActiveChance activeChance;

        public ActiveTimeAttribute(ActiveChance activeChance)
        {
            //Console.WriteLine(activeChance);
            this.activeChance = activeChance;
        }

        public ActiveChance ActiveChance => activeChance;
    }
}
