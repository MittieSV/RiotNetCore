using RiotNetCore.RequestGuard;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace RiotNetCore.Summoner
{
    class Summoner : ISummoner
    {
        
        private const string SummonerRootUrl = "/lol/summoner/v4/summoners";     
        private const string SummonerByNameUrl = "by-name/{CurrentName}";
        
        readonly string url;

        private IRequestLimit _requesLimit;

        public Summoner(IRequestLimit reqlim)
        {
            _requesLimit = reqlim;
            url = $"{SummonerRootUrl}/{SummonerByNameUrl}";
        }

        public async Task<SummonerDTO> GetSummonerByName(string name)
        {
            
            var summonerUrl = url.Replace("{CurrentName}", name);
            var tmp = await _requesLimit.GetRequest(summonerUrl);
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(tmp));
            stream.Position = 0;
            var serializer = new DataContractJsonSerializer(typeof(SummonerDTO));
            var summoner = serializer.ReadObject(stream) as SummonerDTO;

            return summoner;
        }
        
    }
}
