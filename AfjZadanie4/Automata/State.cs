using System.Collections.Generic;
using System.Linq;
using AfjZadanie4.Grammars.Rules;

namespace AfjZadanie4.Automata
{
    public class State
    {
        public string Name { get; set; }
        public List<StateRule> Rules { get; set; }

        public State(string name, List<StateRule> rules)
        {
            Name = name;
            Rules = rules.OrderBy(r => r.ToString()).ToList();
        }

        public override string ToString()
        {
            return $"{Name};{string.Join(",", Rules)};";
        }
    }
}
