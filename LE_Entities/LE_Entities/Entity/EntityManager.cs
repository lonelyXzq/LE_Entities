using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public static class EntityManager
    {

        private static readonly EntityGroup[] entityGroups;

        static EntityManager()
        {
            //DataManager.Init();
            //ActionManager.Init();
            ObjectInitManager.Init();

            entityGroups = new EntityGroup[EntityTypeManager.TypeCount];
            for (int i = 0; i < EntityTypeManager.TypeCount; i++)
            {
                entityGroups[i] = new EntityGroup(EntityTypeManager.GetEntityType(i));
            }
        }

        public static void Init()
        {

        }

        public static int CreateEntity(int typeid, string name)
        {
            if (typeid >= 0 && typeid < entityGroups.Length)
            {
                return entityGroups[typeid].AddEntity(name);
            }
            return -1;
        }

        public static Entity GetEntity(int id)
        {
            EntityBlock entityBlock = EntityBlockManager.GetEntityBlock(id >> DataBlockInfo.BlockSizePow);
            return new Entity(id, entityBlock);

        }


        public static void RemoveEntity(int typeid, int id)
        {
            if (typeid >= 0 && typeid < entityGroups.Length)
            {
                entityGroups[typeid].Remove(id);
            }
        }

        public static void Execute()
        {
            for (int i = 0; i < entityGroups.Length; i++)
            {
                entityGroups[i].OnUpdate();
            }
        }

        //public static void ExecuteGroup(int id)
        //{
        //    GroupManager.GetEntityType(id).;
        //}

    }
}
