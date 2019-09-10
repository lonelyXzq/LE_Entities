using LE_Entities.LE_Type;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LE_Entities.Template
{
    public class TAManager<T> where T : class, ITemplateAction
    {
        private readonly T[] actions;
        protected TAManager()
        {
            Type baseType = typeof(T);
            TemplateIdManager.RegiserBase<T>();
            var types = LEType.GetTypes(t => t.BaseType == baseType);
            actions = new T[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                actions[i] = LEType.CreateInstance<T>(types[i]);
                TemplateIdManager.Register<T>(types[i]);
            }
        }
    }
}
