using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Entities.Listener
{
    static class ListenerManager
    {
        private static int count;

        public static void Init(Type[] types)
        {
            //Console.WriteLine(types[0].GetInterface("LE_Entities.Listener.IListener`1").GetGenericArguments()[0].FullName);
            Type type1 = typeof(ActionListener<>);
            count = types.Length;
            for (int i = 0; i < types.Length; i++)
            {
                //for (int j = 0; j < types[i].GetGenericArguments().Length; j++)
                //{
                //    Console.WriteLine(types[i].GetGenericArguments()[j].FullName);
                //}
                var t = types[i].GetInterface("LE_Entities.Listener.IListener`1").GetGenericArguments();
                type1.MakeGenericType(t).GetMethod("AddListener", BindingFlags.Static | BindingFlags.Public)
                   .Invoke(null, new object[] { GetMark(types[i]), LE_Type.LEType.CreateInstance(types[i]) });

                LE_Log.Log.Info("ListenerRegister", "ListenerName: {0}", types[i].FullName);
            }
            // datatype.MakeGenericType(types).GetProperty("dataBlockManager", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

        }

        private static bool[] GetMark(Type type)
        {
            //Console.WriteLine("23333333");
            bool[] marks = new bool[5];
            if (Attribute.GetCustomAttribute(type, typeof(ActiveTimeAttribute)) is ActiveTimeAttribute activeTime)
            {
                marks[0] = activeTime.ActiveChance.HasFlag(ActiveChance.OnCreate);
                marks[1] = activeTime.ActiveChance.HasFlag(ActiveChance.OnAdd);
                marks[2] = activeTime.ActiveChance.HasFlag(ActiveChance.OnChange);
                marks[3] = activeTime.ActiveChance.HasFlag(ActiveChance.OnRemove);
                marks[4] = activeTime.ActiveChance.HasFlag(ActiveChance.OnDestory);
            }
            else
            {
                marks[2] = true;

                LE_Log.Log.Warning("Listener Register Warning", "Listener : {0} does not has any activeChance", type.FullName);
            }
            return marks;
        }
    }
}
