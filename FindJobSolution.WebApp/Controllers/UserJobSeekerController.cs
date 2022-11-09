using Microsoft.AspNetCore.Mvc;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using FindJobSolution.Data.Entities;
using FindJobSolution.Data.EF;

namespace FindJobSolution.WebApp.Controllers
{
    public class UserJobSeekerController : Controller
    {
        private readonly IUserAPI _userAPI;
        private readonly IConfiguration _configuration;
        private readonly IJobSeekerAPI _jobseekerAPI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserJobSeekerController(IUserAPI userAPI, IConfiguration configuration, IJobSeekerAPI jobseekerAPI, IHttpContextAccessor httpContextAccessor)
        {
            _userAPI = userAPI;
            _configuration = configuration;
            _jobseekerAPI = jobseekerAPI;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                return View(new UserLoginRequest());
            }

            var token = await _userAPI.Authencate(request);
            //if (token == null)
            //{
            //    ModelState.AddModelError("", token);
            //    return View();
            //}
            var userPrincipal = this.ValidateToken(token);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = false
            };
            HttpContext.Session.SetString("Token", token);
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];

            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobseekerAPI.Register(request);
            if (result)
            {
                TempData["result"] = "Create recuiter successfully";
                return RedirectToAction("Login");
            }
            return View(request);
        }

        public async Task<IActionResult> UserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = await _jobseekerAPI.GetByUserId(userId);
            return View(data);

        }
    }
}