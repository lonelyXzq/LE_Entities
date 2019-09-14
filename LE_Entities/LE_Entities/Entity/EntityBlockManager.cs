using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    //TODO: BlockManager
    static class EntityBlockManager
    {
        private static readonly SList<EntityBlock> entities;

        static EntityBlockManager()
        {
            entities = new SList<EntityBlock>();
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

            int id = entities.AddId();
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

        public static void ReleaseBlock(int id)
        {
            if (!entities.Check(id))
            {
                LE_Log.Log.Error("EntityBlock error", "EntitytBlock [id: {0} ] does not exists", id);
                return;
            }
            entities[id].Release();
        }
    }
}
