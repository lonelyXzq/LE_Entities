using System;
using System.Threading;
using LE_Entities.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LE_EntitiesTests
{
    class A
    {
        public string id;

        public A(string id)
        {
            this.id = id;
        }
    }
    [TestClass]
    public class SafetyQueueTests
    {
        private const int Number = 1;
        private Thread[] threads;
        private SafetyQueue<A> queue;

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
            queue = new SafetyQueue<A>();
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
            for (int i = 0; i < 200; i++)
            {
                A a;
                while (!queue.Dequeue(out a))
                {
                    
                }
                Console.WriteLine(i+(a == null ? "null" : a.id));
            }
        }

        public void Add()
        {
            for (int i = 0; i < 100; i++)
            {
                while(!queue.Enqueue(new A(string.Format("name:{0},id:{1}", Thread.CurrentThread.Name,i))))
                {

                };
            }
        }
    }
}
