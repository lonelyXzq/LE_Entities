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

        private static readonly List<ISystemAction> systemActions = new List<ISystemAction>();

        internal static List<ISystemAction> SystemActions => systemActions;

        static ActionManager()
        {
            EntityTypeManager.Init();
            List<ISystemAction>[] groupActions = new List<ISystemAction>[EntityTypeManager.TypeCount];
            for (int i = 0; i < groupActions.Length; i++)
            {
                groupActions[i] = new List<ISystemAction>();
            }
            //DateTime t0 = DateTime.Now;
            var types = LEType.GetTypes(t => t.GetInterfaces().Contains(typeof(ILE_Data)));
            foreach (var type in types)
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    //Console.WriteLine(type.FullName);
                    Add(type, groupActions);
                }
            }
            for (int i = 0; i < groupActions.Length; i++)
            {
                //for (int j = 0; j < groupActions[i].Count; j++)
                //{
                //    Console.WriteLine(groupActions[i][j].Id);
                //}
                EntityTypeManager.GetEntityType(i).SetAction(groupActions[i].ToArray());
            }
            //Console.WriteLine((DateTime.Now - t0).TotalMilliseconds);
        }

        public static void Init()
        {

        }


        public static bool Contain(this BitArray b1, BitArray b2)
        {
            if (b1.Length != b2.Length)
            {
                return false;
            }
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] == false && b2[i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        private static void Add(Type type, List<ISystemAction>[] groupActions)
        {
            ISystemAction systemAction = GetSystemAction(type);
            LE_Log.Log.Info("ActionRegister", "ActionId: {0}  ActionName: {1}", systemAction.Id, systemAction.Name);

            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionAttribute)) is EntityActionAttribute actionAttribute))
            {
                groupActions[EntityTypeManager.GetEntityTypeId(actionAttribute.Type)].Add(systemAction);
            }
            else
            {
                for (int i = 0; i < groupActions.Length; i++)
                {
                    if (EntityTypeManager.GetEntityType(i).DataInfo.Contain(systemAction.DataInfo))
                    {
                        groupActions[i].Add(systemAction);
                    }
                }
            }
        }

        private static ISystemAction GetSystemAction(Type type)
        {
            int length = type.GetMethod("Execute").GetParameters().Length - 1;

            string name = type.GetInterface("IDataAction`" + length).FullName;
            string re = name.Replace("IDataAction", "Entity.SystemAction");
            ISystemAction systemAction = LEType.CreateInstance<ISystemAction>(re);
            Type sysType = systemAction.GetType();
            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionCycleAttribute)) is EntityActionCycleAttribute actionCycleAttribute))
            {
                sysType.GetField("cycle", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(systemAction, actionCycleAttribute.Cycle);
            }
            sysType.GetField("name", BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance).SetValue(systemAction, type.FullName);
            MethodInfo methodInfo = sysType.GetMethod("SetAction");
            methodInfo.Invoke(systemAction, new object[] { type.Assembly.CreateInstance(type.FullName) });
            systemActions.Add(systemAction);
            return systemAction;
        }
    }
}
