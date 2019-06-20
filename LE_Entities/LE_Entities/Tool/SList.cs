using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Tool
{
    class SList<T>:ISList<T>
    {
        private readonly List<ListData> datas;
        private int addPoint;
        private int lastPoint;

        public SList()
        {
            datas = new List<ListData>();
            addPoint = -1;
            lastPoint = -1;
        }

        public void Add(T data)
        {
            if (addPoint == -1)
            {
                datas.Add(new ListData(-1, data));
            }
            else
            {
                ListData listData = datas[addPoint];
                listData.Data = data;
                addPoint = listData.Id;
                listData.Id = -1;
            }
        }

        public bool Check(int index)
        {
            if (index < 0 || index >= datas.Count)
            {
                return false;
            }else if (datas[index].Id == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            datas.Clear();
            addPoint = -1;
            lastPoint = -1;
        }

        public void Remove(int index)
        {
            if (Check(index))
            {
                datas[index].Data = default;
                if (lastPoint > -1)
                {
                    datas[lastPoint].Id = index;
                }
                else
                {
                    addPoint = index;
                }
                lastPoint = index;
            }
        }

        public class ListData
        {
            private int id;
            private T data;

            public ListData(int id, T data)
            {
                this.id = id;
                this.data = data;
            }

            public int Id { get => id; set => id = value; }
            public T Data { get => data; set => data = value; }
        }
    }
}
