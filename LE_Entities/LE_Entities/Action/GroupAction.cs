using LE_Entities.Entity;
using LE_Entities.LE_Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Action
{
    static class GroupAction
    {
        private static readonly Dictionary<string, EntityType> entityTypes = new Dictionary<string, EntityType>();
        public static readonly int TypeCount;

        static GroupAction()
        {
            Type bt = typeof(EntityType);
            DateTime t0 = DateTime.Now;
            var types = LEType.GetTypes(t => t.BaseType == bt);
            TypeCount = types.Length;
            foreach (var type in types)
            {
                entityTypes.Add(type.FullName, LEType.CreateInstance<EntityType>(type));
            }
            Console.WriteLine("Time:" + (DateTime.Now - t0).TotalMilliseconds);
        }

        public static void Init()
        {
        }

        public static EntityType GetEntityType(Type type)
        {
            return entityTypes.ContainsKey(type.FullName) ? entityTypes[type.FullName] : null;
        }
    }
}
