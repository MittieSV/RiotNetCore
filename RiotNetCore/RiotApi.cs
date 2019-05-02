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

        public async Task<SummonerDTO> GetSummonerByName(string name)
        {
           
            ISummoner summoner = new Summoner.Summoner(new RequestLimit("na1", _apiKey));           
            var tmp =  await summoner.GetSummonerByName(name);
            return tmp;
           
        }
    }

   
}
