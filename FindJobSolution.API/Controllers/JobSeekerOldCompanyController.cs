using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerOldCompanyController : ControllerBase
    {
        private readonly IJobSeekerOldCompanyService _jobSeekerOldCompanyService;

        public JobSeekerOldCompanyController(IJobSeekerOldCompanyService jobSeekerOldCompanyService)
        {
            this._jobSeekerOldCompanyService = jobSeekerOldCompanyService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var jobSeekerOldCompany = await _jobSeekerOldCompanyService.GetAll();
            if (jobSeekerOldCompany == null) return BadRequest();
            return Ok(jobSeekerOldCompany);
        }

        [HttpGet("GetById/{JobSeekerOldCompanyId}")]
        public async Task<IActionResult> GetById(int JobSeekerOldCompanyId)
        {
            var jobSeekerOldCompany = await _jobSeekerOldCompanyService.GetbyId(JobSeekerOldCompanyId);
            if (jobSeekerOldCompany == null)
                return BadRequest("Cannot find jobInformation");
            return Ok(jobSeekerOldCompany);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] JobSeekerOldCompanyCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobSeekerOldCompanyService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }

            var jobSeekerOldCompany = await _jobSeekerOldCompanyService.GetbyId(result);

            return CreatedAtAction(nameof(GetById), new { id = result }, jobSeekerOldCompany);
        }

        [HttpPut("Update/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] JobSeekerOldCompanyUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobSeekerOldCompanyService.Update(id, request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete/{JobSeekerOldCompanyId}")]
        public async Task<IActionResult> Delete(int JobSeekerOldCompanyId)
        {
            var result = await _jobSeekerOldCompanyService.Delete(JobSeekerOldCompanyId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] JobSeekerOldCompanyViewmodelPagingRequest request)
        {
            var jobSeekerOldCompanies = await _jobSeekerOldCompanyService.GetAllPaging(request);
            return Ok(jobSeekerOldCompanies);
        }

    }
}
