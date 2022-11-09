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

namespace FindJobSolution.WebApp.Controllers
{
    public class UserJobSeekerController : Controller
    {
        private readonly IUserAPI _userAPI;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJobSeekerAPI _jobSeekerAPI;

        public UserJobSeekerController(IUserAPI userAPI, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IJobSeekerAPI jobSeekerAPI)
        {
            _userAPI = userAPI;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _jobSeekerAPI = jobSeekerAPI;
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

        public async Task<IActionResult> UserProfileAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = await _jobSeekerAPI.GetByUserId(userId);
            return View(data);
        }
    }
}