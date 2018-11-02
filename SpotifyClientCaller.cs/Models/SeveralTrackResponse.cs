using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class SeveralTrackResponse
    {
        [JsonProperty("tracks")]
        public List<TrackFull> Tracks { get; set; }
    }
}