using LE_Entities.Data;
using LE_Entities.Entity;
using LE_Entities.LE_Type;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Action
{
    static class EntityTypeManager
    {
        private static EntityType[] entityTypes;

        private static readonly Dictionary<string, int> idchanges = new Dictionary<string, int>();

        private static int typeCount;

        public static int TypeCount => typeCount;


        static EntityTypeManager()
        {
            
        }

        public static void Init()
        {
            if (entityTypes == null)
            {
                var types = LEType.GetTypes(t => t.GetInterfaces().Contains(typeof(IEntityType)));
                Register(types);
            }
        }

        internal static void Register(Type[] types)
        {
            typeCount = types.Length;
            entityTypes = new EntityType[TypeCount];
            for (int i = 0; i < TypeCount; i++)
            {
                entityTypes[i] = new EntityType();
                Add(types[i], i);
            }
        }

        private static void Add(Type type, int id)
        {
            IEntityType entityType = LEType.CreateInstance<IEntityType>(type);
            
            idchanges.Add(type.FullName, id);
            var infos = type.GetFields();
            Type dataTyep = typeof(DataInfo<>);
            BitArray eType = entityTypes[id].DataInfo;
            eType.Set(DataInfo<EntityData>.DataId, true);
            for (int i = 0; i < infos.Length; i++)
            {
                Type t = infos[i].FieldType;
                if (t.GetInterfaces().Contains(typeof(IData)))
                {
                    //Console.WriteLine(t.FullName);
                    int index=(int)dataTyep.MakeGenericType(t).GetField("dataId", BindingFlags.NonPublic | BindingFlags.Static)
                        .GetValue(null);
                    //Console.WriteLine(index);
                    eType.Set(index, true);
                }
            }
            entityTypes[id].SetEntityType(entityType);
        }

        public static EntityType GetEntityType(int id)
        {
            //Range set
            return entityTypes[id];
        }

        public static int GetEntityTypeId(Type type)
        {
            if (idchanges.TryGetValue(type.FullName, out int id))
            {
                return id;
            }
            return -1;
        }
    }
}
