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
    static class ActionManager
    {

        public static string ToString(this BitArray bitArray)
        {
            return "";
        }
        private static readonly Dictionary<string, ISystemAction> systemActinos = new Dictionary<string, ISystemAction>();

        static ActionManager()
        {
            GroupAction.Init();
            //DateTime t0 = DateTime.Now;
            var types = LEType.GetTypes(t => t.GetInterfaces().Contains(typeof(ILE_Data)));
            foreach (var type in types)
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    Console.WriteLine(type.FullName);
                    Add(type);
                }
            }
            //Console.WriteLine((DateTime.Now - t0).TotalMilliseconds);
        }

        public static void Init()
        {

        }

        private static void Add(Type type)
        {

            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionAttribute)) is EntityActionAttribute actionAttribute))
            {
                ISystemAction systemAction = GetSystemAction(type);
                systemAction.Execute(1);
            }
            else
            {
                ISystemAction systemAction = GetSystemAction(type);
                systemAction.Execute(1);
            }
        }

        private static ISystemAction GetSystemAction(Type type)
        {
            int length = type.GetMethod("Execute").GetParameters().Length - 1;

            string name = type.GetInterface("IDataAction`" + length).FullName;
            Console.WriteLine(name);
            string re = name.Replace("IDataAction", "Entity.SystemAction");
            ISystemAction systemAction = LEType.CreateInstance<ISystemAction>(re);
            MethodInfo methodInfo = systemAction.GetType().GetMethod("SetAction");
            methodInfo.Invoke(systemAction, new object[] { type.Assembly.CreateInstance(type.FullName) });
            return systemAction;
        }
    }
}
