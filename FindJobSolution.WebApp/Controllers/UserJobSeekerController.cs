using Microsoft.AspNetCore.Mvc;
using FindJobSolution.ViewModels.System.UsersJobSeeker;

namespace FindJobSolution.WebApp.Controllers
{
    public class UserJobSeekerController : Controller
    {
        private readonly UserJobSeekerController _userJobSeeker;
        private readonly IConfiguration _configuration;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(LoginRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View(ModelState);

        //    var result = await
        //}
    }
}
