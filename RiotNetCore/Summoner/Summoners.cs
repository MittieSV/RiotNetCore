using RiotNetCore.Helpers;
using RiotNetCore.RequestGuard;
using System.Threading.Tasks;


namespace RiotNetCore.Summoner
{
    class Summoners : ISummoner
    {
        
        private const string SummonerRootUrl = "/lol/summoner/v4/summoners";     
        private const string SummonerByNameUrl = "/by-name/{CurrentName}";
        
        readonly string url;

        private readonly IRequestLimit _requesLimit;

        public Summoners(IRequestLimit reqlim)
        {
            _requesLimit = reqlim;
            url = $"{SummonerRootUrl}{SummonerByNameUrl}";
        }

        public async Task<SummonerDTO> GetSummonerByNameAsync(string name)
        {
            var summonerUrl = url.Replace("{CurrentName}", name);
            string tmp = await _requesLimit.GetRequestAsync(summonerUrl);
            return JsonSerialization.JsonDeserialize<SummonerDTO>(tmp); ;
        }

    }
}
