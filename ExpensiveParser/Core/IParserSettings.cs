namespace ExpensiveParser.Core
{
    public interface IParserSettings
    {
        public int LoadCount { get; set; }
        public string BaseUrl { get; set; }
        public string Category { get; set; }
        public string Section { get; set; }
        public string FilterParam { get; set; }

    }
}
