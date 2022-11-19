using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using FindJobSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FindJobSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJobInformationApi _jobInformationApi;
        private readonly ISaveJobAPI _saveJobAPI;   
        private readonly IApplyJobAPI _applyJobAPI;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IJobInformationApi jobInformationApi, IApplyJobAPI applyJobAPI, ISaveJobAPI saveJobAPI)
        {
            _logger = logger;
            _configuration = configuration;
            _jobInformationApi = jobInformationApi;
            _applyJobAPI = applyJobAPI;
            _saveJobAPI = saveJobAPI;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexRecuiter()
        {
            return View();
        }

        public async Task<IActionResult> JobList(string keyWord, int pageIndex = 1, int pageSize = 5)
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

        public async Task<IActionResult> JobDetail(int id)
        {
            var result = await _jobInformationApi.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> SaveJob(int id)
        {
            var username = User.Identity.Name;
            var saveJob = new SaveJobCreateRequestNew()
            {
                TimeSave = DateTime.Now,
                UserIdentityName = username,
            };
            await _saveJobAPI.Create(id, saveJob);
            return RedirectToAction("JobDetail", new
            {
                id = id
            });
        }


        public async Task<IActionResult> ApplyJob(int id)
        {
            var username = User.Identity.Name;
            var applyjob = new ApplyJobCreateRequestNew()
            {
                TimeApply = DateTime.Now,
                UserIdentityName = username,
            };

            await _applyJobAPI.Create(id, applyjob);
            return RedirectToAction("JobDetail", new
            {
                id = id,
            });


        }
    }
}// lafm sao cho cai view jobdetail no truyen cai ApplyJobCreateRequestNew thi moi lay dc data, tại vì nó get data từ JobInformationViewModel  khi m lấy data từ đó vô cái applly job nó bị lỗi format, hiểu k, tại có nhiều trường k khớp
// mà 