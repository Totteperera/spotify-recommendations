using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyClientCaller.Models;

namespace SpotifyClientCaller
{
    public class SpotifyApiClient
    {
        private readonly ApiUrlBuilder _apiUrlBuilder;
        private readonly HttpMethods _httpMethods;

        public SpotifyApiClient()
        {
            _apiUrlBuilder = new ApiUrlBuilder();
            _httpMethods = new HttpMethods(_apiUrlBuilder);
        }

        public async Task<Search> Search(string q)
        {
            var requestUrl = _apiUrlBuilder.GetSearchUrl(q, "album,track,artist,playlist");
            return await _httpMethods.GetAsync<Search>(requestUrl);
        }

        public async Task<RecommendationsResponse> GetRecommendationsByGenreSeed(List<string> genres, decimal danceability, decimal instrumentalness, decimal valence, int popularity)
        {
            var requestUrl = _apiUrlBuilder.GetRecommendationsUrl(genres, danceability, instrumentalness, valence, popularity, "SE");
            return await _httpMethods.GetAsync<RecommendationsResponse>(requestUrl);
        }

        public async Task<GenreSeed> GetGenreSeed()
        {
            var requestUrl = _apiUrlBuilder.GetGenreSeedUrl();
            return await _httpMethods.GetAsync<GenreSeed>(requestUrl);
        }

        public async Task<SeveralTrackResponse> GetSeveralTracks(List<string> trackIds)
        {
            var requestUrl = _apiUrlBuilder.GetSeveralTracksUrl(trackIds);
            return await _httpMethods.GetAsync<SeveralTrackResponse>(requestUrl);
        }
    }
}