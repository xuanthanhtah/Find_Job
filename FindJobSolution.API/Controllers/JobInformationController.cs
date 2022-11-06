using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInformationController : ControllerBase
    {
        private readonly IJobInformationService _jobInformationService;

        public JobInformationController(IJobInformationService jobInformationService)
        {
            _jobInformationService = jobInformationService;
        }

        //http://localhost:port/api/jobInformation
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var jobInformation = await _jobInformationService.GetAll();
            if (jobInformation == null) return BadRequest();
            return Ok(jobInformation);
        }

        //http://localhost:port/api/jobInformation/{int:id}
        [HttpGet("GetById/{JobInformationId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int JobInformationId)
        {
            var jobInformation = await _jobInformationService.GetbyId(JobInformationId);
            if (jobInformation == null)
                return BadRequest("Cannot find jobInformation");
            return Ok(jobInformation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobInformationCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobInformationService.Create(request);
            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] JobInformationUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobInformationService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete/{JobInformationId}")]
        public async Task<IActionResult> Delete(int JobInformationId)
        {
            var result = await _jobInformationService.Delete(JobInformationId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetJobInformationPagingRequest request)
        {
            var jobSeeker = await _jobInformationService.GetAllPaging(request);
            return Ok(jobSeeker);
        }

        [HttpGet("paging/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetbyRecuiterId([FromQuery] GetJobInformationPagingRequest request, int id)
        {
            var jobSeeker = await _jobInformationService.GetbyRecuiterId(id, request);
            return Ok(jobSeeker);
        }
    }
}