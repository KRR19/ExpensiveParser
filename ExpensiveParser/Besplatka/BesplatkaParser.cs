using AngleSharp.Html.Dom;
using ExpensiveParser.Parser;
using System.Linq;

namespace ExpensiveParser.Besplatka
{
    public class BesplatkaParser : IParser<BesplatkaDocumentModel>
    {
        private const int TOP_ADS = 3;
        public string[] GetLink(IHtmlDocument document, int count)
        {
            IBesplatkaSettings settings = new BesplatkaSettings(count);
            string[] links = document.QuerySelectorAll("a.m-title").Skip(TOP_ADS).Take(count).Select(link => $"{settings.BaseUrl}{link.GetAttribute("href")}").ToArray();
            return links;
        }

        public BesplatkaDocumentModel Parse(IHtmlDocument document)
        {
            string currency = document.QuerySelectorAll("span.currency").Select(title => title.TextContent).FirstOrDefault();
            string price = document.QuerySelectorAll("div.card-price").Select(span => span.QuerySelectorAll("span").FirstOrDefault().TextContent).FirstOrDefault();
            BesplatkaDocumentModel model = new BesplatkaDocumentModel
            {
                Headline = document.QuerySelectorAll("h1.card-title").Select(title => title.TextContent).FirstOrDefault(),
                SellerName = document.QuerySelectorAll("span.t-000").Select(title => title.TextContent).FirstOrDefault(),
                Price = $"{ price } {currency}"
            };


            return model;
        }
    }
}
