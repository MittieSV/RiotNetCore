using System;
namespace RiotNetCore.Match
{
    public class MatchReferenceDto
    {
        public string lane { get; set; }
        public int gameId { get; set; }
        public int champion { get; set; }
        public string platformId { get; set; }
        public int season { get; set; }
        public int queue { get; set; }
        public string role { get; set; }
        public long timestamp { get; set; }

    }
}
