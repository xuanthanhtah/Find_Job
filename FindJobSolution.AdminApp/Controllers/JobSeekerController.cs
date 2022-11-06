using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    [Authorize]
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerAPI _jobSeekerAPI;
        private readonly IConfiguration _configuration;

        public JobSeekerController(IJobSeekerAPI jobSeekerAPI, IConfiguration configuration)
        {
            _jobSeekerAPI = jobSeekerAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetJobSeekerPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _jobSeekerAPI.GetAllPagingJobSeeker(request);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _jobSeekerAPI.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new JobseekerDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobseekerDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _jobSeekerAPI.Delete(request.Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }
    }
}