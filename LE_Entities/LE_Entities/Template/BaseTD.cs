using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Template
{
    public abstract class BaseTD : ITemplate
    {
        protected readonly int id;

        public int Id => id;

        public abstract void Init();


    }
}
