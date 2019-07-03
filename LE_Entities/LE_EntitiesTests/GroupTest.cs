using LE_Entities;
using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
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
            BitArray bitArray = new BitArray(8);
            bitArray.Set(0, true);
            //Console.WriteLine(bitArray.);
            DataManager.Init();
            Entity entity = new Entity("123", 1);
            EntityManager.DataChain.Add(entity);
            //Console.WriteLine(typeof(SystemAction<A1, B1>).FullName);
            ActionManager.Init();
            GroupManager.GetEntityType(0).Execute(1);
            Console.WriteLine();
            GroupManager.GetEntityType(1).Execute(1);
            //LEAction lEAction = new LEAction();
            //Execute<A1, B1> action = lEAction.Execute;
        }




    }

    public class GroupA : EntityType
    {
        public A1 a1;
        public B1 b1;
    }
    public class GroupB : EntityType
    {
        public A1 a1;
        public B1 b1;
        public C1 c1;
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

    [EntityAction(typeof(GroupA))]
    public class GroupAction : IDataAction<A1, B1>
    {
        public void Execute(int id, A1 t1, B1 t2)
        {
            Console.WriteLine("1");
        }
    }

    public class LEAction : IDataAction<A1, B1>
    {
        public void Execute(int id, A1 t1, B1 t2)
        {
            Console.WriteLine("2");
        }
    }

    public class LE2 : IDataAction<A1,C1>
    {
        public void Execute(int id, A1 t1,C1 t2)
        {
            Console.WriteLine("3");
        }
    }
}
