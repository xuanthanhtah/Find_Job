using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Cvs;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetJobSeekerPagingRequest request)
        {
            var jobSeeker = await _IJobSeekerService.GetAllPaging(request);
            return Ok(jobSeeker);
        }

        [HttpGet("{JobSeekerId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int JobSeekerId)
        {
            var jobSeeker = await _IJobSeekerService.GetbyId(JobSeekerId);
            if (jobSeeker == null)
                return BadRequest("Cannot find jobSeeker");
            return Ok(jobSeeker);
        }

        [HttpGet("user/{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(Guid Id)
        {
            var jobseeker = await _IJobSeekerService.GetByUserId(Id);
            if (jobseeker == null)
                return BadRequest("Cannot find jobseeker");
            return Ok(jobseeker);
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

        [HttpDelete("{JobSeekerId}")]
        public async Task<IActionResult> Delete(int JobSeekerId)
        {
            var result = await _IJobSeekerService.Delete(JobSeekerId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok("1");
        }

        [HttpPost("cv/{JobSeekerId}")]
        public async Task<IActionResult> AddCv(int JobSeekerId, [FromForm] CvCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cvid = await _IJobSeekerService.AddCv(JobSeekerId, request);
            if (cvid == 0)
            {
                return BadRequest();
            }
            var cv = await _IJobSeekerService.GetCvById(cvid);
            return CreatedAtAction(nameof(GetCvById), new { id = cvid }, cv);
        }

        [HttpGet("cv/{CvId}")]
        public async Task<IActionResult> GetCvById(int CvId)
        {
            var cv = await _IJobSeekerService.GetCvById(CvId);
            if (cv == null)
                return BadRequest("Cannot find cv");
            return Ok(cv);
        }

        [HttpPut("cv/{CvId}")]
        public async Task<IActionResult> UpdateCv(int CvId, [FromForm] CvUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _IJobSeekerService.UpdateCv(CvId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("cv/{CvId}")]
        public async Task<IActionResult> DeleteCv(int CvId)
        {
            var result = await _IJobSeekerService.RemoveCv(CvId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("cv/{JobSeekerId}")]
        public async Task<IActionResult> GetCvByJobSeekerId(int JobSeekerId)
        {
            var cv = await _IJobSeekerService.GetCvByJobSeekerId(JobSeekerId);
            if (cv == null)
                return BadRequest("Cannot find cv");
            return Ok(cv);
        }
    }
}