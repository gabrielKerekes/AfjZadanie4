using Microsoft.VisualStudio.TestTools.UnitTesting;
using AfjZadanie4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class RuleTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var rule = new Rule("S", "ab");
            Assert.AreEqual(rule.ToString(), "S->ab");

            rule = new Rule("", "");
            Assert.AreEqual(rule.ToString(), "->");
        }
    }
}