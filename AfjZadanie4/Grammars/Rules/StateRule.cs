using System.Collections.Generic;
using System.Text;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Grammars.Rules
{
    public class StateRule : Rule
    {
        public int DotIndex { get; set; }

        public StateRule(NonTerminalSymbol leftSide, List<Symbol> rightSide) : base(leftSide, rightSide)
        {
            DotIndex = 0;
        }

        public StateRule(NonTerminalSymbol leftSide, List<Symbol> rightSide, int dotIndex) : base(leftSide, rightSide)
        {
            DotIndex = dotIndex;
        }
        
        public static StateRule CreateFromRule(Rule rule)
        {
            if (rule == null)
                return null;

            return new StateRule(rule.LeftSide, rule.RightSide);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(LeftSide);
            sb.Append("->");

            int i;
            for (i = 0; i < RightSide.Count; i++)
            {
                if (i == DotIndex)
                    sb.Append(".");

                sb.Append(RightSide[i]);
            }

            // if dot is at last position
            if (i == DotIndex)
                sb.Append(".");

            return sb.ToString();
        }
    }
}
