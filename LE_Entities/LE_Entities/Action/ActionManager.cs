using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Action
{
    static class ActionManager
    {

        public static void Init()
        {
            GroupAction.Init();
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ILE_Data))))
                .ToArray();
            foreach (var type in types)
            {
                if (type.IsClass&&!type.IsAbstract)
                {
                    Console.WriteLine(type.FullName);
                    Add(type);
                }
                //type1.MakeGenericType(type).GetMethod("Init", BindingFlags.Static | BindingFlags.Public)
                //    .Invoke(null, null);
            }
        }

        private static void Add(Type type)
        {
            var method = type.GetMethod("Execute");
            int length = method.GetParameters().Length - 1;
            //var types = type.GetInterface("IDataAction`" + length).GetGenericArguments();
            //Console.WriteLine(length);
            //Console.WriteLine(typeof(SystemAction).FullName);
            //Console.WriteLine(method.Name);
            //var t = method.GetParameters();
            //for (int i = 0; i < t.Length; i++)
            //{
            //    Console.WriteLine(t[i].Name);
           // }
            object ob= type.Assembly.CreateInstance(type.FullName);

            //Console.WriteLine();
            //Console.WriteLine(typeof(Execute<,>).MakeGenericType(types).FullName);
            //object[] parameters = new object[1]
            //{
            //null
            //Delegate.CreateDelegate(typeof(Execute<,>).MakeGenericType(types),type,"Execute",true,true)
            //};
            //Console.WriteLine(type.GetInterface("IDataAction`" + length).FullName);
           // Console.WriteLine(typeof(SystemAction).FullName + "`" + length);
            string name = type.GetInterface("IDataAction`" + length).FullName;
            //Console.WriteLine(name);
            string re = name.Replace("LE_Entities.IDataAction", typeof(SystemAction).FullName);
           // Console.WriteLine(re);
            //Console.WriteLine(typeof(SystemAction).Assembly.CreateInstance(re)+":233333333333");
            ISystemAction systemAction = typeof(SystemAction).Assembly.CreateInstance(re) as ISystemAction;
            Type st = systemAction.GetType();
            MethodInfo methodInfo = st.GetMethod("AddAction");
            methodInfo.Invoke(systemAction, new object[]{ ob});
            systemAction.Execute(1);
            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionAttribute)) is EntityActionAttribute actionAttribute))
            {

            }
            else
            {
            }
        }
    }
}
