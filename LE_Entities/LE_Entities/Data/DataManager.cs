using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Data
{
    public static class DataManager
    {
        public static int Count;
        private static IDataBlockManager[] dataBlockManagers;

        public static IDataBlockManager[] DataBlockManagers => dataBlockManagers;

        public static void Init()
        {
            var types = LE_Type.LEType.GetTypes(
                t => t.GetInterfaces().Contains(typeof(IData)));
            Type type1 = typeof(DataInfo<>);
            Count = types.Length;
            dataBlockManagers = new IDataBlockManager[Count];
            for (int i = 0; i < types.Length; i++)
            {
                type1.MakeGenericType(types[i]).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                   .Invoke(null, null);
                LE_Log.Log.Info("DataRegister", "DataId: {0}  DataName: {1}", i, types[i].FullName);

            }
        }

        public static void AddDataType(int id, IDataBlockManager dataBlockManager)
        {
            dataBlockManagers[id] = dataBlockManager;
        }
    }
}
