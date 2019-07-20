using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public static class EntityManager
    {
        private static readonly DataChain<Entity> dataChain=new DataChain<Entity>();

        public static void CreateEntity(int typeid,string name)
        {
            Entity entity = new Entity(name,typeid);
            dataChain.Add(entity);
            GroupManager.GetEntityType(typeid).Init(entity);
        }

        public static void ExecuteEntity(int id)
        {
            Entity entity = dataChain.GetData(id);
            GroupManager.GetEntityType(entity.GroupId).Execute(entity,id);
        }

        //public static void ExecuteGroup(int id)
        //{
        //    GroupManager.GetEntityType(id).;
        //}

        internal static DataChain<Entity> DataChain => dataChain;
    }
}
