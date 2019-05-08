using RiotNetCore.RequestGuard;

namespace RiotNetCore.Match
{
    abstract class Match
    {
        protected const string RootURL = "/lol/match/v4";
        protected string url;

        protected readonly IRequestLimit _requesLimit;

        protected Match(IRequestLimit requesLimit)
        {
            _requesLimit = requesLimit;
        }
    }
}
