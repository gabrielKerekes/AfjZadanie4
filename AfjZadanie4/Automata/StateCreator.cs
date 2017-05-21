using System;
using System.Collections.Generic;
using System.Linq;
using AfjZadanie4.Grammars;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Automata
{
    public class StateCreator
    {
        public static List<State> CreateStates(Grammar grammar)
        {
            var initialState = CreateInitialState(grammar);

            var states = new List<State> { initialState };

            for (var i = 0; i < states.Count; i++)
            {
                var currentState = states[i];

                var initialStateSymbolsWithDotOnLeftSide = currentState.Rules.Where(r => r.RightSide.Count > r.DotIndex).Select(r => r.RightSide[r.DotIndex]);
                foreach (var symbol in initialStateSymbolsWithDotOnLeftSide)
                {
                    var newState = CreateState(grammar, currentState, symbol, $"S{GetNextStateNumber(states)}");
                    
                    if (DoesStateAlreadyExist(states, newState))
                        continue;

                    CheckForConflicts(newState.Rules);

                    states.Add(newState);
                }
            }

            return states;
        }

        private static bool DoesStateAlreadyExist(List<State> states, State newState)
        {
            return states.Any(state => string.Join(",", state.Rules) == string.Join(",", newState.Rules));
        }

        private static void CheckForConflicts(List<StateRule> newStateRules)
        {
            if (newStateRules.Count(r => r.DotIndex >= r.RightSide.Count) > 1)
                throw new RedRedConflictException("Konflikt - redukcia/redukcia");

            if (newStateRules.Any(r => r.DotIndex >= r.RightSide.Count) && newStateRules.Any(r => r.DotIndex < r.RightSide.Count))
                throw new PresunRedConflictException("Konflikt - presun/redukcia");
        }
        
        public static State CreateInitialState(Grammar grammar)
        {
            var rules = new List<StateRule>();

            rules.AddRange(grammar.Rules.Where(r => r.LeftSide.Name == grammar.StartSymbol.Name).Select(StateRule.CreateFromRule));

            GetRulesOfSymbolsAfterDot(grammar, rules);

            return new State("S0", rules);
        }
        
        private static void GetRulesOfSymbolsAfterDot(Grammar grammar, List<StateRule> existingRules)
        {
            var addedRules = new List<Rule>();

            for (var i = 0; i < existingRules.Count; i++)
            {
                var existingRule = existingRules[i];

                var rulesWithSymbolAfterDotOnLeftSide = grammar.Rules.Where(r => existingRule.DotIndex < existingRule.RightSide.Count
                                                                                 && r.LeftSide.Name == existingRule.RightSide[existingRule.DotIndex].Name
                                                                                 && !existingRules.Contains(r)
                                                                                 && !addedRules.Contains(r)).ToList();

                if (rulesWithSymbolAfterDotOnLeftSide.Count > 0)
                {
                    var newRules = rulesWithSymbolAfterDotOnLeftSide.Select(StateRule.CreateFromRule).ToList();
                    addedRules.AddRange(rulesWithSymbolAfterDotOnLeftSide);
                    existingRules.AddRange(newRules);
                    i = -1;
                }
            }
        }
        
        public static State CreateState(Grammar grammar, State previousState, Symbol symbolFollowed, string name)
        {
            var rules = new List<StateRule>();
            
            var rulesToAdvance = previousState.Rules.Where(r => r.RightSide.Count > r.DotIndex && r.RightSide[r.DotIndex].Name == symbolFollowed.Name);

            var advancedRules = new List<StateRule>();
            foreach (var ruleToAdvance in rulesToAdvance)
            {
                var advancedRule = StateRule.CreateFromRule(ruleToAdvance);
                advancedRule.DotIndex = ruleToAdvance.DotIndex + 1;

                advancedRules.Add(advancedRule);
            }

            rules.AddRange(advancedRules);

            GetRulesOfSymbolsAfterDot(grammar, rules);
            //rules.AddRange(rulesWithSymbolAfterDotOnLeftSide.Select(StateRule.CreateFromRule));

            return new State(name, rules);
        }

        public static int GetNextStateNumber(List<State> states)
        {
            return states.Count;
        }
    }

    public class RedRedConflictException : Exception
    {
        public RedRedConflictException(string message) : base(message)
        {
        }
    }

    public class PresunRedConflictException : Exception
    {
        public PresunRedConflictException(string message) : base(message)
        {
        }
    }
}
