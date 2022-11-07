using FindJobSolution.APItotwoweb.API;
using FindJobSolution.Data.EF;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobSolution.WebApp.Controllers
{
    public class UserRecuiterController : Controller
    {
        private readonly IUserAPI _userAPI;
        private readonly IConfiguration _configuration;
        private readonly IRecuiterAPI _recuiterAPI;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private Guid idUser;

        public UserRecuiterController(IUserAPI userAPI, IConfiguration configuration, IRecuiterAPI recuiterAPI, IHttpContextAccessor httpContextAccessor)
        {
            _userAPI = userAPI;
            _configuration = configuration;
            _recuiterAPI = recuiterAPI;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = await _recuiterAPI.GetByUserId(userId);
            return View(data);
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
            if (token == null)
            {
                ModelState.AddModelError("", token);
                return View();
            }
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
            return RedirectToAction("IndexRecuiter", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("IndexRecuiter", "Home");
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

        //public async Task<IActionResult> UserProfile(Guid id)
        //{
        //    var result = await _recuiterAPI.GetByUserId(id);
        //    return View(result);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRecuiterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _recuiterAPI.Register(request);
            if (result)
            {
                TempData["result"] = "Create recuiter successfully";
                return RedirectToAction("Login");
            }
            return View(request);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var result = await _recuiterAPI.GetByUserId(id);
        //    if (result != null)
        //    {
        //        var user = result;
        //        var updateRequest = new RecruiterUpdateRequest()
        //        {
        //            Id = id,
        //            RecruiterId = user.RecruiterId,
        //            CompanyName = user.CompanyName,
        //            Address = user.Address,
        //            CompanyIntroduction = user.CompanyIntroduction,
        //        };
        //        return View(updateRequest);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(RecruiterUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var result = await _recuiterAPI.Edit(request);
        //    if (result)
        //    {
        //        TempData["result"] = "Cập nhật người dùng thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", result.ToString());
        //    return View(request);
        //}
    }
}