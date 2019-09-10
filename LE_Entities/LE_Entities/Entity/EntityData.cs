using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    class EntityData : IData
    {
        private string name;
        private int id;
        private EntityBlock entityBlock;
        private int localId;

        public EntityData(string name, int id, EntityBlock entityBlock)
        {
            this.name = name;
            this.id = id;
            this.entityBlock = entityBlock;
            this.localId = id & (DataBlockInfo.BlockSize - 1);
        }

        public string Name { get => name; set => name = value; }
        public int Id => id;
        public EntityBlock EntityBlock => entityBlock;
        public int LocalId => localId;
    }
}
