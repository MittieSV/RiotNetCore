using System.Runtime.Serialization;

namespace RiotNetCore.Summoner
{
    //<summary>
    // represents a summoner 
    //</summary>
    public class SummonerDTO
    {
        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [DataMember(Name = "profileIconId")]
        public int profileIconId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [DataMember(Name = "name")]
        public string name { get; set; }

        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [DataMember(Name = "puuid")]
        public string puuid { get; set; }
        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [DataMember(Name = "summonerLevel")]
        public long summonerLevel { get; set; }
        /// <summary>
        /// Date summoner was last modified specified as epoch milliseconds. The following events will update this timestamp: profile icon change, playing the tutorial or advanced tutorial, finishing a game, summoner name change
        /// </summary>
        [DataMember(Name = "revisionDate")]
        public long revisionDate { get; set; }
        /// <summary>
        /// Encrypted summoner ID. Max length 63 characters.
        /// </summary>
        [DataMember(Name = "id")]
        public string id { get; set; }
        /// <summary>
        /// Encrypted account ID. Max length 56 characters.
        /// </summary>
        [DataMember(Name = "accountId")]
        public string accountId { get; set; }
    }
}
