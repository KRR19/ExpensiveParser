namespace ExpensiveParser.Besplatka
{
    public class BesplatkaSettings : IBesplatkaSettings
    {
        public string BaseUrl { get; set; } = "https://besplatka.ua";
        public string Category { get; set; } = "electronika-i-bitovaya-tehnika";
        public string Sections { get; set; } = "smartfone-telefone";
        public string Filter { get; set; } = "sort=price-a-z";
        public int LoadCount { get; set; }
        public string URL { get; set; }

        public BesplatkaSettings(int loadCount)
        {
            this.LoadCount = loadCount;
            this.URL = $"{BaseUrl}/{Category}/{Sections}?{Filter}";
        }
    }
}
