using Xunit;

namespace RiotNetCore.Test
{
    public class RiotApiTest
    {
        [Fact]
        public async void GetSummoner1()
        {
            RiotApi api = new RiotApi("RGAPI-78d23f4f-be4f-4c38-a1df-be08a5f7b9d7");
            var tmp = await api.GetSummonerByName("RiotSchmick","na1");
            Assert.Equal("RiotSchmick", tmp.name);
        }       
    }

    public class RiotApiTest2
    {
        [Fact]
        public async void GetSummoner2()
        {
            RiotApi api = new RiotApi("RGAPI-78d23f4f-be4f-4c38-a1df-be08a5f7b9d7")
            {
                Settings = new Settings() { ThrowIfLimitReached = false }
            };
            var tmp = await api.GetSummonerByName("d1d", "ru");
            Assert.Equal("d1d", tmp.name);
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
