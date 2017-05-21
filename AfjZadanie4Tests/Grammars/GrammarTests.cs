using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class GrammarTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var nonTerminal_A = new NonTerminalSymbol("A");
            var terminal_a = new TerminalSymbol("a");

            var nonTerminals = new List<NonTerminalSymbol> { nonTerminal_A };
            var terminals = new List<TerminalSymbol> { terminal_a };
            var rules = new List<Rule> { new Rule(nonTerminal_A, terminal_a) };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            Assert.AreEqual(grammar.ToString(), "A;a;A->a");

            grammar = new Grammar(new List<NonTerminalSymbol>(), new List<TerminalSymbol>(), new List<Rule>());
            Assert.AreEqual(grammar.ToString(), ";;");
        }
    }
}