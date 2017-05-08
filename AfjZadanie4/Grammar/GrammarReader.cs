using System.IO;
using System.Linq;

namespace AfjZadanie4.Grammar
{
    public class GrammarReader
    {
        public static Grammar ReadGrammarFromFile(string fileName)
        {
            return GrammarParser.Parse(File.ReadLines(fileName).ToList());
        }
    }
}
