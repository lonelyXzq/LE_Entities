﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Data
{
    public interface IDataBlockManager
    {
        bool CheckBlock(int id);

        int AddBlock();

        void RemoveBlock(int blockId);
    }
}