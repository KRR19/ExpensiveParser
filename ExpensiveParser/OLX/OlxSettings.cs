namespace ExpensiveParser.OLX
{
    public class OlxSettings : IOlxSettings
    {
        public string BaseUrl { get; set; } = "https://www.olx.ua";
        public string Category { get; set; } = "elektronika";
        public string Sections { get; set; } = "telefony-i-aksesuary";
        public string Filter { get; set; } = "?search%5Border%5D=filter_float_price%3Adesc";
        public int LoadCount { get; set; }

        public OlxSettings(int loadCount)
        {
            this.LoadCount = loadCount;
        }
    }
}
