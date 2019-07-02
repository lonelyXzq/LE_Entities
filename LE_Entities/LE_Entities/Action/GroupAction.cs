using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Action
{
    static class GroupAction
    {
        private static readonly Dictionary<string, EntityType> entityTypes=new Dictionary<string, EntityType>();

        public static void Init()
        {
            int count = 0;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.BaseType==typeof(EntityType)))
                .ToArray();
            foreach (var type in types)
            {

                if (type.IsClass)
                {
                    count++;
                    entityTypes.Add(type.FullName,type.Assembly.CreateInstance(type.FullName) as EntityType);
                }
            }
        }

        public static EntityType GetEntityType(Type type)
        {
            return entityTypes.ContainsKey(type.FullName) ? entityTypes[type.FullName] : null;
        }
    }
}
