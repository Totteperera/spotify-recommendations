using System.Threading.Tasks;
using System.Web.Mvc;
using Recommendations.Models;
using SpotifyClientCaller;

namespace Recommendations.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new SpotifyApiClient();
            var genres = await client.GetGenreSeed();

            // Write a class for building viewmodels
            var model = new StartPageViewModel
            {
                Genres = genres.Genres
            };

            return View("Index", model);
        }
    }
}