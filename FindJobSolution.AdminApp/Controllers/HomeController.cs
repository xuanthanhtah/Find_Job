using FindJobSolution.AdminApp.Models;
using FindJobSolution.APItotwoweb.API;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindJobSolution.AdminApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportAPI _reportAPI;
        private readonly IAdminAPI _adminAPI;

        public HomeController(ILogger<HomeController> logger, IReportAPI reportAPI, IAdminAPI adminAPI)
        {
            _adminAPI = adminAPI;
            _logger = logger;
            _reportAPI = reportAPI;
        }

        public async Task<IActionResult> Index()
        {
            var getData = await _adminAPI.GetReportData();
            var user = User.Identity.Name;
            return View(getData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}