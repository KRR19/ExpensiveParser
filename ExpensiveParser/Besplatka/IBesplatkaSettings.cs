using ExpensiveParser.Parser;

namespace ExpensiveParser.Besplatka
{
    public interface IBesplatkaSettings : IParserSettings
    {
        string Category { get; set; }
        string Sections { get; set; }
        string Filter { get; set; }
        int LoadCount { get; set; }
        string URL { get; set; }
    }
}
