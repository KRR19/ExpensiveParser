using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using System;


namespace ExpensiveParser.Core
{
    public class ParserWorker
    {
        private IParserSettings Settings;
        private bool isActive;
        private HtmlLoader loader;
        public event Action<object> OnCompleted;
        public ParserWorker()
        {

        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        private async void Worker()
        {
            for (int itemNumber = 0; itemNumber < Settings.LoadCount; itemNumber++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                string source = await loader.GetSource();
                HtmlParser Parser = new HtmlParser();
                IHtmlDocument document = await Parser.ParseDocumentAsync(source);
            }

        }
    }
}
