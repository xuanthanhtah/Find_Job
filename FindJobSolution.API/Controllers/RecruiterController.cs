using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Catalog.RecuiterImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _RecruiterService;

        public RecruiterController(IRecruiterService RecruiterService)
        {
            _RecruiterService = RecruiterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recruiter = await _RecruiterService.GetAll();
            return Ok(recruiter);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetRecuiterPagingRequest request)
        {
            var recruiter = await _RecruiterService.GetAllPaging(request);
            return Ok(recruiter);
        }

        [HttpGet("{RecruiterId}")]
        public async Task<IActionResult> GetById(int RecruiterId)
        {
            var recruiter = await _RecruiterService.GetById(RecruiterId);
            if (recruiter == null)
                return BadRequest("Cannot find recruiter");
            return Ok(recruiter);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] RecruiterUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _RecruiterService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            var recruiter = await _RecruiterService.GetById(result);
            return CreatedAtAction(nameof(GetById), new { id = result }, recruiter);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int RecruiterId)
        {
            var result = await _RecruiterService.Delete(RecruiterId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPost("image/{RecruiterId}")]
        public async Task<IActionResult> AddImage(int RecruiterId, [FromForm] ImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _RecruiterService.AddImage(RecruiterId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _RecruiterService.GetImageById(result);
            return CreatedAtAction(nameof(GetImageById), new { id = result }, image);
        }

        [HttpPut("image/{ImageId}")]
        public async Task<IActionResult> UpdateImage(int ImageId, [FromForm] ImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _RecruiterService.UpdateImage(ImageId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _RecruiterService.GetImageById(ImageId);
            return CreatedAtAction(nameof(GetImageById), new { id = ImageId }, image);
        }

        [HttpDelete("image/{ImageId}")]
        public async Task<IActionResult> DeleteImage(int ImageId)
        {
            var result = await _RecruiterService.RemoveImage(ImageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("image/{ImageId}")]
        public async Task<IActionResult> GetImageByRecuiterid(int ImageId)
        {
            var image = await _RecruiterService.GetImageByRecuiterid(ImageId);
            if (image == null)
                return BadRequest("Cannot find image");
            return Ok(image);
        }

        [HttpGet("image/{ImageId}")]
        public async Task<IActionResult> GetImageById(int ImageId)
        {
            var image = await _RecruiterService.GetImageById(ImageId);
            if (image == null)
                return BadRequest("Cannot find image");
            return Ok(image);
        }
    }
}