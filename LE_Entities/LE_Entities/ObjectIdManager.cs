using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities
{
    public static class ObjectIdManager
    {
        public static string fileName = "save.id";

        private static readonly Dictionary<string, int> idInfos = new Dictionary<string, int>();

        private static readonly Dictionary<string, int> localIds = new Dictionary<string, int>();

        internal static void AddInfo(Type type, int id)
        {
            idInfos.Add(type.FullName, id);
        }

        internal static void AddInfos(List<Type> types)
        {
            for (int i = 0; i < types.Count; i++)
            {
                idInfos.Add(types[i].FullName, i);
            }
        }

        public static int GetId(Type type)
        {
            if (idInfos.TryGetValue(type.FullName, out int id))
            {
                return id;
            }
            LE_Log.Log.Warning("type warning", "type: {0} does not exists", type.FullName);
            return -1;
        }

        public static int GetLocalId(Type type)
        {
            if (localIds.TryGetValue(type.FullName, out int id))
            {
                return id;
            }
            LE_Log.Log.Warning("type warning", "type: {0} does not exists", type.FullName);
            return -1;
        }

        public static void OutputInfos()
        {
            foreach (var data in idInfos)
            {
                LE_Log.Log.Info("idInfo", "name: {0} , id: {1}", data.Key, data.Value);
            }
            foreach (var data in localIds)
            {
                LE_Log.Log.Info("localIdInfo", "name: {0} , id: {1}", data.Key, data.Value);
            }
        }

        public static void ReInitIds()
        {

        }

        public static void SaveIds()
        {

        }

        public static void LoadIds()
        {

        }
    }
}
