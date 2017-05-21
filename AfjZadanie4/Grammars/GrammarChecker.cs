using System.Collections.Generic;
using System.Linq;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars
{
    public static class GrammarChecker
    {
        public static bool IsStartSymbolOnRightSide(List<Rule> rules, Symbol startSymbol)
        {
            //return rules.Any(r => r.RightSide.Any(s => s.Name == startSymbol.Name));
            return rules.Any(r => Lsd(r, startSymbol));
        }

        private static bool Lsd(Rule r, Symbol st)
        {
            var a = r.RightSide.Any(s => Asd(s.Name, st.Name));

            return a;
        }

        private static bool Asd(string s1, string s2)
        {
            var eq = s1 == s2;

            return eq;
        }
    }
}
