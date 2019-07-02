using LE_Entities.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_EntitiesTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void RegisterTest()
        {
            DataManager.Init();
        }

        public class A1 : IData
        {

        }

        public class B1 : IData
        {

        }
    }
}
