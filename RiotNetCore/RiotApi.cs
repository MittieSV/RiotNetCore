using RiotNetCore.RequestGuard;
using RiotNetCore.Summoner;
using System.Threading.Tasks;

namespace RiotNetCore
{
    public class RiotApi
    {
        private string _apiKey;
        
        
        public RiotApi(string apikey)
        {
            _apiKey = apikey;
        }

        public async Task<SummonerDTO> GetSummonerByName(string name, string region)
        {
           
            ISummoner summoner = new Summoners(new RequestLimit(region, _apiKey));           
            var tmp =  await summoner.GetSummonerByName(name);
            return tmp;
           
        }
    }

   
}
