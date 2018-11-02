using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class GenreSeed
    {
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }
    }
}