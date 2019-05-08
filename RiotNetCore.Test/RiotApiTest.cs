using RiotNetCore.Match;
using System.Linq;
using Xunit;

namespace RiotNetCore.Test
{

    public class RiotApiTest
    {
        [Fact]
        public async void GetSummoner()
        {
            RiotApi api = new RiotApi("RGAPI-0e186d8a-dbf0-491f-a3d9-30f23269e740");
            var tmp = await api.GetSummonerByName("RiotSchmick","na1");
            Assert.Equal("RiotSchmick", tmp.name);
        }       
    }

    public class RiotApiTestRu
    {
        string apikey = "RGAPI-0e186d8a-dbf0-491f-a3d9-30f23269e740";

        [Fact]
        public async void GetSummoner()
        {

            RiotApi api = new RiotApi(apikey)
            {
                Settings = new Settings() { ThrowIfLimitReached = false }
            };

            var tmp = await api.GetSummonerByName("d1d", "ru");

           
            Assert.Equal("d1d", tmp.name);
        }

        [Fact]
        public async void GetMatchList()
        {
            RiotApi api = new RiotApi(apikey)
            {
                Settings = new Settings() { ThrowIfLimitReached = false }
            };

            var tmp = await api.GetSummonerByName("d1d", "ru");
            MatchlistDto list = await api.GetMatchList(tmp.accountId, "ru");
            MatchReferenceDto matchId = list.matches.FirstOrDefault();

            Assert.Equal(166498934, matchId.gameId);
        }

        [Fact]
        public async void GetMathDetails_TeamStatsDto()
        {
            RiotApi api = new RiotApi(apikey)
            {
                Settings = new Settings() { ThrowIfLimitReached = false }
            };

            var tmp = await api.GetSummonerByName("d1d", "ru");
            MatchlistDto list = await api.GetMatchList(tmp.accountId, "ru");
            MatchReferenceDto matchId = list.matches.FirstOrDefault();
            MatchDto match = await api.GetMatchById(matchId.gameId, "ru");
            TeamStatsDto team = match.teams.FirstOrDefault();
            Assert.Equal("Win", team.win);
        }
    }



    public class RNCRequestExeprionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task KeyExpiredExeprionTest()
        {
            RiotApi api = new RiotApi("RGAPI-78d23f4f-be4f-4c38-a1df-be08a5f7b9d7");
            System.Exception ex = await Assert.ThrowsAsync<RequestGuard.RiotNetCoreRequestException>(() => api.GetSummonerByName("d1d", "ru"));
            
            Assert.Equal("Wrong api key", ex.Message);
        }
    }
}
