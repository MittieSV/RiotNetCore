using RiotNetCore.RequestGuard;
using RiotNetCore.Summoner;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RiotNetCore.Match;

namespace RiotNetCore
{
    public class RiotApi
    {
        private readonly string _apiKey;
        IMemoryCache cache;
        public Settings Settings { get;  set; }


        public RiotApi(string apikey)
        {
            _apiKey = apikey;
            Settings = new Settings();
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<SummonerDTO> GetSummonerByName(string name, string region)
        {  
            ISummoner summoner = new Summoners(new RequestLimit(region, _apiKey, Settings));
            SummonerDTO result;
            if (!cache.TryGetValue($"{name}:{region}", out result))
            {
                SummonerDTO tmp = await summoner.GetSummonerByNameAsync(name);
                result = cache.Set($"{name}:{region}", tmp);
            }   
            return result;   
        }
        
        public async Task<MatchlistDto> GetMatchList(string encryptedAccountId, string region)
        {
            
            Matchlists list = new Matchlists(new RequestLimit(region, _apiKey, Settings), encryptedAccountId);
            MatchlistDto tmp = await list.ByAccount();
            return tmp;
        }
        public async Task<MatchDto> GetMatchById(int id, string region)
        {

            Matches match = new Matches(new RequestLimit(region, _apiKey, Settings), id);
            MatchDto tmp = await match.GetByIdAsync();
            return tmp;
        }
    }

   
}
