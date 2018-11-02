using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class Image
    {
        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }
    }
}