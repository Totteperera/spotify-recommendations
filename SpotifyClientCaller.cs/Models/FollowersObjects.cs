using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class FollowersObject
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}