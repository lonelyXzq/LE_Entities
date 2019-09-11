﻿using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LE_Entities
{
    static class ObjectInitManager
    {
        static ObjectInitManager()
        {
            DateTime d1 = DateTime.Now;
            Type[] types = LE_Type.LEType.GetTypes(t => t.GetInterfaces().Contains(typeof(IBaseObject)));
            List<Type> datas = new List<Type>();
            List<Type> groups = new List<Type>();
            List<Type> actions = new List<Type>();
            DateTime d2 = DateTime.Now;
            Console.WriteLine((d2 - d1).TotalMilliseconds);
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsInterface)
                {

                }
                else if (types[i].GetInterfaces().Contains(typeof(IData)))
                {
                    datas.Add(types[i]);
                }
                else if (types[i].GetInterfaces().Contains(typeof(IEntityType)))
                {
                    groups.Add(types[i]);
                }
                else if (types[i].GetInterfaces().Contains(typeof(ILE_Data)))
                {
                    actions.Add(types[i]);
                }
                else
                {
                    //TODO: exception
                    LE_Log.Log.Exception(new Exception(), "Register fail", "unknow type , type name : {0}", types[i].FullName);
                }
            }

            DataManager.Register(datas.ToArray());
            EntityTypeManager.Register(groups.ToArray());
            ActionManager.Register(actions.ToArray());
        }

        public static void Init()
        {

        }
    }
}