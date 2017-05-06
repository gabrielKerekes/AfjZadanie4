using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4
{
    public static class GrammarCorrector
    {
        public static void CorrectGrammar(Grammar grammar)
        {
            AddNewStartSymbolIfNeeded(grammar);
        }

        // todo: return type asi nemusi byt
        private static void AddNewStartSymbolIfNeeded(Grammar grammar)
        {
            if (IsStartSymbolOnRightSide(grammar))
            {
                AddNewStartSymbol(grammar);
            }
        }


        private static bool IsStartSymbolOnRightSide(Grammar grammar)
        {
            return grammar.Rules.Any(r => r.RightSide.Contains(grammar.StartSymbol));
        }

        private static void AddNewStartSymbol(Grammar grammar)
        {
            grammar.StartSymbol = "S'";
            grammar.NonTerminals.Add(grammar.StartSymbol);
            grammar.Rules.Add(new Rule(grammar.StartSymbol, Grammar.DefaultStartSymbol));
        }
    }
}
