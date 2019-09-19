using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class SetDataCommand<T> : ICommand where T:IData
    {
        private T data;
        private int entityId;

        private readonly int commandId;

        public int CommandId => commandId;
        public SetDataCommand()
        {

        }

        public SetDataCommand(int commandId)
        {
            this.commandId = commandId;
        }

        public void SetCommand(T data, int id)
        {
            this.data = data;
            this.entityId = id;
        }

        public void Execute()
        {
            Entity.EntityManager.GetEntity(entityId).SetData<T>(data);
        }

        public object GetData()
        {
            return null;
        }
    }
}
