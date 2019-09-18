using LE_Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Command
{
    class AddEntityCommand : ICommand
    {
        private int typeId;

        public AddEntityCommand()
        {

        }

        public void SetCommand(int typeId)
        {
            
        }

        public void Execute()
        {
            //Entity.EntityManager.GetEntity(id).SetData<T>();
        }
    }
}
