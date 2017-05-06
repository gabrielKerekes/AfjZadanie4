using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfjZadanie4
{
    public class GrammarReader
    {
        public static Grammar ReadGrammarFromFile(string fileName)
        {
            return GrammarParser.Parse(File.ReadLines(fileName).ToList());
        }
    }
}
