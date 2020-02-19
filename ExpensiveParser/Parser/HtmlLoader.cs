using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensiveParser.Parser
{
    public class HtmlLoader
    {
        public async Task<string> GetHtmlDocument(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string source = null;
            if (response !=null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
