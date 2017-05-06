using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4
{
    public class Grammar
    {
        // todo: ked pojdu nonterminals a terminals na char tak aj toto...
        public const string DefaultStartSymbol = "S";

        public string StartSymbol { get; set; }
        public List<string> NonTerminals { get; set; }
        public List<string> Terminals { get; set; }
        public List<Rule> Rules { get; set; }

        public Grammar(List<string> nonTerminals, List<string> terminals, List<Rule> rules)
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
