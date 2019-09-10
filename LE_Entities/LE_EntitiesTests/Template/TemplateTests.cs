using LE_Entities.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_EntitiesTests.Template
{
    [TestClass]
    public class TemplateTests
    {
        [TestMethod]
        public void Init()
        { 
            TemplateManager<Base>.Init();
        }
    }

    class Base : ITemplate
    {
        protected int id;
        public int Id => id;

    }
    class A : Base
    {

    }
    class B : Base
    {

    }
}
