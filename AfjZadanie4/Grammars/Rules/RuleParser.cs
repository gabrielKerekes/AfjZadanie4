using System;
using System.Collections.Generic;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars.Rules
{
    public static class RuleParser
    {
        public static List<Rule> ParseRules(List<string> rulesStrings, List<Symbol> possibleSymbols)
        {
            var rules = new List<Rule>();
            foreach (var ruleString in rulesStrings)
            {
                var ruleStringSplit = ruleString.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                var leftSideSymbol = new NonTerminalSymbol(ruleStringSplit[0]);
                var rightSideSymbols = SymbolParser.ParseSymbols(ruleStringSplit[1], possibleSymbols);

                var rule = new Rule(leftSideSymbol, rightSideSymbols);
                rules.Add(rule);
            }

            return rules;
        }
    }
}
