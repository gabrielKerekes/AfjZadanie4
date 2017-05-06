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
    public class GrammarTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var nonTerminals = new List<string> {"A"};
            var terminals = new List<string> { "a" };
            var rules = new List<Rule> { new Rule("A", "a") };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            Assert.AreEqual(grammar.ToString(), "A;a;A->a");

            grammar = new Grammar(new List<string>(), new List<string>(), new List<Rule>());
            Assert.AreEqual(grammar.ToString(), ";;");
        }
    }
}