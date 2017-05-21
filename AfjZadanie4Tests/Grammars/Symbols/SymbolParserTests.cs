using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AfjZadanie4.Grammars.Symbols.Tests
{
    [TestClass()]
    public class SymbolParserTests
    {
        [TestMethod()]
        public void ParseSymbolsTest()
        {
            var symbolString = "ABBACA";
            var possibleSymbols = new List<Symbol>
            {
                new Symbol("A"), new Symbol("B"), new Symbol("C"), new Symbol("BA"), 
            };

            var expectedResult = new List<Symbol>
            {
                new Symbol("A"), new Symbol("B"), new Symbol("BA"), new Symbol("C"), new Symbol("A"),
            };
            
            var receivedResult = SymbolParser.ParseSymbols(symbolString, possibleSymbols);
            Assert.AreEqual(string.Join(",", expectedResult), string.Join(",", receivedResult));

            expectedResult = new List<Symbol>
            {
                new Symbol("A"), new Symbol("BA"),
            };
            receivedResult = SymbolParser.ParseSymbols("QQAQQBAQQ", possibleSymbols);
            Assert.AreEqual(string.Join(",", expectedResult), string.Join(",", receivedResult));

            receivedResult = SymbolParser.ParseSymbols("EDAWDSADWQ", new List<Symbol>());
            Assert.AreEqual(string.Join(",", new List<Symbol>()), string.Join(",", receivedResult));
        }
    }
}