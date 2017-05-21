using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Grammars;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class GrammarParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            var testLines = new List<string> { "3", "3", "3", "S", "A", "B", "a", "b", "c", "S->ABc", "A->a", "B->b" };

            var grammar = GrammarParser.Parse(testLines);
            Assert.AreEqual(grammar.ToString(), "S,A,B;a,b,c;S->ABc,A->a,B->b");
        }
    }
}