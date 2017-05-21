using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class RuleTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var terminal_a = new TerminalSymbol("a");
            var terminal_b = new TerminalSymbol("b");

            var rule = new Rule(nonTerminal_S, new List<Symbol>{ terminal_a, terminal_b });
            Assert.AreEqual("S->ab", rule.ToString());

            rule = new Rule(null, new List<Symbol>());
            Assert.AreEqual("", rule.ToString());
        }
    }
}