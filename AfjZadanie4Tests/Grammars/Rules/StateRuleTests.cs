using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars.Rules.Tests
{
    [TestClass()]
    public class StateRuleTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var terminal_a = new TerminalSymbol("a");

            var nonTerminals = new List<NonTerminalSymbol>
            {
                nonTerminal_S,
                nonTerminal_A,
            };
            var terminals = new List<TerminalSymbol>
            {
                terminal_a,
            };

            var stateRule = new StateRule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A }, 1);
            Assert.AreEqual(stateRule.ToString(), "S->a.A");

            stateRule = new StateRule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A }, 2);
            Assert.AreEqual(stateRule.ToString(), "S->aA.");

            stateRule = new StateRule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A }, 0);
            Assert.AreEqual(stateRule.ToString(), "S->.aA");

            stateRule = new StateRule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A });
            Assert.AreEqual(stateRule.ToString(), "S->.aA");
        }
    }
}