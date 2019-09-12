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

        private static ISystemAction[] systemActions;

        private static int actionCount;

        public static int ActionCount => actionCount;

        internal static ISystemAction[] SystemActions => systemActions;

        static ActionManager()
        {

        }

        public static void Init()
        {
            if (systemActions == null)
            {

                EntityTypeManager.Init();
                var types = LEType.GetTypes(t => t.GetInterfaces().Contains(typeof(ILE_Data)));
                Register(types);
            }
        }

        internal static void Register(Type[] types)
        {
            actionCount = types.Length;
            systemActions = new ISystemAction[actionCount];
            List<ISystemAction>[] groupActions = new List<ISystemAction>[EntityTypeManager.TypeCount];
            for (int i = 0; i < groupActions.Length; i++)
            {
                groupActions[i] = new List<ISystemAction>();
            }

            for (int i = 0; i < actionCount; i++)
            {
                if (types[i].IsClass && !types[i].IsAbstract)
                {
                    Add(types[i], groupActions, i);
                }
            }
            for (int i = 0; i < groupActions.Length; i++)
            {
                EntityTypeManager.GetEntityType(i).SetAction(groupActions[i].ToArray());
            }
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

        private static void Add(Type type, List<ISystemAction>[] groupActions, int id)
        {
            ISystemAction systemAction = GetSystemAction(type, id);
            LE_Log.Log.Info("ActionRegister", "ActionId: {0}  ActionName: {1}", systemAction.Id, systemAction.Name);

            if ((Attribute.GetCustomAttribute(type, typeof(EntityActionAttribute)) is EntityActionAttribute actionAttribute))
            {
                groupActions[ObjectIdManager.GetId(actionAttribute.Type)].Add(systemAction);
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

        private static ISystemAction GetSystemAction(Type type, int id)
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
            systemActions[id] = systemAction;
            return systemAction;
        }
    }
}
