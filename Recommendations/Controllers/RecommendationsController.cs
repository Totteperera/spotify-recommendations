using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Recommendations.Models;
using SpotifyClientCaller;

namespace Recommendations.Controllers
{
    public class RecommendationsController : Controller
    {
        public async Task<ActionResult> GetRecommendations(string genres, decimal danceability, decimal instrumentalness, decimal valence, int popularity)
        {
            // Must make genres mandatory
            var genreList = JsonConvert.DeserializeObject<List<string>>(genres);

            var client = new SpotifyApiClient();
            var recommendationsResponse = await client.GetRecommendationsByGenreSeed(genreList, danceability, instrumentalness, valence, popularity);
            var severalTrackResponse = await client.GetSeveralTracks(recommendationsResponse.Tracks.Select(x => x.Id).ToList());
            var model = new RecommendationResultViewModel
            {
                Tracks = severalTrackResponse.Tracks
            };
            
            return View("_RecommendationResult", model);
        }
    }
}