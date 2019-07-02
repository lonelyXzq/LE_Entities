using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public abstract class EntityType : IEntityType
    {
        private string name;
        private readonly int id;
        private ISystemAction[] groupActions;
        private int actionCount;

        protected EntityType()
        {
            this.name = GetType().Name;
            id = IdManager.IdDeliverer<EntityType>.GetNextId();

            Console.WriteLine(name + ":" + id);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAction(ISystemAction[] groupActions)
        {
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
