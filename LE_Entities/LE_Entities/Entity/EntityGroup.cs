using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{


    public abstract class EntityGroup : IEntityGroup
    {
        private readonly string name;
        private readonly int id;
        private readonly HashSet<int> datas;
        private readonly EntityType entityType;

        public EntityGroup(string name, int id)
        {
            this.name = name;
            this.id = id;
            datas = new HashSet<int>();
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
            foreach (var data in datas)
            {
                entityType.Execute(data);
                //EntityManager.DataChain.
            }
        }

        public virtual void OnEnd()
        {
        }

        public virtual void OnDestory()
        {
        }
    }

}
