using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.WebApp.Controllers
{
    [Authorize]
    public class JobInformationController : Controller
    {
        private readonly IJobInformationApi _jobInformationApi;
        private readonly IConfiguration _configuration;

        public JobInformationController(IJobInformationApi jobInformationApi, IConfiguration configuration)
        {
            _jobInformationApi = jobInformationApi;
            _configuration = configuration;
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

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(UserRegisterRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var result = await _userAPI.Register(request);
        //    if (result)
        //    {
        //        TempData["result"] = "Create user successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}
    }
}