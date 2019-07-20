using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    class DataBlockInfo
    {
        public static int BlockSize = 64;

        private readonly int entityBlockId;

        private readonly int[] datas;

        private int firtEmpty;
        private int lastPoint;

        private readonly int[] marks;

        public DataBlockInfo(int entityBlockId, int[] datas)
        {
            this.entityBlockId = entityBlockId;
            this.datas = datas;
            this.firtEmpty = 0;
            this.lastPoint = -1;
            this.marks = new int[BlockSize];
            for (int i = 0; i < BlockSize; i++)
            {
                marks[i] = i+1;
            }
        }

        public bool this[int index]
        {
            get
            {
                return Check(index);
            }
        }

        public int AddData()
        {
            if (firtEmpty < BlockSize)
            {
                int re = firtEmpty;
                firtEmpty = marks[re];
                marks[re] = -1;
                return re;
            }
            return -1;
        }

        public bool Check(int index)
        {
            if (index < 0 || index >= BlockSize)
            {
                return false;
            }
            else if(marks[index]==-1)
            {
                return true;
            }
            return false;
        }

        public void RemoveData(int index)
        {
            if (Check(index))
            {
                if (lastPoint > -1)
                {
                    marks[index] = marks[lastPoint];
                    marks[lastPoint] = index;
                }
                else
                {
                    marks[index] = firtEmpty;
                    firtEmpty = index;
                }
                lastPoint = index;
            }
        }

        public int EntityBlockId => entityBlockId;

    }
}