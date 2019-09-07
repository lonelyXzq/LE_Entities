using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
     class EntityBlock
    {
        private readonly DataBlockInfo dataBlockInfo;
        private readonly int id;
        private readonly EntityType entityType;

        public bool IsEmpty => dataBlockInfo.IsEmpty;

        public bool IsFull => dataBlockInfo.IsFull;

        public int Count => dataBlockInfo.Count;

        public EntityBlock(int id, EntityType entityType)
        {
            this.entityType = entityType;
            this.id = id;
            int[] datas = new int[DataManager.Count];
            for (int i = 0; i < DataManager.Count; i++)
            {
                if (entityType.DataInfo[i])
                {
                    datas[i] = DataManager.DataBlockManagers[i].AddBlock();
                }
                else
                {
                    datas[i] = -1;
                }
            }
            dataBlockInfo = new DataBlockInfo(id, datas);
        }

        public void Execute()
        {
            entityType.Execute(this);
        }

        public int AddEntity(string name)
        {
            int id= dataBlockInfo.AddData();
            if (id == -1)
            {
                return id;
            }
            Entity entity = new Entity(new EntityData(name, id, this));
            entityType.Init(entity);
            return id;
        }

        public void RemoveEntity(int id)
        {
            dataBlockInfo.RemoveData(id);
        }

        public void Release()
        {
            int[] datas = dataBlockInfo.BlockDatas;
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] != -1)
                {
                    DataManager.DataBlockManagers[i].RemoveBlock(datas[i]);
                }
            }
        }

        private int GetBlockId<T>() where T : IData
        {
            if (dataBlockInfo.BlockDatas[DataInfo<T>.DataId] == -1)
            {
                dataBlockInfo.BlockDatas[DataInfo<T>.DataId] = DataInfo<T>.DataBlockManager.AddBlock();
            }
            return dataBlockInfo.BlockDatas[DataInfo<T>.DataId];
        }

        private int CheckBlockId<T>() where T : IData
        {
            return dataBlockInfo.BlockDatas[DataInfo<T>.DataId];
        }

        public DataBlock<T> GetDataBlock<T>() where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return default;
            }
            return DataInfo<T>.DataBlockManager.GetBlock(blockId);
        }

        public T GetData<T>(int id) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists",typeof(T));
                return default;
            }
            return DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id];
        }

        //public int CreateEntityId()
        //{
        //    return dataBlockInfo.AddData();
        //}

        public void AddData<T>(int id, T data) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return;
            }
            DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = data;
        }

        //public void RemoveData<T>(int id) where T : IData
        //{
        //    int blockId = GetBlockId<T>();
        //    DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = default;
        //}

        public void SetData<T>(int id, T data) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return;
            }
            DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = data;
        }

        internal DataBlockInfo DataBlockInfo => dataBlockInfo;

        public int BlockId => id;

        public EntityType EntityType => entityType;
    }
}
