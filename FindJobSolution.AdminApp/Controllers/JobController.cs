using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.Skills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobAPI _jobAPI;
        private readonly IConfiguration _configuration;

        public JobController(IJobAPI jobAPI, IConfiguration configuration)
        {
            _jobAPI = jobAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetJobPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _jobAPI.GetAllPaging(request);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobAPI.Create(request);
            if (result)
            {
                TempData["result"] = "Create job successfully";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new JobDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobAPI.Delete(request.Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _jobAPI.GetById(id);
            if (result != null)
            {
                var user = result;
                var updateRequest = new JobUpdateRequest()
                {
                    Id = id,
                    JobName = user.JobName,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _jobAPI.Edit(request);
            if (result)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.ToString());
            return View(request);
        }
    }
}