using LE_Entities.Data;
using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class ChangeDataCommand<T> : ICommand where T : IData
    {
        private Execute<T> execute;
        private int id;

        public ChangeDataCommand()
        {

        }

        public void SetCommand(Execute<T> execute, int id)
        {
            this.execute = execute;
            this.id = id;
        }

        public void Execute()
        {
            Entity.EntityManager.GetEntity(id).ChangeData(execute);
        }
    }
}
