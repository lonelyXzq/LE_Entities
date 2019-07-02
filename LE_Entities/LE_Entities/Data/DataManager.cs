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
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                type1.MakeGenericType(type).GetMethod("Init", BindingFlags.Static|BindingFlags.Public)
                    .Invoke(null,null);
            }
        }
    }
}
