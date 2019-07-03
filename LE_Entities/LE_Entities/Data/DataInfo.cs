using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    static class DataInfo<T> where T : IData
    {
        private static readonly int dataId = IdManager.IdDeliverer<IData>.GetNextId();
        public static int DataId => dataId;
        private static readonly DataChain<T> dataChain = new DataChain<T>();

        internal static DataChain<T> DataChain => dataChain;

        public static void Init()
        {
        }

    }
}
