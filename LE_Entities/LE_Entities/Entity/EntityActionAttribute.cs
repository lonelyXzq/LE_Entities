﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{

    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class EntityActionAttribute : Attribute
    {
        private string groupName;
        private int level;

        public EntityActionAttribute(string groupName, int level = 0)
        {
            this.groupName = groupName;
            this.level = level;
        }

        public string GroupName { get => groupName; set => groupName = value; }
        public int Level { get => level; set => level = value; }
    }
}
