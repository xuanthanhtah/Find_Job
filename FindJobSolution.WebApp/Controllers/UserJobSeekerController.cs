using Microsoft.AspNetCore.Mvc;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;

namespace FindJobSolution.WebApp.Controllers
{
    public class UserJobSeekerController : Controller
    {
        private readonly IUserAPI _userAPI;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJobSeekerAPI _jobSeekerAPI;
        private readonly IApplyJobAPI _applyJobAPI;
        private readonly ISaveJobAPI _saveJobAPI;
        private readonly IJobSeekerOldCompanyAPI _jobSeekerOldCompanyAPI;

        public UserJobSeekerController(IUserAPI userAPI, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IJobSeekerAPI jobSeekerAPI, IApplyJobAPI applyJobAPI, ISaveJobAPI saveJobAPI, IJobSeekerOldCompanyAPI jobSeekerOldCompanyAPI)
        {
            _userAPI = userAPI;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _jobSeekerAPI = jobSeekerAPI;
            _applyJobAPI = applyJobAPI;
            _saveJobAPI = saveJobAPI;
            _jobSeekerOldCompanyAPI = jobSeekerOldCompanyAPI;
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

            IEnumerable<Claim> claims = userPrincipal.Claims;

            var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            if (role.Contains("JobSeeker"))
            {
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
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobSeekerAPI.Register(request);
            if (result)
            {
                TempData["result"] = "Create jobseeker successfully";
                return RedirectToAction("Login", "UserJobSeeker");
            }
            return View(request);
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

        public async Task<IActionResult> UserProfile()
        {
            if(User.Identity.Name == null)
                return RedirectToAction("index", "Home");

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var jobseerker = await _jobSeekerAPI.GetByUserId(userId);
            var jobName = await _jobSeekerAPI.GetJobIdByjobSeekerId(jobseerker.jobseekerId);
            ViewBag.JobNamed = jobName.JobName;

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("index", "Home");
           
            var data = await _jobSeekerAPI.GetByUserId(userId);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfileEdit(int id)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToAction("index", "Home");

            var result = await _jobSeekerAPI.GetById(id);
            if (result != null)
            {
                var user = result;
                var updateRequest = new JobSeekerUpdateRequest()
                {
                    DesiredSalary = user.DesiredSalary,
                    Dob = user.Dob,
                    Gender = user.Gender,
                    Name = user.Name ,
                    National = user.National ,
                    
                    Address = user.Address ,
                    PhoneNumber = user.PhoneNumber ,
                    Email = user.Email,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UserProfileEdit(int id, [FromForm] JobSeekerUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var data = await _jobSeekerAPI.Edit(id, request);
            if (data)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("UserProfile", "Home");
            }

            ModelState.AddModelError("", data.ToString());
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> UserOldCompanyEdit(int id)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToAction("index", "Home");          
            var result = await _jobSeekerOldCompanyAPI.GetById(id);

            if (result != null)
            {
                var user = result;
                var updateRequest = new JobSeekerOldCompanyUpdateRequest()
                {
                    CompanyName = user.CompanyName,
                    JobTitle = user.JobTitle,
                    WorkExperience = user.WorkExperience,
                    WorkingTime = user.WorkingTime,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UserOldCompanyEdit(int id, [FromForm] JobSeekerOldCompanyUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var data = await _jobSeekerOldCompanyAPI.Edit(id, request);
            if (data)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("UserProfile", "Home");
            }

            ModelState.AddModelError("", data.ToString());
            return View(request);
        }

        [HttpGet]

        public async Task<IActionResult> UserJob()
        {
            var id = User.Identity.Name;
            var all = await _applyJobAPI.GetAll(id);
            return View(all);
        }


        public async Task<IActionResult> CancelSaveJob(int jobinfoid, int jobseekerid)
        {
            SaveJobDeleteRequest request = new SaveJobDeleteRequest()
            {
                JobInformationId = jobinfoid,
                JobSeekerId = jobseekerid,
            };

            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _saveJobAPI.Delete(request.JobSeekerId, request.JobInformationId);
            if (result)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("UserJob", "UserJobSeeker");
        }

        public async Task<IActionResult> CancelApplyJob(int jobinfoid, int jobseekerid)
        {
            ApplyJobDeleteRequest request = new ApplyJobDeleteRequest()
            {
                JobInformationId = jobinfoid,
                JobSeekerId = jobseekerid,
            };

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _applyJobAPI.Delete(request.JobSeekerId, request.JobInformationId);
            if (result)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("UserJob", "UserJobSeeker");
        }
    }
}