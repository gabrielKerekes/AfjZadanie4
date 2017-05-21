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
            //if (args.Length == 0)
            //{
            //    System.Console.WriteLine("Grammar filename needed as argument.");
            //    return;
            //}

            //var fileName = args[0];

            var fileNames = new List<string> { "testy\\gramatika1.txt", "testy\\gramatika2.txt", "testy\\gramatika3.txt", "testy\\gramatika4.txt", "testy\\gramatika5.txt", };
            foreach (var fileName in fileNames)
            {
                try
                {
                    var grammar = GrammarReader.ReadGrammarFromFile(fileName);
                    LR0AutomataCreator.TryCreateAutomata(grammar);
                }
                catch (RedRedConflictException)
                {
                    Console.WriteLine("NIE - konflikt REDUKCIA/REDUKCIA");
                    continue;
                }
                catch (PresunRedConflictException)
                {
                    Console.WriteLine("NIE - konflikt PRESUN/REDUKCIA");
                    continue;
                }

                Console.WriteLine("ANO");
            }
        }
    }
}
