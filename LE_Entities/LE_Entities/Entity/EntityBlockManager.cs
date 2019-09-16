using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    //TODO: BlockManager
    static class EntityBlockManager
    {
        private static readonly ISList<EntityBlock> entities;

        internal static ISList<EntityBlock> Entities => entities;

        static EntityBlockManager()
        {
            entities = new SteadyList<EntityBlock>();
        }

        public static EntityBlock GetEntityBlock(int id)
        {
            if (!entities.Check(id))
            {
                LE_Log.Log.Error("EntityBlock error", "EntitytBlock [id: {0} ] does not exists", id);
                return null;
            }
            return entities[id];
        }

        public static int AddBlock(EntityType entityType)
        {

            int id = entities.Add(null);
            EntityBlock entityBlock = new EntityBlock(id, entityType);

            entities[id] = entityBlock;
            return id;

        }

        public static void ReleaseEmpty()
        {
            var blocks = entities.FindData((b) => b.IsEmpty);
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].Release();
            }
        }

        public static void Release()
        {
            entities.Clear();
        }

        internal static void ReleaseBlock(int id)
        {
            if (!entities.Check(id))
            {
                LE_Log.Log.Error("EntityBlock error", "EntitytBlock [id: {0} ] does not exists", id);
                return;
            }
            entities[id].Release();
            entities.Remove(id);
        }

    }
}
