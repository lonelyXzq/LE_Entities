using LE_Entities.IdManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LE_EntitiesTests
{
    [TestClass]
    public class IdManagerTests
    {
        [TestMethod]
        public void BaseTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0}:{1}", Thread.CurrentThread.ManagedThreadId, IdDeliverer<int>.GetNextId());
            }
        }

        [TestMethod]
        public void ThreadTest()
        {
            Thread[] threads = new Thread[4];
            Console.WriteLine("23333");
            for (int i = 0; i < 4; i++)
            {
                threads[i] = new Thread(Out);
            }
            for (int i = 0; i < 4; i++)
            {
                threads[i].Start();
            }
            Thread.Sleep(100);
        }

        public void Out()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0}:{1}",Thread.CurrentThread.ManagedThreadId, IdDeliverer<int>.GetNextId());
            }
        }
    }
}
