using System.Collections.Generic;
using System.Linq;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars
{
    public static class GrammarParser
    {
        public static Grammar Parse(List<string> grammarStringLines)
        {
            var numOfNonTerminalSymbols = int.Parse(grammarStringLines[0]);
            var numOfTerminalSymbols = int.Parse(grammarStringLines[1]);
            var numOfRules = int.Parse(grammarStringLines[2]);
            
            var nonTerminals = new List<NonTerminalSymbol>();
            foreach (var nonTerminalStringLine in grammarStringLines.Skip(3).Take(numOfNonTerminalSymbols))
            {
                nonTerminals.Add(new NonTerminalSymbol(nonTerminalStringLine));
            }
            
            var terminals = new List<TerminalSymbol>();
            foreach (var terminalStringLine in grammarStringLines.Skip(3 + numOfNonTerminalSymbols).Take(numOfTerminalSymbols))
            {
                terminals.Add(new TerminalSymbol(terminalStringLine));
            }

            var rulesStrings = new List<string>();
            foreach (var ruleStringLine in grammarStringLines.Skip(3 + numOfNonTerminalSymbols + numOfTerminalSymbols).Take(numOfRules))
            {
                rulesStrings.Add(ruleStringLine);
            }

            var possibleSymbols = new List<Symbol>();
            possibleSymbols.AddRange(nonTerminals);
            possibleSymbols.AddRange(terminals);
            var rules = RuleParser.ParseRules(rulesStrings, possibleSymbols);

            return new Grammar(nonTerminals, terminals, rules);
        }
    }
}
