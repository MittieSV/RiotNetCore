using RiotNetCore.RequestGuard;
using RiotNetCore.Summoner;
using System.Threading.Tasks;

namespace RiotNetCore
{
    public class RiotApi
    {
        private readonly string _apiKey;
        public Settings Settings { get; private set; }


        public RiotApi(string apikey)
        {
            _apiKey = apikey;
            Settings = new Settings();
        }

        public async Task<SummonerDTO> GetSummonerByName(string name, string region)
        {  
            ISummoner summoner = new Summoners(new RequestLimit(region, _apiKey, Settings));           
            var tmp =  await summoner.GetSummonerByNameAsync(name);
            return tmp;   
        }
    }

   
}
