using System.Collections.Generic;

namespace RiotNetCore.Match
{
    public class MatchDto
    {
        public int seasonId { get; set; }
        public int queueId { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public List<TeamStatsDto> teams { get; set; }
    }
}
