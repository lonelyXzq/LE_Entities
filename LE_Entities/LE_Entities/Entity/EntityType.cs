using LE_Entities.Data;
using System;
using System.Collections;
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
        private readonly BitArray dataInfo;

        protected EntityType()
        {
            this.name = GetType().Name;
            dataInfo = new BitArray(DataManager.Count);
            id = IdManager.IdDeliverer<EntityType>.GetNextId();
            LE_Log.Log.Info("TypeRegister", "TypeId: {0} TypeName: {1}", id, name);
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

        public abstract void Init(Entity entity);

        public void Execute(Entity entity,int id)
        {
            for (int i = 0; i < actionCount; i++)
            {
                groupActions[i].Execute(entity,id);
            }
        }

        public string Name => name;

        public int Id => id;

        public BitArray DataInfo => dataInfo;
    }
}
