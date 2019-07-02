using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ActionAttribute : Attribute
    {
        private readonly ActionType actionType;
        private readonly int level;

        public ActionAttribute(ActionType actionType,int level=0)
        {
            this.actionType = actionType;
            this.level = level;
        }

        

        public ActionType ActionType => actionType;

        public int Level => level;
    }
}
