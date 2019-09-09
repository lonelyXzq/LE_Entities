using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Data
{
    public static class DataManager
    {
        public static readonly int Count;

        private static readonly IDataBlockManager[] dataBlockManagers;

        internal static IDataBlockManager[] DataBlockManagers => dataBlockManagers;

        static DataManager()
        {
            var types = LE_Type.LEType.GetTypes(
                t => t.GetInterfaces().Contains(typeof(IData)));
            Type type1 = typeof(DataInfo<>);
            Count = types.Length;
            dataBlockManagers = new IDataBlockManager[Count];
            for (int i = 0; i < types.Length; i++)
            {
                //type1.MakeGenericType(types[i]).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                //   .Invoke(null, null);
                dataBlockManagers[i] = (IDataBlockManager)type1.MakeGenericType(types[i]).GetProperty("DataBlockManager", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                LE_Log.Log.Info("DataRegister", "DataId: {0}  DataName: {1}", i, types[i].FullName);
            }
        }

        public static void Init()
        {

        }

        //internal static void AddDataType(int id, IDataBlockManager dataBlockManager)
        //{
        //    dataBlockManagers[id] = dataBlockManager;
        //}
    }
}
