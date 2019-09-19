using LE_Entities.Data;
using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class GetDataCommand<T> :ICommand where T:IData
    {
        private int entityId;

        private T data;

        private readonly int commandId;

        public int CommandId => commandId;

        public void Execute()
        {
            data = EntityManager.GetEntity(entityId).GetData<T>();
        }

        public void SetCommand(int entityId)
        {
            this.entityId = entityId;
        }

        public object GetData()
        {
            return data;
        }
    }
}
