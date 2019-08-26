using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Template
{
    public abstract class BaseTD
    {
        private readonly int id;

        public int Id => id;

        public abstract void Init();

        protected void SetData<T>(T data) where T : struct, ITemplate
        {
            //TODO: Set template Data;
            //TDManager<T>
        }
    }
}
