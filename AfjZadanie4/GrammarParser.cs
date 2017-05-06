using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4
{
    public class GrammarParser
    {
        public static Grammar Parse(List<string> grammarStringLines)
        {
            var numOfNonTerminalSymbols = int.Parse(grammarStringLines[0]);
            var numOfTerminalSymbols = int.Parse(grammarStringLines[1]);
            var numOfRules = int.Parse(grammarStringLines[2]);

            // todo: mozno sa da z nonTerminals a terminals spravit char...
            // todo: ked tu v tom foreach s tym nic ine nerobim tak prerobit na lynq
            var nonTerminals = new List<string>();
            foreach (var grammarStringLine in grammarStringLines.Skip(3).Take(numOfNonTerminalSymbols))
            {
                nonTerminals.Add(grammarStringLine);
            }

            // todo: ked tu v tom foreach s tym nic ine nerobim tak prerobit na lynq
            var terminals = new List<string>();
            foreach (var grammarStringLine in grammarStringLines.Skip(3 + numOfNonTerminalSymbols).Take(numOfTerminalSymbols))
            {
                terminals.Add(grammarStringLine);
            }

            // todo: ked tu v tom foreach s tym nic ine nerobim tak prerobit na lynq
            var rulesStrings = new List<string>();
            foreach (var grammarStringLine in grammarStringLines.Skip(3 + numOfNonTerminalSymbols + numOfTerminalSymbols).Take(numOfRules))
            {
                rulesStrings.Add(grammarStringLine);
            }

            var rules = ParseRules(rulesStrings);

            return new Grammar(nonTerminals, terminals, rules);
        }

        public static List<Rule> ParseRules(List<string> rulesStrings)
        {
            var rules = new List<Rule>();
            foreach (var ruleString in rulesStrings)
            {
                var ruleStringSplit = ruleString.Split(new [] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                var rule = new Rule(ruleStringSplit[0], ruleStringSplit[1]);

                rules.Add(rule);
            }

            return rules;
        }
    }
}
