using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    [Authorize]
    public class RecuiterController : Controller
    {
        private readonly IRecuiterAPI _RecuiterAPI;
        private readonly IConfiguration _configuration;

        public RecuiterController(IRecuiterAPI RecuiterAPI, IConfiguration configuration)
        {
            _RecuiterAPI = RecuiterAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetRecuiterPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _RecuiterAPI.GetAllPagingRecuiter(request);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _RecuiterAPI.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new RecuiterDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RecuiterDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _RecuiterAPI.Delete(request.Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }
    }
}