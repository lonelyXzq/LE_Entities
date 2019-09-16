using LE_Entities.Data;
using LE_Entities.Tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        private int mark;

        public EntityBlock(int id, EntityType entityType)
        {
            this.entityType = entityType;
            this.id = id;
            mark = 0;
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

        public bool Get()
        {
            if (Interlocked.CompareExchange(ref mark, 1, 0) == 0)
            {
                return true;
            }
            return false;
        }

        public void Re()
        {
            mark = 0;
        }

        public void Execute()
        {
            if (Interlocked.CompareExchange(ref mark, 1, 0) != 0)
            {
                return;
            }
            entityType.Execute(this);
            mark = 0;
        }

        public int AddEntity(string name)
        {
            int id = dataBlockInfo.AddData();
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
            int[] datas = dataBlockInfo.BlockDatas;
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] != -1)
                {
                    DataManager.DataBlockManagers[i].RemoveData(datas[i], id);
                }
            }
        }

        internal void Release()
        {
            int[] datas = dataBlockInfo.BlockDatas;
            int[] marks = dataBlockInfo.Marks;
            List<int> ids = new List<int>();
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == -1)
                {
                    ids.Add(i);
                }
            }
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] != -1)
                {
                    DataManager.DataBlockManagers[i].RemoveDatas(datas[i], ids);
                    DataManager.DataBlockManagers[i].RemoveBlock(datas[i]);
                }
            }

            LE_Log.Log.Debug("EntityBlockRelease", "entityBlock[id : {0}] release", BlockId);
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
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
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
            //Console.WriteLine(blockId);
            //Console.WriteLine(DataInfo<T>.DataBlockManager.CheckBlock(0));
            Listener.ActionListener<T>.Listeners[0]?.Invoke(BlockId << DataBlockInfo.BlockSizePow + id, ref data);
            DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = data;
        }

        public void RemoveData<T>(int id) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return;
            }
            Listener.ActionListener<T>.Listeners[4]?.Invoke(BlockId << DataBlockInfo.BlockSizePow + id,
                ref DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id]);
            DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = default;
        }

        public void SetData<T>(int id, T data) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return;
            }
            Listener.ActionListener<T>.Listeners[2]?.Invoke(BlockId << DataBlockInfo.BlockSizePow + id, ref data);
            DataInfo<T>.DataBlockManager.GetBlock(blockId).Datas[id] = data;
        }

        public void ChangeData<T>(int id, Execute<T> execute) where T : IData
        {
            int blockId = CheckBlockId<T>();
            if (blockId == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", typeof(T));
                return;
            }
            var block = DataInfo<T>.DataBlockManager.GetBlock(blockId);
            int entityId = BlockId << DataBlockInfo.BlockSizePow + id;
            block.ChangeData(id, entityId, execute);
            Listener.ActionListener<T>.Listeners[2]?.Invoke(entityId, ref block.Datas[id]);
            //DataInfo<T>.DataBlockManager.ChanngeData(blockId, id, BlockId << DataBlockInfo.BlockSizePow + id, execute);
        }

        public void SetData_UnSafy(int dataTypeId, int id, IData data)
        {
            int bid = dataBlockInfo.BlockDatas[dataTypeId];
            if (bid == -1)
            {
                LE_Log.Log.Error("Data error", "dataType: {0} is not exists", data.GetType());
                return;
            }
            DataManager.DataBlockManagers[dataTypeId].SetData(bid, id, data);
        }

        internal DataBlockInfo DataBlockInfo => dataBlockInfo;

        public int BlockId => id;

        public EntityType EntityType => entityType;
    }
}
