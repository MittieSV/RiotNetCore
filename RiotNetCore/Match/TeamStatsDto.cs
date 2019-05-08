namespace RiotNetCore.Match
{
    public class TeamStatsDto
    {
        /// <summary>
        /// 100 for blue side. 200 for red side.
        /// </summary>
        public int teamId { get; set; }
        /// <summary>
        /// String indicating whether or not the team won. 
        /// There are only two values visibile in public match history. 
        /// (Legal values: Fail, Win)
        /// </summary>
        public string win { get; set; }
    }
}