using FindJobSolution.Application.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReportData()
        {
            var reportData = await _adminService.GetReportData();
            return Ok(reportData);
        }
    }
}