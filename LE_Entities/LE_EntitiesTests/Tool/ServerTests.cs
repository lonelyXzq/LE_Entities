using LE_Entities.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LE_EntitiesTests.Tool
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void BaseTest()
        {
            Server server = new Server(20, "testServer");
            server.SetAction(DoSomething);
            Console.WriteLine("2333");
            server.Start();
            Thread.Sleep(100);
            server.Stop();
        }

        public void DoSomething()
        {
            Console.WriteLine("Do");
        }
    }
}
