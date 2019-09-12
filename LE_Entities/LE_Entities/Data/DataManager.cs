using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Data
{


    public static class DataManager
    {
        private static int count;

        private static IDataBlockManager[] dataBlockManagers;

        public static int Count => count;

        internal static IDataBlockManager[] DataBlockManagers => dataBlockManagers;

        static DataManager()
        {
           
        }


        internal static void Register(Type[] types)
        {
            Type type1 = typeof(DataInfo<>);
            count = types.Length;
            dataBlockManagers = new IDataBlockManager[count];
            for (int i = 0; i < types.Length; i++)
            {
                //type1.MakeGenericType(types[i]).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                //   .Invoke(null, null);
                dataBlockManagers[i] = (IDataBlockManager)type1.MakeGenericType(types[i]).GetProperty("DataBlockManager", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);



                LE_Log.Log.Info("DataRegister", "DataId: {0}  DataName: {1}", i, types[i].FullName);
            }
        }

        public static void Init()
        {
            if (dataBlockManagers == null)
            {
                var types = LE_Type.LEType.GetTypes(
                    t => t.GetInterfaces().Contains(typeof(IData)));
                Register(types);
            }
        }

        //internal static void AddDataType(int id, IDataBlockManager dataBlockManager)
        //{
        //    dataBlockManagers[id] = dataBlockManager;
        //}
    }
}
