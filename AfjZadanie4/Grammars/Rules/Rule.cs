using System.Collections.Generic;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars.Rules
{
    public class Rule
    {
        public NonTerminalSymbol LeftSide { get; set; }
        public List<Symbol> RightSide { get; set; }

        public Rule(NonTerminalSymbol leftSide, List<Symbol> rightSide)
        {
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public Rule(NonTerminalSymbol leftSide, Symbol rightSide)
        {
            LeftSide = leftSide;
            RightSide = new List<Symbol> { rightSide };
        }

        public override string ToString()
        {
            if (LeftSide == null || RightSide == null)
                return "";

            return $"{LeftSide}->{string.Join("", RightSide)}";
        }
    }
}
