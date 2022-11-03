using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.WebApp.Controllers
{
    public class UserRecuiterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
