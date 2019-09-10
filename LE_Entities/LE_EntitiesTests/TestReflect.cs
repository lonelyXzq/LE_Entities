using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_EntitiesTests
{
    [TestClass]
    public class TestReflect
    {
        public delegate void TestD<T>(T data);

        [TestMethod]
        public void Test()
        {
            var type = typeof(A1<int,float>);
            var types = type.GetGenericArguments();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].FullName);
            }
            type = typeof(B0);
            
            var t = type.GetInterfaces();
            for (int i = 0; i < t.Length; i++)
            {
                Console.WriteLine(t[i].Name);
            }
            Console.WriteLine(type.GetInterface("IB`2").Name);
            types = t[0].GetGenericArguments();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].FullName);
            }
            //Console.WriteLine(typeof(IB<int,float>).FullName);
        }

        [TestMethod]
        public void TestDelegate()
        {
            TestDe<int> test = new TestDe<int>();
            TestD<int> testD = new TestD<int>(test.Exe);
            //Type T2 = typeof(TestDe<int>);
            //var me = T2.GetMethod("Exe");
            //Delegate.CreateDelegate(typeof(TestD<int>),me);
        }

        class TestDe<T>
        {
            public void Exe(T data)
            {

            }
        }

        interface IB<T1, T2>
        {
            void Init(T1 t1, T2 t2);
        }

        class B0 : IB<int, float>
        {
            public void Init(int t1, float t2)
            {
            }
        }

        class A1<T1, T2>
        {
            T1 a;
            T2 b;

            public A1(T1 a, T2 b)
            {
                this.a = a;
                this.b = b;
            }

            public T1 A { get => a; set => a = value; }
            public T2 B { get => b; set => b = value; }
        }
    }
}
