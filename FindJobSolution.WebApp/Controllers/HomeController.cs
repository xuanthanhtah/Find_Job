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
using Microsoft.AspNetCore.Mvc.Rendering;
using FindJobSolution.ViewModels.Catalog.Message;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FindJobSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJobInformationApi _jobInformationApi;
        private readonly ISaveJobAPI _saveJobAPI;
        private readonly IApplyJobAPI _applyJobAPI;
        private readonly IJobAPI _jobAPI;
        //private readonly IMessageAPI _messageAPI;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IJobInformationApi jobInformationApi, IApplyJobAPI applyJobAPI, ISaveJobAPI saveJobAPI, IJobAPI jobAPI)
        {
            _logger = logger;
            _configuration = configuration;
            _jobInformationApi = jobInformationApi;
            _applyJobAPI = applyJobAPI;
            _saveJobAPI = saveJobAPI;
            _jobAPI = jobAPI;
            //_messageAPI = messageAPI;
        }

        //public async Task<IActionResult> createChat(MessageCreateRequest request)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var result = await _messageAPI.Create(userId, request);
        //    if (result == false) return BadRequest("Cannot create message");
        //    return Ok();
        //}

        //public async Task<IActionResult> indexChat()
        //{
        //    var currUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var userName = User.FindFirstValue(ClaimTypes.Name);
        //    ViewBag.currUser = userName;
        //    var message = await _messageAPI.GetbyUserId(currUser);
        //    if (message == null) return BadRequest("Cannot find message");
        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexRecuiter()
        {
            return View();
        }

        public async Task<IActionResult> JobList(string keyWord, int? JobId, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetJobInformationPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize,
                JobId = JobId,
            };

            var data = await _jobInformationApi.GetAllPaging(request);

            var Job = await _jobAPI.GetAll();
            ViewBag.Job = Job.Select(x => new SelectListItem()
            {
                Text = x.JobName,
                Value = x.JobId.ToString(),
            });

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
            if(username == null)
            {
                return RedirectToAction("login", "UserJobSeeker");
            }
            var saveJob = new SaveJobCreateRequestNew()
            {
                TimeSave = DateTime.Now,
                UserIdentityName = username,
            };
            var result = await _saveJobAPI.Create(id, saveJob);

            if (result)
            {
                TempData["result"] = "Lưu công việc thành công";
                return RedirectToAction("JobDetail", new
                {
                    id = id,
                });
            }
            else
            {
                TempData["result"] = "Bạn đã lưu công việc này rồi";
                return RedirectToAction("JobDetail", new
                {
                    id = id,
                });
            }

            return RedirectToAction("JobDetail", new
            {
                id = id
            });
        }

        public async Task<IActionResult> ApplyJob(int id)
        {
            var username = User.Identity.Name;
            if (username == null)
            {
                return RedirectToAction("Login", "UserJobSeeker");
            }

            var applyjob = new ApplyJobCreateRequestNew()
            {
                TimeApply = DateTime.Now,
                UserIdentityName = username,
            };

            var result = await _applyJobAPI.Create(id, applyjob);

            if (result)
            {
                TempData["result"] = "Ứng tuyển thành công";
                return RedirectToAction("JobDetail", new
                {
                    id = id,
                });
            }
            else
            {
                TempData["result"] = "Bạn đã ứng tuyển công việc này rồi";
                return RedirectToAction("JobDetail", new
                {
                    id = id,
                });
            }
        }
    }
}