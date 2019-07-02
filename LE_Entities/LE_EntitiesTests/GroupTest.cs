﻿using LE_Entities;
using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_EntitiesTests
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public void InitTest()
        {
            DataManager.Init();
            Entity entity = new Entity("123", 1);
            EntityManager.DataChain.Add(entity);
            //Console.WriteLine(typeof(SystemAction<A1, B1>).FullName);
            ActionManager.Init();

            //LEAction lEAction = new LEAction();
            //Execute<A1, B1> action = lEAction.Execute;
        }



        class GroupA : EntityType
        {

        }
        class GroupB : EntityType
        {

        }
    }
    public class A1 : IData
    {

    }

    public class B1 : IData
    {

    }

    public class C1 : IData
    {

    }

    public class LEAction : IDataAction<A1, B1>
    {
        public void Execute(int id, A1 t1, B1 t2)
        {
            Console.WriteLine("2333333333333333");
            Console.WriteLine(id + ":");
        }
    }

    public class LE2 : IDataAction<A1>
    {
        public void Execute(int id, A1 t1)
        {
            Console.WriteLine(id+":23333333333");
        }
    }
}
