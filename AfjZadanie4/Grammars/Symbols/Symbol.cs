namespace AfjZadanie4.Grammars.Symbols
{
    public class Symbol
    {
        public string Name { get; set; }

        public Symbol(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
