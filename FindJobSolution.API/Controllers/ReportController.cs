using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReport(ReportCreateRequest request)
        {
            var result = await _reportService.Create(request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetReportPagingRequest request)
        {
            var job = await _reportService.GetAllPaging(request);
            return Ok(job);
        }

        [HttpDelete("{ReportId}")]
        public async Task<IActionResult> Delete(int ReportId)
        {
            var result = await _reportService.Delete(ReportId);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}