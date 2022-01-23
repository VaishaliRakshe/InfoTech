using Microsoft.AspNetCore.Mvc;

namespace InfoTech.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
