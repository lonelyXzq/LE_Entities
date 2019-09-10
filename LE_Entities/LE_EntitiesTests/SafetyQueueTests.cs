using System;
using System.Threading;
using LE_Entities.ThreadTracker;
using LE_Entities.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LE_EntitiesTests
{
    class A0
    {
        public string id;

        public A0(string id)
        {
            this.id = id;
        }
    }
    [TestClass]
    public class SafetyQueueTests
    {
        private const int Number = 8;
        private Thread[] threads;
        private SafetyQueue<A0> queue;

        [TestInitialize]
        public void Init()
        {
            threads = new Thread[Number];
            for (int i = 0; i < Number; i++)
            {
                threads[i] = new Thread(Add)
                {
                    Name = i.ToString()
                };
            }
            queue = new SafetyQueue<A0>();
        }
        [TestMethod]
        public void BaseSafetyQuueTest()
        {
            Console.WriteLine("233333");
            for (int i = 0; i < Number; i++)
            {
                threads[i].Start();
            }
            //.Sleep(100);
            for (int i = 0; i < 80020; i++)
            {
                A0 a;
                if (queue.Dequeue(out a))
                {
                    //Console.WriteLine(i + ":"+a.id);
                }
                else
                {
                    //Console.WriteLine(i + ":null");
                }
            }
            ThreadTracker.OutPut();
        }

        public void Add()
        {
            for (int i = 0; i < 5000; i++)
            {
                queue.Enqueue(new A0(string.Format("name:{0},id:{1}", Thread.CurrentThread.Name, i)));
            }
        }
    }
}
