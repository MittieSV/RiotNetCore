using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotNetCore.RequestGuard
{
    class RequestLimit : IRequestLimit
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string BaseUrl = "https://{region}.api.riotgames.com";
        private readonly string _region;
        private readonly string _apikey;
        private readonly Settings _settings;
        private readonly IMemoryCache _cache;

        public RequestLimit(string region, string apiKey, Settings settings)
        {
            _region = region;
            _apikey = apiKey;
            _settings = settings;
            
        }
        public async Task<string> GetRequestAsync(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var tmpUrl = $"{BaseUrl}{url}?api_key={_apikey}";
            tmpUrl = tmpUrl.Replace("{region}", _region);
            string source = null;
            HttpResponseMessage response = await TaskAsync(tmpUrl);
           
            if (response.StatusCode == (HttpStatusCode)429)
            {
                if(_settings.ThrowIfLimitReached)
                    throw new RiotNetCoreRequestException("requests limit reached", response.StatusCode);
                var retryAfter = response.Headers.GetValues("Retry-After");
                Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(retryAfter.FirstOrDefault()))).Wait();
                
                response = await TaskAsync(tmpUrl);
            }
            //TODO Create a response status handler
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
               
                source = await response.Content.ReadAsStringAsync();
                
            }
            else
            {
                throw new RiotNetCoreRequestException("Wrong api key", response.StatusCode);
            }
            
            return source;
        }


        private async Task<HttpResponseMessage> TaskAsync(string tmpUrl)
        {
            var response = await client.GetAsync(tmpUrl);
            response.Headers.TryGetValues("X-App-Rate-Limit-Count", out IEnumerable<string> appRateLimitCount);
            response.Headers.TryGetValues("X-Method-Rate-Limit-Count", out IEnumerable<string> methodRateLimitCount);
            response.Headers.TryGetValues("X-App-Rate-Limit", out IEnumerable<string> appRateLimit);
            response.Headers.TryGetValues("X-Method-Rate-Limit", out IEnumerable<string> methodRateLimit);
            return response;
        }
    }
}
