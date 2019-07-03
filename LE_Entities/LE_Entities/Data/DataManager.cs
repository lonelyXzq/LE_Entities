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

        public static void Init()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IData))))
                .ToArray();
            Type type1 = typeof(DataInfo<>);
            Count = types.Length;
            for (int i = 0; i < types.Length; i++)
            {
                type1.MakeGenericType(types[i]).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                   .Invoke(null, null);
                LE_Log.Log.Info("DataRegister", "DataId: {0}  DataName: {1}", i, types[i].FullName);

            }
        }
    }
}
