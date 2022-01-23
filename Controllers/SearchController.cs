using Microsoft.AspNetCore.Mvc;

namespace InfoTech.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
