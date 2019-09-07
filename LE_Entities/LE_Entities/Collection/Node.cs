using LE_Entities.Data;
using LE_Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace LE_Entities.Collection
{
    class Node
    {
        private readonly List<EntityData>[] datas;

        public Node()
        {
            datas = new List<EntityData>[DataManager.Count];
            for (int i = 0; i < DataManager.Count; i++)
            {
                datas[i] = new List<EntityData>();
            }
        }

        public void AddEntity(EntityData entityData)
        {
            datas[entityData.EntityBlock.EntityType.Id].Add(entityData);
        }

        public void RemoveEntity(EntityData entityData)
        {
            int id=entityData.EntityBlock.EntityType.Id;
            for (int i = 0; i < datas[id].Count; i++)
            {
                if (datas[id][i].Id == entityData.Id)
                {
                    datas[id].RemoveAt(i);
                    break;
                }
            }
        }


        // void AddEntity()
    }
}
