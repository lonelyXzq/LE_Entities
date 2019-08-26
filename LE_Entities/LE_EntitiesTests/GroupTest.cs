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
            //BitArray bitArray = new BitArray(8);
            //bitArray.Set(0, true);
            //Console.WriteLine(bitArray.);
            //DataManager.Init();
            //Entity entity = new Entity("123");
            //EntityManager.DataChain.Add(entity);
            //Console.WriteLine(typeof(SystemAction<A1, B1>).FullName);
            //ActionManager.Init();
            EntityManager.Init();
            for (int i = 0; i < 64; i++)
            {
                EntityManager.CreateEntity(1, null);
            }
            Console.WriteLine(EntityManager.CreateEntity(1, "123"));
            Console.WriteLine(EntityManager.CreateEntity(1, "1234"));
            Console.WriteLine(EntityManager.CreateEntity(1, "12"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12345"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12367"));
            EntityManager.RemoveEntity(GroupManager.GetEntityTypeId(typeof(GroupB)), 0);
            EntityManager.Execute();
            //GroupManager.GetEntityType(0).Execute(1);
            //Console.WriteLine();
            //GroupManager.GetEntityType(1).Execute(1);
            //LEAction lEAction = new LEAction();
            //Execute<A1, B1> action = lEAction.Execute;
        }




    }

    public class GroupA : EntityType
    {
        public A1 a1;
        public B1 b1;

        public override void Init(Entity entity)
        {
            entity.AddData(new A1());
            entity.AddData(new B1());
        }
    }
    public class GroupB : EntityType
    {
        public A1 a1;
        public B1 b1;
        public C1 c1;

        public override void Init(Entity entity)
        {
            entity.AddData(new A1());
            entity.AddData(new B1());
            entity.AddData(new C1());
            //throw new NotImplementedException();
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

    [EntityAction(typeof(GroupA))]
    public class GroupAction : IDataAction<A1, B1>
    {
        public void Execute(int id, A1 t1, B1 t2)
        {
            Console.WriteLine(id*10+1);
        }
    }

    public class LEAction : IDataAction<A1, B1>
    {
        public void Execute(int id, A1 t1, B1 t2)
        {
            Console.WriteLine(id * 10 + 2);
        }
    }

    public class LE2 : IDataAction<A1,C1>
    {
        public void Execute(int id, A1 t1,C1 t2)
        {
            Console.WriteLine(id * 10 + 3);
        }
    }
}
