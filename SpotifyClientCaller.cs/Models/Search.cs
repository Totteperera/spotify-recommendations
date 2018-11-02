using Newtonsoft.Json;

namespace SpotifyClientCaller.Models
{
    public class Search
    {
        [JsonProperty("albums")]
        public PagingObject<AlbumSimple> Albums { get; set; }
        [JsonProperty("artists")]
        public PagingObject<ArtistFull> Artists { get; set; } 
        [JsonProperty("tracks")]
        public PagingObject<TrackFull> Tracks { get; set; }  
        [JsonProperty("playlists")]
        public PagingObject<PlaylistSimple> Playlists { get; set; }
    }
}
