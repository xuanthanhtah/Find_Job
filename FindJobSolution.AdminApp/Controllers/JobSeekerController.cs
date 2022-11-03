using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerAPI _jobSeekerAPI;
        private readonly IConfiguration _configuration;

        public JobSeekerController(IJobSeekerAPI jobSeekerAPI, IConfiguration configuration)
        {
            _jobSeekerAPI = jobSeekerAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
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
    }
}