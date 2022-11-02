﻿using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveJobController : ControllerBase
    {
        private readonly ISaveJobService _savejobService;
        public SaveJobController(ISaveJobService SaveJobService)
        {
            _savejobService = SaveJobService;
        }

        //http://localhost:port/api/Skill/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SaveJob = await _savejobService.GetAll();
            return Ok(SaveJob);
        }

        //http://localhost:port/api/Skill/paging/
        //[HttpGet("paging")]
        //public async Task<IActionResult> GetAllPaging([FromQuery] GetSaveJobPagingRequest request)
        //{
        //    var SaveJob = await _savejobService.GetAllPaging(request);
        //    return Ok(SaveJob);
        //}

        //http://localhost:port/api/Skill/1
        [HttpGet("{JobSeekerId, JobInfomationId}")]
        public async Task<IActionResult> GetById(int JobSeekerId, int JobInfomationId)
        {
            var savejob = await _savejobService.GetbyId(JobSeekerId, JobInfomationId);
            if (savejob == null)
                return BadRequest("Cannot find SavedJob");
            return Ok(savejob);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SaveJobCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _savejobService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] SkillUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _savejobService.Update(request);
        //    if (result == 0)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}

        [HttpDelete("{JobSeekerId, JobInfomationId}")]
        public async Task<IActionResult> Delete(int JobSeekerId, int JobInfomationId)
        {
            var result = await _savejobService.Delete(JobSeekerId, JobInfomationId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}