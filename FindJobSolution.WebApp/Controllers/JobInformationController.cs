using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindJobSolution.WebApp.Controllers
{
    [Authorize]
    public class JobInformationController : Controller
    {
        private readonly IJobInformationApi _jobInformationApi;
        private readonly IConfiguration _configuration;
        private readonly IJobAPI _jobAPI;

        public JobInformationController(IJobInformationApi jobInformationApi, IConfiguration configuration, IJobAPI jobAPI)
        {
            _jobInformationApi = jobInformationApi;
            _configuration = configuration;
            _jobAPI = jobAPI;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetJobInformationPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _jobInformationApi.GetAllPaging(request);

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
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
    }
}