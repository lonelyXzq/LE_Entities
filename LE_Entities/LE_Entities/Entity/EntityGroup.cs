using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{


    class BaseEntityGroup : IBaseEntityGroup
    {
        private readonly string name;
        private readonly int id;

        public BaseEntityGroup(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name => name;

        public int Id => id;

        public virtual void OnInit()
        {
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnEnd()
        {
        }

        public virtual void OnDestory()
        {
        }
    }

    class EntityGroup : BaseEntityGroup
    {
        public EntityGroup(string name, int id)
            :base(name,id)
        {

        }
    }
}
