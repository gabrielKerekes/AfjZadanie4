using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4
{
    public class Rule
    {
        public string LeftSide { get; set; }
        public string RightSide { get; set; }

        public Rule(string leftSide, string rightSide)
        {
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public override string ToString()
        {
            return $"{LeftSide}->{RightSide}";
        }
    }
}
