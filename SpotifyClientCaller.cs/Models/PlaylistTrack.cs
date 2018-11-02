using System;
using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class PlaylistTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("added_by")]
        public User AddedBy { get; set; }

        [JsonProperty("is_local")]
        public bool? IsLocal { get; set; }

        [JsonProperty("track")]
        public TrackFull Track { get; set; }
    }
}