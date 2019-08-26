using LE_Entities.LE_Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LE_Entities.Template
{
    public static class TemplateManager<T> where T : class, ITemplate
    {
        public static readonly T[] datas;

        static TemplateManager()
        {
            Type baseType = typeof(T);
            var types = LEType.GetTypes(t => t.BaseType == baseType);
            datas = new T[types.Length];
            for (int i = 0; i < types.Length; i++)
            {

                datas[i] = LEType.CreateInstance<T>(types[i]);
                int id=IdManager.IdDeliverer<T>.GetNextId();
                var _id = types[i].GetField("id", BindingFlags.NonPublic |BindingFlags.Instance| BindingFlags.FlattenHierarchy);
                if (_id == null)
                {
                    //TODO: Exception
                    LE_Log.Log.Exception(new Exception() ,"Template register fail","template type:{0}",types[i].FullName);
                }
                _id.SetValue(datas[i], id);
                Console.WriteLine("{0}:{1}",types[i].Name,datas[i].Id);
            }
        }
        
        public static void Init()
        {

        }

    }
}
