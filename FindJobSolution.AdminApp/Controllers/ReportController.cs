using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.Report;
using FindJobSolution.ViewModels.Catalog.Skills;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportAPI _reportAPI;
        private readonly IConfiguration _configuration;

        public ReportController(IReportAPI reportAPI, IConfiguration configuration)
        {
            _reportAPI = reportAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetReportPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _reportAPI.GetAllPaging(request);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReportDeleteVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _reportAPI.Delete(request.id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }
    }
}