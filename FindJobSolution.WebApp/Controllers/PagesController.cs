using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.WebApp.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}