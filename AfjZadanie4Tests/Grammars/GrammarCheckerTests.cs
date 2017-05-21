using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars.Tests
{
    [TestClass()]
    public class GrammarCheckerTests
    {
        [TestMethod()]
        public void IsStartSymbolOnRightSideTest()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var terminal_a = new TerminalSymbol("a");

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_A, terminal_a),
                new Rule(nonTerminal_A, nonTerminal_S),
                new Rule(nonTerminal_S, nonTerminal_A),
            };
            
            Assert.AreEqual(true, GrammarChecker.IsStartSymbolOnRightSide(rules, nonTerminal_S));

            rules = new List<Rule>
            {
                new Rule(nonTerminal_A, terminal_a),
                new Rule(nonTerminal_S, nonTerminal_A),
            };

            Assert.AreEqual(false, GrammarChecker.IsStartSymbolOnRightSide(rules, nonTerminal_S));
        }
    }
}