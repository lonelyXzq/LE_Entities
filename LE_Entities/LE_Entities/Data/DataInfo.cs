using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    static class DataInfo<T> where T : IData
    {
        private static readonly int dataId;
        public static int DataId => dataId;

        public static int LocalId;

        private static readonly DataBlockManager<T> dataBlockManager ;

        internal static DataBlockManager<T> DataBlockManager => dataBlockManager;

        static DataInfo()
        {
            dataId = IdManager.IdDeliverer<IData>.GetNextId();
            dataBlockManager = new DataBlockManager<T>();
        }

        public static void Init()
        {
            //DataManager.AddDataType(dataId, dataBlockManager);
        }

    }
}
