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
        private static readonly List<ISystemAction>[] groupActions;
        static ActionManager()
        {
            GroupManager.Init();
            groupActions = new List<ISystemAction>[GroupManager.TypeCount];
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
                    Add(type);
                }
            }
            for (int i = 0; i < groupActions.Length; i++)
            {
                GroupManager.GetEntityType(i).SetAction(groupActions[i].ToArray());
            }
            //Console.WriteLine((DateTime.Now - t0).TotalMilliseconds);
        }

        public static void Init()
        {

        }

        private static void Add(Type type)
        {
            ISystemAction systemAction = GetSystemAction(type);
            LE_Log.Log.Info("ActionRegister", "ActionId: {0}  ActionName: {1}", systemAction.Id, systemAction.Name);
            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionAttribute)) is EntityActionAttribute actionAttribute))
            {
                groupActions[GroupManager.GetEntityTypeId(actionAttribute.Type)].Add(systemAction);
            }
            else
            {
                for (int i = 0; i < groupActions.Length; i++)
                {
                    bool mark = true;
                    var t = GroupManager.GetEntityType(i).DataInfo.And(systemAction.DataInfo).Xor(systemAction.DataInfo);
                    for (int j = 0; j < t.Length; j++)
                    {
                        if (t[i])
                        {
                            mark = false;
                        }
                    }
                    if (mark)
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
            sysType.GetField("name", BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance).SetValue(systemAction, type.FullName);
            MethodInfo methodInfo = sysType.GetMethod("SetAction");
            methodInfo.Invoke(systemAction, new object[] { type.Assembly.CreateInstance(type.FullName) });
            systemActions.Add(systemAction);
            return systemAction;
        }
    }
}
