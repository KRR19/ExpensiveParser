using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace ExpensiveParser.Core
{
    public class HtmlLoader
    {
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            url = $"{settings.BaseUrl}/{settings.Category}/{settings.Section}/{settings.FilterParam}";
        }
        public async Task<string> GetSource()
        {
            string source = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = await client.GetAsync(url);

            if(responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                source = await responce.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
