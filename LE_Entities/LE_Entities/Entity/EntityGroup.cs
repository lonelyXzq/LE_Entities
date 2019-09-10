using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LE_Entities.Entity
{


    public class EntityGroup : IEntityGroup
    {
        private readonly Dictionary<int,EntityBlock> blocks;
        private readonly EntityType entityType;
        private readonly Queue<int> unFullBlockIds;

        public EntityGroup(EntityType entityType)
        {
            blocks = new Dictionary<int, EntityBlock>();
            this.entityType = entityType;
            unFullBlockIds = new Queue<int>();
        }

        public string Name => entityType.Name;

        public int Id => entityType.Id;

        public EntityType EntityType => entityType;


        public int AddEntity(string name)
        {
            int id;
            EntityBlock entityBlock;
            if (unFullBlockIds.Count == 0)
            {
                id = EntityBlockManager.AddBlock(entityType);
                unFullBlockIds.Enqueue(id);
                entityBlock = EntityBlockManager.GetEntityBlock(id);
                blocks.Add(id, entityBlock);
            }
            else
            {
                id = unFullBlockIds.Dequeue();
                entityBlock = blocks[id];
                if (entityBlock.Count < DataBlockInfo.BlockSize - 1)
                {
                    unFullBlockIds.Enqueue(id);
                }
            }
            return (id << DataBlockInfo.BlockSizePow) + entityBlock.AddEntity(name);
        }

        public void Remove(int id)
        {
            int blockId = id >> DataBlockInfo.BlockSizePow;
            int tid = id - (blockId << DataBlockInfo.BlockSizePow);
            if(blocks.TryGetValue(blockId,out EntityBlock entityBlock))
            {
                if (entityBlock.IsFull)
                {
                    unFullBlockIds.Enqueue(blockId);
                }
                entityBlock.RemoveEntity(tid);
            }
        }

        public virtual void OnInit()
        {
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnUpdate()
        {
            foreach (var data in blocks.Values)
            {
                //TODO:group update
                //data.Execute();
                Task.Run(() => entityType.Execute(data));
                //EntityManager.ExecuteEntity(data);
                //entityType.Execute(data);
                //EntityManager.DataChain.
            }
        }

        public virtual void OnEnd()
        {
            foreach (var data in blocks.Values)
            {
                data.Release();
            }
            blocks.Clear();
            unFullBlockIds.Clear();
        }

        public virtual void OnDestory()
        {
        }
    }

}
