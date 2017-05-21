using System.Collections.Generic;
using System.Linq;

namespace AfjZadanie4.Grammars.Symbols
{
    public static class SymbolParser
    {
        public static List<Symbol> ParseSymbols(string symbolsString, List<Symbol> possibleSymbols)
        {
            var symbols = new List<Symbol>();
            
            var currentString = "";
            foreach (var c in symbolsString)
            {
                currentString += c;

                if (possibleSymbols.Any(s => s.Name == currentString))
                {
                    if (!possibleSymbols.Any(s => s.Name.StartsWith(currentString)))
                        currentString = "";

                    continue;
                }

                var substring = currentString.Substring(0, currentString.Length - 1);
                if (possibleSymbols.Any(s => s.Name == substring))
                    symbols.Add(new Symbol(substring));

                currentString = c.ToString();
            }

            if (possibleSymbols.Any(s => s.Name == currentString))
            {
                symbols.Add(new Symbol(currentString));
            }

            return symbols;
        }
    }
}
