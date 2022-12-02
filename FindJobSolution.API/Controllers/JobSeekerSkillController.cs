using FindJobSolution.APItotwoweb.API;
using FindJobSolution.Application.Catalog;
using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.JobSeekerSkill;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerSkillController : ControllerBase
    {
        private readonly IJobSeekerSkillService _jobSeekerSkillService;

        public JobSeekerSkillController(IJobSeekerSkillService jobSeekerSkillService)
        {
            this._jobSeekerSkillService = jobSeekerSkillService;
        }

        [HttpGet("Jobseekerid={JobSeekerId}/SkillId={SkillId}")]
        public async Task<IActionResult> GetById(int JobSeekerId, int SkillId)
        {
            var jobSeekerSkill = await _jobSeekerSkillService.GetbyId(JobSeekerId,SkillId);
            if (jobSeekerSkill == null)
                return BadRequest("Cannot find JobSeekerSkill");
            return Ok(jobSeekerSkill);
        }

        [HttpPut("Update/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] JobSeekerSkillUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _jobSeekerSkillService.Update(id, request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobSeekerSkill = await _jobSeekerSkillService.GetAll();
            return Ok(jobSeekerSkill);
        }
    }
}
