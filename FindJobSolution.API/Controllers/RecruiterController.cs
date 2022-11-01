using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Catalog.RecuiterImages;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;

        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recruiter = await _recruiterService.GetAll();
            return Ok(recruiter);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetRecuiterPagingRequest request)
        {
            var recruiter = await _recruiterService.GetAllPaging(request);
            return Ok(recruiter);
        }

        [HttpGet("{RecruiterId}")]
        public async Task<IActionResult> GetById(int RecruiterId)
        {
            var recruiter = await _recruiterService.GetById(RecruiterId);
            if (recruiter == null)
                return BadRequest("Cannot find recruiter");
            return Ok(recruiter);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecruiterUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _recruiterService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            var recruiter = await _recruiterService.GetById(result);
            return CreatedAtAction(nameof(GetById), new { id = result }, recruiter);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int RecruiterId)
        {
            var result = await _recruiterService.Delete(RecruiterId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPost("image/{RecruiterId}")]
        public async Task<IActionResult> AddImage(int RecruiterId, [FromBody] ImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _recruiterService.AddImage(RecruiterId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _recruiterService.GetImageById(result);
            return CreatedAtAction(nameof(GetImageById), new { id = result }, image);
        }

        [HttpPut("image/{ImageId}")]
        public async Task<IActionResult> UpdateImage(int ImageId, [FromBody] ImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _recruiterService.UpdateImage(ImageId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _recruiterService.GetImageById(ImageId);
            return CreatedAtAction(nameof(GetImageById), new { id = ImageId }, image);
        }

        [HttpDelete("image/{ImageId}")]
        public async Task<IActionResult> DeleteImage(int ImageId)
        {
            var result = await _recruiterService.RemoveImage(ImageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{Recuiterid}/image")]
        public async Task<IActionResult> GetImageByRecuiterid(int Recuiterid)
        {
            var image = await _recruiterService.GetImageByRecuiterid(Recuiterid);
            if (image == null)
                return BadRequest("Cannot find image");
            return Ok(image);
        }

        [HttpGet("image/{ImageId}")]
        public async Task<IActionResult> GetImageById(int ImageId)
        {
            var image = await _recruiterService.GetImageById(ImageId);
            if (image == null)
                return BadRequest("Cannot find image");
            return Ok(image);
        }
    }
}