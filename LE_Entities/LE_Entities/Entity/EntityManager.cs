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

        private static readonly Dictionary<int, EntityGroup> entityGroups = new Dictionary<int, EntityGroup>();

        static EntityManager()
        {
            DataManager.Init();
            ActionManager.Init();
            for (int i = 0; i < GroupManager.TypeCount; i++)
            {
                entityGroups.Add(i, new EntityGroup(GroupManager.GetEntityType(i)));
            }
        }

        public static void Init()
        {

        }

        public static int CreateEntity(int typeid, string name)
        {
            if (entityGroups.TryGetValue(typeid, out EntityGroup entityGroup))
            {
                return entityGroup.AddEntity(name);
            }
            return -1;
        }

        public static Entity GetEntity(int id)
        {
            EntityBlock entityBlock = EntityBlockManager.GetEntityBlock(id >> DataBlockInfo.BlockSizePow);
            return new Entity(id,entityBlock);

        }


        public static void RemoveEntity(int typeid, int id)
        {
            if (entityGroups.TryGetValue(typeid, out EntityGroup entityGroup))
            {
                entityGroup.Remove(id);
            }
        }

        public static void Execute()
        {
            foreach (var group in entityGroups.Values)
            {
                group.OnUpdate();
            }
 
        }

        //public static void ExecuteGroup(int id)
        //{
        //    GroupManager.GetEntityType(id).;
        //}

    }
}
