using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AfjZadanie4.Automata;
using AfjZadanie4.Grammars;
using AfjZadanie4.Grammars.Rules;
using AfjZadanie4.Grammars.Symbols;

namespace AfjZadanie4.Tests
{
    [TestClass()]
    public class LR0AutomataCreatorTests
    {
        [TestMethod()]
        public void CreateInitialStateTest()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var terminal_a = new TerminalSymbol("a");
            var terminal_b = new TerminalSymbol("b");

            var nonTerminals = new List<NonTerminalSymbol>
            {
                nonTerminal_S,
                nonTerminal_A,
            };
            var terminals = new List<TerminalSymbol>
            {
                terminal_a,
                terminal_b,
            };

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_S, nonTerminal_A),
                new Rule(nonTerminal_A, terminal_a),
            };

            var grammar = new Grammar(nonTerminals, terminals, rules);

            var initialState = StateCreator.CreateInitialState(grammar);
            Assert.AreEqual("S0;A->.a,S->.A;", initialState.ToString());

            grammar.Rules.Add(new Rule(nonTerminal_A, terminal_b));
            initialState = StateCreator.CreateInitialState(grammar);
            Assert.AreEqual("S0;A->.a,A->.b,S->.A;", initialState.ToString());
        }

        [TestMethod()]
        public void CreateInitialStateTest2()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var nonTerminal_C = new NonTerminalSymbol("C");
            var terminal_a = new TerminalSymbol("a");
            var terminal_b = new TerminalSymbol("b");

            var nonTerminals = new List<NonTerminalSymbol>
            {
                nonTerminal_S,
                nonTerminal_A,
                nonTerminal_C,
            };
            var terminals = new List<TerminalSymbol>
            {
                terminal_a,
                terminal_b,
            };

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A, terminal_b }),
                new Rule(nonTerminal_A, new List<Symbol> { nonTerminal_C, terminal_a }),
                new Rule(nonTerminal_C, new List<Symbol> { terminal_a, nonTerminal_A }),
                new Rule(nonTerminal_C, new List<Symbol> { terminal_a, nonTerminal_S }),
                new Rule(nonTerminal_C, terminal_b),
            };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            var initialState = StateCreator.CreateInitialState(grammar);

            Assert.AreEqual("S0;S->.aAb,S'->.S;", initialState.ToString());
        }

        [TestMethod()]
        public void CreateStateTest()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var terminal_a = new TerminalSymbol("a");
            var terminal_b = new TerminalSymbol("b");

            var nonTerminals = new List<NonTerminalSymbol>
            {
                nonTerminal_S,
                nonTerminal_A,
            };
            var terminals = new List<TerminalSymbol>
            {
                terminal_a,
                terminal_b,
            };

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A }),
                new Rule(nonTerminal_A, terminal_a),
            };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            var initialState = StateCreator.CreateInitialState(grammar);

            var createdState = StateCreator.CreateState(grammar, initialState, terminal_a, "S1");
            Assert.AreEqual("S1;A->.a,S->a.A;", createdState.ToString());
        }

        [TestMethod()]
        public void CreateStateTest2()
        {
            var nonTerminal_S = new NonTerminalSymbol("S");
            var nonTerminal_A = new NonTerminalSymbol("A");
            var nonTerminal_C = new NonTerminalSymbol("C");
            var terminal_a = new TerminalSymbol("a");
            var terminal_b = new TerminalSymbol("b");

            var nonTerminals = new List<NonTerminalSymbol>
            {
                nonTerminal_S,
                nonTerminal_A,
                nonTerminal_C,
            };
            var terminals = new List<TerminalSymbol>
            {
                terminal_a,
                terminal_b,
            };

            var rules = new List<Rule>
            {
                new Rule(nonTerminal_S, new List<Symbol> { terminal_a, nonTerminal_A, terminal_b }),
                new Rule(nonTerminal_A, new List<Symbol> { nonTerminal_C, terminal_a }),
                new Rule(nonTerminal_C, new List<Symbol> { terminal_a, nonTerminal_A }),
                new Rule(nonTerminal_C, new List<Symbol> { terminal_a, nonTerminal_S }),
                new Rule(nonTerminal_C, terminal_b),
            };

            var grammar = new Grammar(nonTerminals, terminals, rules);
            var initialState = StateCreator.CreateInitialState(grammar);

            var createdState = StateCreator.CreateState(grammar, initialState, terminal_a, "S1");
            Assert.AreEqual("S1;A->.Ca,C->.aA,C->.aS,C->.b,S->a.Ab;", createdState.ToString());

            var createdState2 = StateCreator.CreateState(grammar, createdState, nonTerminal_C, "S2");
            Assert.AreEqual("S2;A->C.a;", createdState2.ToString());

            var createdState3 = StateCreator.CreateState(grammar, createdState, terminal_a, "S3");
            Assert.AreEqual("S3;A->.Ca,C->.aA,C->.aS,C->.b,C->a.A,C->a.S,S->.aAb;", createdState3.ToString());
        }
    }
}