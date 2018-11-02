using System.Threading.Tasks;
using System.Web.Mvc;
using Recommendations.Models;
using SpotifyClientCaller;

namespace Recommendations.Controllers
{
    public class SearchController : Controller
    {
        public async Task<ActionResult> Search(string q)
        {
            var client = new SpotifyApiClient();
            var searchResult = await client.Search(q);

            var model = new SearchResultViewModel
            {
                SearchResult = searchResult,
                SearchString = q
            };

            return View("_SearchResult", model);
        }
    }
}