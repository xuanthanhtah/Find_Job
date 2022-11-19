using FindJobSolution.APItotwoweb.API;
using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using System.Security.Claims;

namespace FindJobSolution.WebApp.Controllers
{
    [Authorize]
    public class JobInformationController : Controller
    {
        private readonly IJobInformationApi _jobInformationApi;
        private readonly IConfiguration _configuration;
        private readonly IJobAPI _jobAPI;
        private readonly IApplyJobAPI _applyJobAPI;
        private readonly IJobSeekerAPI _jobSeekerAPI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobInformationController(IJobInformationApi jobInformationApi, IConfiguration configuration, IJobAPI jobAPI, IHttpContextAccessor httpContextAccessor, IApplyJobAPI applyJobAPI, IJobSeekerAPI jobSeekerAPI)
        {
            _httpContextAccessor = httpContextAccessor;
            _jobInformationApi = jobInformationApi;
            _configuration = configuration;
            _jobAPI = jobAPI;
            _applyJobAPI = applyJobAPI;
            _jobSeekerAPI = jobSeekerAPI;
            _jobSeekerAPI = jobSeekerAPI;
        }

        public async Task<IActionResult> Index()
        {
            //get recuiterId by userId in cookie
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var recuiterId = await _jobInformationApi.GetRecuiterIdByUserId(userId);

            var result = await _jobInformationApi.GetPagingByRecuiterIdPage(recuiterId.RecruiterId);
            if (result == null)
            {
                return View("create");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var jobName = await _jobAPI.GetAll();
            ViewBag.JobName = jobName.Select(x => new SelectListItem()
            {
                Text = x.JobName,
                Value = x.JobId.ToString()
            }).ToList();
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
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var recuiterId = await _jobInformationApi.GetRecuiterIdByUserId(userId);
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobInformationApi.Create(recuiterId.RecruiterId, request);
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
            var jobName = await _jobAPI.GetAll();
            ViewBag.JobName = jobName.Select(x => new SelectListItem()
            {
                Text = x.JobName,
                Value = x.JobId.ToString()
            }).ToList();
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

        [HttpGet]
        public async Task<IActionResult> JobSeekerApply(int id)
        {
            var result = await _applyJobAPI.GetByJobInforId(id);

            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditStatus(ApplyJobViewModel request)
        {
            var result = await _applyJobAPI.GetById(request.JobSeekerId, request.JobInformationId);
            if (result != null)
            {
                var user = result;
                var updateRequest = new ApplyJobUpdateRequest()
                {
                    Status = user.Status
                };

                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus(ApplyJobUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _applyJobAPI.Edit(request);
            if (result)
            {
                TempData["result"] = "Cập nhật trạng thái thành công";
                return RedirectToAction("JobSeekerApply");
            }

            ModelState.AddModelError("", result.ToString());
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> ProfileJobSeeker(int id)
        {
            var data = await _jobSeekerAPI.GetById(id);
            return View(data);
        }
    }
}