﻿using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyJobController : ControllerBase
    {
        private readonly IApplyJobService _applyjobService;
        public ApplyJobController(IApplyJobService ApplyJobService)
        {
            _applyjobService = ApplyJobService;
        }

        //http://localhost:port/api/Skill/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ApplyJob = await _applyjobService.GetAll();
            return Ok(ApplyJob);
        }

        //http://localhost:port/api/Skill/paging/
        //[HttpGet("paging")]
        //public async Task<IActionResult> GetAllPaging([FromQuery] GetApplyJobPagingRequest request)
        //{
        //    var ApplyJob = await _applyjobService.GetAllPaging(request);
        //    return Ok(ApplyJob);
        //}

        //http://localhost:port/api/Skill/1
        [HttpGet("{JobSeekerId, JobInfomationId}")]
        public async Task<IActionResult> GetById(int JobSeekerId, int JobInfomationId)
        {
            var savejob = await _applyjobService.GetbyId(JobSeekerId, JobInfomationId);
            if (savejob == null)
                return BadRequest("Cannot find SavedJob");
            return Ok(savejob);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ApplyJobCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _applyjobService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] ApplyJobUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _applyjobService.Update(request);
        //    if (result == 0)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}

        [HttpDelete("{JobSeekerId, JobInfomationId}")]
        public async Task<IActionResult> Delete(int JobSeekerId, int JobInfomationId)
        {
            var result = await _applyjobService.Delete(JobSeekerId, JobInfomationId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}