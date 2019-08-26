using LE_Entities.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_EntitiesTests
{
    [TestClass]
    public class ToolDataTests
    {
        struct SA0
        {
            public int A1;
            public int B2;
        }

        [TestMethod]
        public void BlockStrcutTest()
        {
            DataBlock<SA0> dataBlock = new DataBlock<SA0>();
            SA0 sa = dataBlock.Datas[5];
            sa.A1 = 10;
            Console.WriteLine(dataBlock.Datas[5].A1);
            dataBlock.Datas[6].A1=10;
            Console.WriteLine(dataBlock.Datas[6].A1);
            SA0 s= dataBlock.GetData(7);
            s.A1 = 10;
            Console.WriteLine(dataBlock.Datas[7].A1);
        }

        [TestMethod]
        public void EmptyTest()
        {
            DataBlockInfo dataBlockInfo = new DataBlockInfo(0, null);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(dataBlockInfo.AddData());
            }
            dataBlockInfo.RemoveData(9);
            dataBlockInfo.RemoveData(7);
            dataBlockInfo.RemoveData(8);
            dataBlockInfo.RemoveData(0);
            dataBlockInfo.RemoveData(5);
            dataBlockInfo.RemoveData(6);
            dataBlockInfo.RemoveData(4);
            dataBlockInfo.RemoveData(1);
            dataBlockInfo.RemoveData(2);
            dataBlockInfo.RemoveData(3);
            //Console.WriteLine(dataBlockInfo.IsEmpty);
            Assert.AreEqual(dataBlockInfo.IsEmpty, true);

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(dataBlockInfo.AddData());
            }
        }

        [TestMethod]
        public void BlockTest()
        {
            DataBlockInfo dataBlockInfo = new DataBlockInfo(0, null);
            for (int i = 0; i < 70; i++)
            {
                Console.WriteLine(dataBlockInfo.AddData());
            }
            dataBlockInfo.RemoveData(10);
            dataBlockInfo.RemoveData(7);
            dataBlockInfo.RemoveData(20);
            dataBlockInfo.RemoveData(50);
            dataBlockInfo.RemoveData(50);
            dataBlockInfo.RemoveData(-1);
            dataBlockInfo.RemoveData(70);
            dataBlockInfo.RemoveData(6);
            dataBlockInfo.RemoveData(6);
            dataBlockInfo.RemoveData(-1);
            dataBlockInfo.RemoveData(70);
            Assert.AreEqual(false, dataBlockInfo[10]);
            Assert.AreEqual(false, dataBlockInfo[7]);
            Assert.AreEqual(false, dataBlockInfo[20]);
            Assert.AreEqual(false, dataBlockInfo[50]);
            Assert.AreEqual(false, dataBlockInfo[6]);
            Assert.AreEqual(false, dataBlockInfo[-1]);
            Assert.AreEqual(false, dataBlockInfo[70]);
            Assert.AreEqual(true, dataBlockInfo[8]);
            Assert.AreEqual(true, dataBlockInfo[14]);
            Assert.AreEqual(true, dataBlockInfo[35]);
            Assert.AreEqual(true, dataBlockInfo[49]);
            Assert.AreEqual(10, dataBlockInfo.AddData());
            Assert.AreEqual(7, dataBlockInfo.AddData());
            Assert.AreEqual(20, dataBlockInfo.AddData());
            Assert.AreEqual(50, dataBlockInfo.AddData());
            Assert.AreEqual(6, dataBlockInfo.AddData());
            Assert.AreEqual(-1, dataBlockInfo.AddData());
            Assert.AreEqual(-1, dataBlockInfo.AddData());
        }
    }
}
