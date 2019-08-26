using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LE_Entities.LE_Type
{
    public static class LEType
    {
        public static object CreateInstance(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);
        }

        public static T CreateInstance<T>(Type type) where T:class
        {
            return type.Assembly.CreateInstance(type.FullName) as T;
        }

        public static T CreateInstance<T>(string typeName) where T:class
        {
            return typeof(T).Assembly.CreateInstance(typeName) as T;
        }

        public static Type[] GetTypes(Func<Type,bool> func)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(func))
                .ToArray();
        }
    }
}
