using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars
{
    public static class GrammarCorrector
    {
        public static void CorrectGrammar(Grammar grammar)
        {
            AddNewStartSymbolIfNeeded(grammar);
        }
        
        private static void AddNewStartSymbolIfNeeded(Grammar grammar)
        {
            if (GrammarChecker.IsStartSymbolOnRightSide(grammar.Rules, grammar.StartSymbol))
            {
                AddNewStartSymbol(grammar);
            }
        }

        private static void AddNewStartSymbol(Grammar grammar)
        {
            grammar.StartSymbol = new NonTerminalSymbol("S'");
            grammar.NonTerminals.Add(grammar.StartSymbol);
            grammar.Rules.Add(new Rule(grammar.StartSymbol, Grammar.DefaultStartSymbol));
        }
    }
}
