using RiotNetCore.RequestGuard;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace RiotNetCore.Summoner
{
    class Summoners : ISummoner
    {
        
        private const string SummonerRootUrl = "/lol/summoner/v4/summoners";     
        private const string SummonerByNameUrl = "by-name/{CurrentName}";
        
        readonly string url;

        private readonly IRequestLimit _requesLimit;

        public Summoners(IRequestLimit reqlim)
        {
            _requesLimit = reqlim;
            url = $"{SummonerRootUrl}/{SummonerByNameUrl}";
        }

        public async Task<SummonerDTO> GetSummonerByNameAsync(string name)
        {

            var summonerUrl = url.Replace("{CurrentName}", name);
            var tmp = await _requesLimit.GetRequestAsync(summonerUrl);
            SummonerDTO summoner = null;
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(tmp)))
            {
                stream.Position = 0;
                var serializer = new DataContractJsonSerializer(typeof(SummonerDTO));
                summoner = serializer.ReadObject(stream) as SummonerDTO;
            }

            return summoner;
        }

    }
}
