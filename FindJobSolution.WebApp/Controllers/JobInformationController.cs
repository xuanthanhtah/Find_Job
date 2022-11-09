using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FindJobSolution.WebApp.Controllers
{
    [Authorize]
    public class JobInformationController : Controller
    {
        private readonly IJobInformationApi _jobInformationApi;
        private readonly IConfiguration _configuration;
        private readonly IJobAPI _jobAPI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobInformationController(IJobInformationApi jobInformationApi, IConfiguration configuration, IJobAPI jobAPI, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _jobInformationApi = jobInformationApi;
            _configuration = configuration;
            _jobAPI = jobAPI;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
        {
            //get recuiterId by userId in cookie
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var recuiterId = await _jobInformationApi.GetRecuiterIdByUserId(userId);

            var request = new GetJobInformationPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var result = await _jobInformationApi.GetPagingByRecuiterId(recuiterId.RecruiterId, request);
            if (result == null)
            {
                TempData["result"] = "Bạn chưa tạo công việc nào cả, tạo ngay thôi";
                return RedirectToAction("create");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new JobInformationDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobInformationDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobInformationApi.Delete(request.Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobInformationCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobInformationApi.Create(request);
            if (result)
            {
                TempData["result"] = "Create job successfully";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _jobInformationApi.GetById(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _jobInformationApi.GetById(id);
            if (result != null)
            {
                var user = result;
                var updateRequest = new JobInformationUpdateRequest()
                {
                    //JobInformationId = user.JobInformationId,
                    JobTitle = user.JobTitle,
                    JobLevel = user.JobLevel,
                    JobType = user.JobType,
                    Description = user.Description,
                    WorkingLocation = user.WorkingLocation,
                    MinSalary = user.MinSalary,
                    MaxSalary = user.MaxSalary,
                    JobId = user.JobId,
                    Status = user.Status,
                    JobInformationTimeStart = user.JobInformationTimeStart,
                    JobInformationTimeEnd = user.JobInformationTimeEnd
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobInformationUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _jobInformationApi.Edit(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật tin tuyển dụng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.ToString());
            return View(request);
        }
    }
}