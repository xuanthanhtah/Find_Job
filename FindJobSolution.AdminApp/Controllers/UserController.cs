using FindJobSolution.AdminApp.Service;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FindJobSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAPI _userAPI;
        private readonly IConfiguration _configuration;

        public UserController(IUserAPI userAPI, IConfiguration configuration)
        {
            _userAPI = userAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetUserPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userAPI.GetUsersPaging(request);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userAPI.Register(request);
            if (result)
            {
                TempData["result"] = "Create user successfully";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("index", "Login");
        }
    }
}