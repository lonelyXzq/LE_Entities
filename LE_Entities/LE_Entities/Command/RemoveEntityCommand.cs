using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    public class RemoveEntityCommand:ICommand
    {
        private int entityId;

        private int typeId;

        private readonly int commandId;

        public RemoveEntityCommand(int commandId)
        {
            this.commandId = commandId;
        }

        public void SetCommand(int typeId, int entityId)
        {
            this.typeId = typeId;
            this.entityId = entityId;
        }

        public int CommandId => commandId;

        public void Execute()
        {
            EntityManager.RemoveEntity(typeId, entityId);
        }

        public object GetData()
        {
            return null;
        }
    }
}
