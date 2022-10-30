using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IJobSeekerService _IJobSeekerService;
        public JobSeekerController(IJobSeekerService IJobSeekerService)
        {
            _IJobSeekerService = IJobSeekerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobSeeker = await _IJobSeekerService.GetAll();
            return Ok(jobSeeker);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetJobSeekerPagingRequest request)
        {
            var jobSeeker = await _IJobSeekerService.GetAllPaging(request);
            return Ok(jobSeeker);
        }

        [HttpGet("{JobSeekerId}")]
        public async Task<IActionResult> GetById(int JobSeekerId)
        {
            var jobSeeker = await _IJobSeekerService.GetbyId(JobSeekerId);
            if (jobSeeker == null)
                return BadRequest("Cannot find jobSeeker");
            return Ok(jobSeeker);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] JobSeekerUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _IJobSeekerService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int JobSeekerId)
        {
            var result = await _IJobSeekerService.Delete(JobSeekerId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
