using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EntityActionAttribute : Attribute
    {
        private readonly Type type;


        public EntityActionAttribute(Type type)
        {
            this.type = type;
        }

        public Type Type => type;

    }
}
