using System.Collections.Generic;
using System.Globalization;

namespace SpotifyClientCaller
{
    internal class ApiUrlBuilder
    {
        private const string BaseUrl = "https://api.spotify.com/v1/";
        private const string AccountsBaseUrl = "https://accounts.spotify.com/";

        public string GetSearchUrl(string q, string type, int limit = 10, int offset = 0, string market = "")
        {
            var includeMarket = !string.IsNullOrEmpty(market);

            var url = $"{BaseUrl}search" +
                      $"?q={q}" +
                      $"&type={type}" +
                      $"&limit={limit}" +
                      $"&offset={offset}";

            if (includeMarket)
            {
                url += $"&market={market}";
            }

            return url;
        }

        public string GetRecommendationsUrl(List<string> genres, decimal danceability, decimal instrumentalness, decimal valence, int popularity, string market = "")
        {
            var includeMarket = !string.IsNullOrEmpty(market);
            var clonedCulture = (CultureInfo) CultureInfo.InvariantCulture.Clone();
            clonedCulture.NumberFormat.NumberGroupSeparator = ".";
            var url = $"{BaseUrl}recommendations" +
                      $"?seed_genres={string.Join(",", genres)}" +
                      $"&target_danceability={danceability.ToString(clonedCulture)}" +
                      $"&target_popularity={popularity}" +
                      $"&target_instrumentalness={instrumentalness.ToString(clonedCulture)}" +
                      $"&target_valence={valence.ToString(clonedCulture)}" +
                      $"&limit=40";

            if (includeMarket)
            {
                url += $"&market={market}";
            }

            return url;
        }

        public string GetGenreSeedUrl()
        {
            return $"{BaseUrl}recommendations/available-genre-seeds";
        }

        public string GetSeveralTracksUrl(List<string> trackIds)
        {
            return $"{BaseUrl}tracks/" +
                   $"?ids={string.Join(",", trackIds)}";
        }

        public string GetAccessTokenUrl()
        {
            return $"{AccountsBaseUrl}api/token";
        }
    }
}