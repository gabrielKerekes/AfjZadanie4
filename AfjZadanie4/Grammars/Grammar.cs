using System.Collections.Generic;
using System.Linq;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars
{
    public class Grammar
    {
        public static readonly NonTerminalSymbol DefaultStartSymbol = new NonTerminalSymbol("S");

        public NonTerminalSymbol StartSymbol { get; set; }
        public List<NonTerminalSymbol> NonTerminals { get; set; }
        public List<TerminalSymbol> Terminals { get; set; }
        public List<Rule> Rules { get; set; }

        public Grammar(List<NonTerminalSymbol> nonTerminals, List<TerminalSymbol> terminals, List<Rule> rules)
        {
            NonTerminals = nonTerminals;
            Terminals = terminals;
            Rules = rules;

            StartSymbol = DefaultStartSymbol;
            GrammarCorrector.CorrectGrammar(this);
        }

        public override string ToString()
        {
            return $"{string.Join(",", NonTerminals)};{string.Join(",", Terminals)};{string.Join(",", Rules.Select(r => r.ToString()))}";
        }
    }
}
