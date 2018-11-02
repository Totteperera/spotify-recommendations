using System.Web.Mvc;

namespace Recommendations.Controllers
{
    public class HeaderController : Controller
    {
        public ActionResult Header()
        {
            return View("_Header");
        }
    }
}