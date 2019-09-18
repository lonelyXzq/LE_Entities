using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class SetDataCommand<T> : ICommand where T:IData
    {
        private T data;
        private int id;

        public SetDataCommand()
        {

        }

        public void SetCommand(T data, int id)
        {
            this.data = data;
            this.id = id;
        }

        public void Execute()
        {
            Entity.EntityManager.GetEntity(id).SetData<T>(data);
        }
    }
}
