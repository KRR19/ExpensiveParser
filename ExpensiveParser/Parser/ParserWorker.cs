﻿using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ExpensiveParser.Besplatka;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensiveParser.Parser
{
    public class ParserWorker
    {
        private readonly int COUNT_LOAD_DATA = 3;
        private IBesplatkaSettings Settings;
        private bool isActive;

        public event Action<object> OnComplete;
        public ParserWorker()
        {
            this.Settings = new BesplatkaSettings(this.COUNT_LOAD_DATA);
        }
        public void Start()
        {
            isActive = true;
            Worker();
        }
        public async void Worker()
        {
            List<BesplatkaDocumentModel> models = new List<BesplatkaDocumentModel>();
            string[] links = await GetLinksAsync();

            for(int advertIndex = 0; advertIndex < COUNT_LOAD_DATA; advertIndex++)
            {
                if(!isActive)
                {
                    OnComplete?.Invoke(this);
                    return;
                }
                HtmlLoader loader = new HtmlLoader();
                BesplatkaParser parser = new BesplatkaParser();
                HtmlParser domDocument = new HtmlParser();
                string source = await loader.GetHtmlDocument(links[advertIndex]);
                IHtmlDocument document = await domDocument.ParseDocumentAsync(source);
                BesplatkaDocumentModel model = parser.Parse(document);
                model.Link = links[advertIndex];
                models.Add(model);
            }
        }
        

        public async Task<string[]> GetLinksAsync()
        {
            HtmlLoader loader = new HtmlLoader();
            string source = await loader.GetHtmlDocument(Settings.URL);
            HtmlParser domDocument = new HtmlParser();
            IHtmlDocument document = await domDocument.ParseDocumentAsync(source);
            BesplatkaParser parser = new BesplatkaParser();
            string[] links = parser.GetLink(document, COUNT_LOAD_DATA);
            return links;
        }
    }
}
