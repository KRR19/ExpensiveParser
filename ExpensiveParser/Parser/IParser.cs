using AngleSharp.Html.Dom;

namespace ExpensiveParser.Parser
{
    public interface IParser<T> where T : class
    {
        string[] GetLink(IHtmlDocument document, int count);
        T Parse(IHtmlDocument document);
    }
}
