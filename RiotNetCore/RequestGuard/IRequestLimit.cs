using System.Threading.Tasks;

namespace RiotNetCore.RequestGuard
{
    interface IRequestLimit
    {
        Task<string> GetRequest(string url);
    }
}
