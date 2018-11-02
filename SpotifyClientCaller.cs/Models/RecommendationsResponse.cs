using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class RecommendationsResponse
    {
        [JsonProperty("seeds")]
        public List<RecommendationSeed> Seeds { get; set; }

        [JsonProperty("tracks")]
        public List<TrackSimple> Tracks { get; set; }
    }
}