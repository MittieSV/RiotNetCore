using RiotNetCore.Helpers;
using RiotNetCore.RequestGuard;
using System.Threading.Tasks;

namespace RiotNetCore.Match
{
    class Matchlists : Match
    {
        
        private const string ByAccountIdURL = "/matchlists/by-account/{encryptedAccountId}";

        public Matchlists(IRequestLimit reqlim, string encryptedAccountId) : base(reqlim)
        {
            url = $"{RootURL}{ByAccountIdURL}";
            url= url.Replace("{encryptedAccountId}", encryptedAccountId);
        }
        public async Task<MatchlistDto> ByAccount()
        {
            string tmp = await _requesLimit.GetRequestAsync(url);
            return JsonSerialization.JsonDeserialize<MatchlistDto>(tmp);
        }
    }
}
