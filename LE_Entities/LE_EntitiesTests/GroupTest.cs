using LE_Entities;
using LE_Entities.Action;
using LE_Entities.Data;
using LE_Entities.Entity;
using LE_Entities.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            //for (int i = 0; i < 64; i++)
            //{
            //    EntityManager.CreateEntity(1, null);
            //}
            //LE2 e2 = new LE2();
            //DataBlock<D1> dataBlock = new DataBlock<D1>();
            //D1[] d1s = dataBlock.Datas;
            //A1 a1 = new A1();
            //C1 c1 = new C1();
            //Execute<A1, C1, D1> execute = e2.Execute;
            //execute?.Invoke(-12, ref a1, ref c1, ref d1s[2]);
            //Console.WriteLine(d1s[2].a);
            Console.WriteLine(EntityManager.CreateEntity(1, "123asd"));
            Console.WriteLine(EntityManager.CreateEntity(1, "1234"));
            Console.WriteLine(EntityManager.CreateEntity(1, "12"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12345"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12367"));
            
            //GroupManager.GetEntityType(0).Execute(1);
            //Console.WriteLine();
            //GroupManager.GetEntityType(1).Execute(1);
            //LEAction lEAction = new LEAction();
            //Execute<A1, B1> action = lEAction.Execute;
        }

        [TestMethod]
        public void ExecuteTest()
        {
            EntityManager.Init();
            Console.WriteLine(EntityManager.CreateEntity(1, "123asd"));
            Console.WriteLine(EntityManager.CreateEntity(1, "1234"));
            Console.WriteLine(EntityManager.CreateEntity(1, "12"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12345"));
            Console.WriteLine(EntityManager.CreateEntity(0, "12367"));
            EntityManager.RemoveEntity(EntityTypeManager.GetEntityTypeId(typeof(GroupB)), 0);
            EntityManager.Execute();
            Thread.Sleep(100);
            EntityManager.Execute();
            Thread.Sleep(100);
            EntityManager.Execute();
            Thread.Sleep(100);
            EntityManager.Execute();
            Thread.Sleep(100);
            Entity entity = EntityManager.GetEntity(1);
            Console.WriteLine("----------");
            Console.WriteLine(entity.GetData<D1>().a);
            Assert.AreEqual(entity.GetData<D1>().a, 1);
            Console.WriteLine(entity.Name);
        }


    }

    public class GroupA : IEntityType
    {
        public A1 a1;
        public B1 b1;

        public void Init(Entity entity)
        {
            entity.AddData(new A1());
            entity.AddData(new B1());
        }
    }
    public class GroupB : IEntityType
    {
        public A1 a1;
        public B1 b1;
        public C1 c1;
        public D1 d1;

        public void Init(Entity entity)
        {
            entity.AddData(new A1());
            entity.AddData(new B1());
            entity.AddData(new C1());
            entity.AddData(new D1(3));
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

    public struct D1 : IData
    {
        public int a;

        public D1(int a)
        {
            this.a = a;
        }
    }

    [EntityAction(typeof(GroupA))]
    public class GroupAction : IDataAction<A1, B1>
    {
        public void Execute(int id, ref A1 t1,ref B1 t2)
        {
            Console.WriteLine(id*10+1);
        }
    }

    public class LEAction : IDataAction<A1, B1>
    {
        public void Execute(int id,ref A1 t1,ref B1 t2)
        {
            Console.WriteLine(id * 10 + 2);
        }
    }

    [EntityActionCycle(2)]
    public class LE2 : IDataAction<A1,C1,D1>
    {
        public void Execute(int id,ref A1 t1,ref C1 t2,ref D1 t3)
        {
            Console.WriteLine("------------------------------");
            //Console.WriteLine(t3.a);
            t3.a = id;
            //Console.WriteLine(t3.a);
            Console.WriteLine(id * 10 + 3);
            Console.WriteLine("active");
        }
    }
}
