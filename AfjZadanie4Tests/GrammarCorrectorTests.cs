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
    public class GrammarCorrectorTests
    {
        [TestMethod()]
        public void CorrectGrammarTest()
        {
            var nonTerminals = new List<string> { "S", "A" };
            var terminals = new List<string> { "a" };
            var rules = new List<Rule> { new Rule("A", "a"), new Rule("A", "S"), new Rule("S", "A") };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            GrammarCorrector.CorrectGrammar(grammar);
            Assert.AreEqual(grammar.ToString(), "S,A,S';a;A->a,A->S,S->A,S'->S");
        }
    }
}