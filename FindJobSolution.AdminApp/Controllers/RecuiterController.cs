using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
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
    }
}