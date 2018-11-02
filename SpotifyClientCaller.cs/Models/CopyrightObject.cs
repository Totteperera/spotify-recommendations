using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class CopyrightObject
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}