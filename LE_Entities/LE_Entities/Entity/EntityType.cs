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

        internal void SetName(string name)
        {
            this.name = name;
        }

        internal void SetAction(ISystemAction[] groupActions)
        {
            this.groupActions = groupActions;
            actionCount = groupActions.Length;
        }

        public abstract void Init(Entity entity);


        internal void Execute(EntityBlock entityBlock)
        {
            for (int i = 0; i < actionCount; i++)
            {
                groupActions[i].Execute(entityBlock);
            }
        }

        public string Name => name;

        public int Id => id;

        public BitArray DataInfo => dataInfo;
    }
}
