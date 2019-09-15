using LE_Entities.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    internal class EntityType : IObject
    {
        private string name;
        private readonly int id;
        private ISystemAction[] groupActions;
        private int actionCount;
        private readonly BitArray dataInfo;
        private IEntityType entityType;

        public EntityType()
        {
            //this.name = GetType().Name;
            dataInfo = new BitArray(DataManager.Count);
            id = IdManager.IdDeliverer<EntityType>.GetNextId();

        }

        public void SetEntityType(IEntityType entityType)
        {
            this.entityType = entityType;
            name = entityType.GetType().FullName;
            LE_Log.Log.Info("TypeRegister", "TypeId: {0} TypeName: {1}", id, name);
        }

        public void SetAction(ISystemAction[] groupActions)
        {
            this.groupActions = groupActions;
            actionCount = groupActions.Length;
        }

        public void Init(Entity entity)
        {
            entityType.Init(entity);
        }


        public void Execute(EntityBlock entityBlock)
        {
            if (!entityBlock.Get())
            {

                LE_Log.Log.Info("ActionOverTime", "entityBlock[ entityType : {0} , entityBlockId : {1}]: operation is over time", name, entityBlock.BlockId);
                return;
            }
            for (int i = 0; i < actionCount; i++)
            {
                groupActions[i].Update(entityBlock);
            }
            entityBlock.Re();
        }

        public string Name => name;

        public int Id => id;

        public BitArray DataInfo => dataInfo;
    }
}
