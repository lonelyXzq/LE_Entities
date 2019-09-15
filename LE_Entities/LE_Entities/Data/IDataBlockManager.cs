using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    interface IDataBlockManager
    {
        bool CheckBlock(int id);

        int AddBlock();

        void RemoveBlock(int blockId);

        void RemoveData(int blockId, int localId);

        void RemoveDatas(int blockId, List<int> localIds);
    }
}
