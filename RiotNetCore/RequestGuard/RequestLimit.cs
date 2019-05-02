using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotNetCore.RequestGuard
{
    class RequestLimit : IRequestLimit
    {
        private readonly HttpClient client = new HttpClient();
        private string BaseUrl = "https://{region}.api.riotgames.com";
        private string _region;
        private string _apikey;

        public RequestLimit(string region, string apiKey)
        {
            _region = region;
            _apikey = apiKey;
        }
        public async Task<string> GetRequest(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var tmpUrl = $"{BaseUrl}{url}?api_key={_apikey}";
            tmpUrl = tmpUrl.Replace("{region}", _region);
            string source = null;
            var response = await client.GetAsync(tmpUrl);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
