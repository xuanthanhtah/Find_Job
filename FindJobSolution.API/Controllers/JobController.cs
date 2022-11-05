using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Jobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //http://localhost:port jo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var job = await _jobService.GetAll();
            return Ok(job);
        }

        //http://localhost:port/api/job/paging/
        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetJobPagingRequest request)
        {
            var job = await _jobService.GetAllPaging(request);
            return Ok(job);
        }

        //http://localhost:port/api/job/1
        [HttpGet("{JobId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int JobId)
        {
            var job = await _jobService.GetbyId(JobId);
            if (job == null)
                return BadRequest("Cannot find job");
            return Ok(job);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] JobCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobService.Create(request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] JobUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobService.Update(request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{JobId}")]
        public async Task<IActionResult> Delete(int JobId)
        {
            var result = await _jobService.Delete(JobId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}