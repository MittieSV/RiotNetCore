using RiotNetCore.Helpers;
using RiotNetCore.RequestGuard;
using System.Threading.Tasks;

namespace RiotNetCore.Match
{
    class Matches : Match
    {
       
        private const string ByAccountIdURL = "/matches/{matchId}";

        public Matches(IRequestLimit reqlim, int matchId) : base(reqlim)
        {
           
            url = $"{RootURL}{ByAccountIdURL}";
            url = url.Replace("{matchId}", matchId.ToString());
        }

        public async Task<MatchDto> GetByIdAsync()
        {
            string tmp = await _requesLimit.GetRequestAsync(url);
            return JsonSerialization.JsonDeserialize<MatchDto>(tmp); ;

        }

    }
}

