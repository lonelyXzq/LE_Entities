using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EntityActionAttribute : Attribute
    {
        private readonly int level;
        private readonly Type type;


        public EntityActionAttribute(Type type, int level = 0)
        {
            this.level = level;
            this.type = type;
        }

        public int Level  => level; 
        public Type Type  => type;

    }
}
