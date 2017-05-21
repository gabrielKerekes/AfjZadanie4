using AfjZadanie4.Grammars;

namespace AfjZadanie4.Automata
{
    public static class LR0AutomataCreator
    {
        public static LR0Automata TryCreateAutomata(Grammar grammar)
        {
            var states = StateCreator.CreateStates(grammar);

            return new LR0Automata(states);
        }
    }
}
