using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class AddEntityCommand : ICommand
    {
        private int typeId;

        private string name;

        private int id;

        private readonly int commandId;

        public int CommandId => commandId;

        public AddEntityCommand(int commandId)
        {
            this.commandId = commandId;
        }

        public void SetCommand(int typeId,string name)
        {
            this.typeId = typeId;
            this.name = name;
        }

        public void Execute()
        {
            id = Entity.EntityManager.CreateEntity(typeId,name);
        }

        public object GetData()
        {
            return id;
        }
    }
}
