using System.Threading.Tasks;

namespace RiotNetCore.Summoner
{
    interface ISummoner
    {
        Task<SummonerDTO> GetSummonerByNameAsync(string name);
    }
}
