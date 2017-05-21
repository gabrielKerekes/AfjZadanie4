using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class GrammarCorrectorTests
    {
        [TestMethod()]
        public void CorrectGrammarTest()
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

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_A, terminal_a),
                new Rule(nonTerminal_A, nonTerminal_S),
                new Rule(nonTerminal_S, nonTerminal_A),
            };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            GrammarCorrector.CorrectGrammar(grammar);
            Assert.AreEqual("S,A,S';a;A->a,A->S,S->A,S'->S", grammar.ToString());
        }
    }
}