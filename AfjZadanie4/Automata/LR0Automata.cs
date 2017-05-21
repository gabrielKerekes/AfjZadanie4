using System.Collections.Generic;

namespace AfjZadanie4.Automata
{
    public class LR0Automata
    {
        public List<State> States { get; set; }

        public LR0Automata(List<State> states)
        {
            States = states;
        }
    }
}
