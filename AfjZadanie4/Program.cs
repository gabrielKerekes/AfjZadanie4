using System;
using System.Collections.Generic;
using AfjZadanie4.Automata;
using AfjZadanie4.Grammars;

namespace AfjZadanie4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Grammar filename needed as argument.");
                return;
            }

            var fileName = args[0];

            try
            {
                var grammar = GrammarReader.ReadGrammarFromFile(fileName);
                LR0AutomataCreator.TryCreateAutomata(grammar);

                Console.WriteLine("ANO");
            }
            catch (RedRedConflictException)
            {
                Console.WriteLine("NIE - konflikt REDUKCIA/REDUKCIA");
            }
            catch (PresunRedConflictException)
            {
                Console.WriteLine("NIE - konflikt PRESUN/REDUKCIA");
            }
        }
    }
}
