using System.Threading.Tasks;

namespace RiotNetCore.RequestGuard
{
    interface IRequestLimit
    {
        Task<string> GetRequestAsync(string url);
    }
}
