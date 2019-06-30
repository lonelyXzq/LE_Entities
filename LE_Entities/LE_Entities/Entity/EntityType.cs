using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public abstract class EntityType:IObject
    {
        private readonly string name;
        private readonly int id;
        private readonly ISystemAction[] groupActions;
        private readonly int actionCount;

        protected EntityType(string name, ISystemAction[] groupActions)
        {
            this.name = name;
            id = IdManager.IdDeliverer<EntityType>.GetNextId();
            this.groupActions = groupActions;
            actionCount = groupActions.Length;
        }

        public void Execute(int id)
        {
            for (int i = 0; i < actionCount; i++)
            {
                groupActions[i].Execute(id);
            }
        }

        public string Name => name;

        public int Id => id;
    }
}
