using System.Threading.Tasks;

namespace RiotNetCore.Summoner
{
    interface ISummoner
    {
        Task<SummonerDTO> GetSummonerByName(string name);
    }
}
