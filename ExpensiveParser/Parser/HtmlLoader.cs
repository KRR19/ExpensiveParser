using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensiveParser.Parser
{
    public class HtmlLoader
    {
        private readonly HttpClient Client;

        public HtmlLoader()
        {
            Client = new HttpClient();
        }

        public async Task<string> GetHtmlDocument(string url)
        {
            var response = await Client.GetAsync(url);
            string source = null;
            if (response !=null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
