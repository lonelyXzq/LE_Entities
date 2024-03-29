﻿using LE_Entities.Data;
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
        private static readonly List<EntityType> entityTypes = new List<EntityType>();

        private static readonly Dictionary<string, int> idchanges = new Dictionary<string, int>();

        public static readonly int TypeCount;

        static EntityTypeManager()
        {
            Type bt = typeof(EntityType);
            var types = LEType.GetTypes(t => t.BaseType == bt);
            TypeCount = types.Length;
            for (int i = 0; i < TypeCount; i++)
            {
                Add(types[i], i);
            }
        }

        public static void Init()
        {

        }

        private static void Add(Type type, int id)
        {
            EntityType entityType = LEType.CreateInstance<EntityType>(type);
            entityTypes.Add(entityType);
            idchanges.Add(type.FullName, id);
            var infos = type.GetFields();
            Type dataTyep = typeof(DataInfo<>);
            var eType = (BitArray)typeof(EntityType).GetField("dataInfo",BindingFlags.NonPublic|BindingFlags.Instance)
                    .GetValue(entityType);
            eType.Set(DataInfo<EntityData>.DataId, true);
            for (int i = 0; i < infos.Length; i++)
            {
                Type t = infos[i].FieldType;
                if (t.GetInterfaces().Contains(typeof(IData)))
                {
                    int index=(int)dataTyep.MakeGenericType(t).GetField("dataId", BindingFlags.NonPublic | BindingFlags.Static)
                        .GetValue(null);
                    eType.Set(index, true);
                }
            }
        }

        public static EntityType GetEntityType(int id)
        {
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
