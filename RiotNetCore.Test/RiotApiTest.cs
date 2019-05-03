using Xunit;

namespace RiotNetCore.Test
{
    public class RiotApiTest
    {
        [Fact]
        public async void GetSummoner()
        {
            RiotApi api = new RiotApi("RGAPI-79ade177-b4b6-48d4-89dc-f23f26a8d5b6");
            var tmp = await api.GetSummonerByName("RiotSchmick","na1");
            Assert.Equal("RiotSchmick", tmp.name);
        }
    }
}
