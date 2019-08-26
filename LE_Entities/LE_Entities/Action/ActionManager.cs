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
                //for (int j = 0; j < groupActions[i].Count; j++)
                //{
                //    Console.WriteLine(groupActions[i][j].Id);
                //}
                GroupManager.GetEntityType(i).SetAction(groupActions[i].ToArray());
            }
            //Console.WriteLine((DateTime.Now - t0).TotalMilliseconds);
        }

        public static void Init()
        {

        }

        //private static string ToString(BitArray bitArray)
        //{
        //    string ts = string.Empty;
        //    for (int k = 0; k < bitArray.Length; k++)
        //    {
        //        ts += string.Format("[{0}]", bitArray[k]);
        //    }
        //    return ts;
        //}

        public static bool Contain(this BitArray b1,BitArray b2)
        {
            if (b1.Length != b2.Length)
            {
                return false;
            }
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i]==false&&b2[i]==true)
                {
                    return false;
                }
            }
            return true;
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
                    //bool mark = true;
                    //var t = (BitArray)GroupManager.GetEntityType(i).DataInfo.Clone();
                    //LE_Log.Log.Debug("EntityInfo", ToString(t));
                    //LE_Log.Log.Debug("ActionInfo", ToString(systemAction.DataInfo));
                    //var t2 = t.Or(systemAction.DataInfo);
                    //LE_Log.Log.Debug("T2Info", ToString(t2));
                    if (GroupManager.GetEntityType(i).DataInfo.Contain(systemAction.DataInfo))
                    {
                        groupActions[i].Add(systemAction);
                      
                        //LE_Log.Log.Debug("action register", " {0}:{1}:{2} ", 
                        //    GroupManager.GetEntityType(i).Name,ToString(GroupManager.GetEntityType(i).DataInfo),systemAction.Name);
                        //Console.WriteLine(systemAction.Name);
                    }
                    //for (int j = 0; j < t.Length; j++)
                    //{
                    //    if (t[i])
                    //    {
                    //        mark = false;
                    //    }
                    //}
                    //if (mark)
                    //{
                    //    groupActions[i].Add(systemAction);
                    //}
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
