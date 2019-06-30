using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class DataActionAttribute : Attribute
    {
        private Type dataType;
        private int level;

        public DataActionAttribute(Type dataType, int level = 0)
        {
            this.dataType = dataType;
            this.level = level;
        }

        
        public int Level { get => level; set => level = value; }
    }
}
