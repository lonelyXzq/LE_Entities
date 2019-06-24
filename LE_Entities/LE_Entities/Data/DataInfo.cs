using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    static class DataInfo<T> where T : IData
    {
        public static readonly int DataId = IdManager.IdDeliverer<IData>.GetNextId();
        private static readonly DataChain<T> dataChain = new DataChain<T>();

        internal static DataChain<T> DataChain => dataChain;
    }
}
