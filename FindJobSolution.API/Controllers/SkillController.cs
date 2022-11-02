using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Skills;
using Microsoft.AspNetCore.Mvc;

namespace FindSkillSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService SkillService)
        {
            _skillService = SkillService;
        }

        //http://localhost:port/api/Skill/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Skill = await _skillService.GetAll();
            return Ok(Skill);
        }

        //http://localhost:port/api/Skill/paging/
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetSkillPagingRequest request)
        {
            var Skill = await _skillService.GetAllPaging(request);
            return Ok(Skill);
        }

        //http://localhost:port/api/Skill/1
        [HttpGet("{SkillId}")]
        public async Task<IActionResult> GetById(int skillId)
        {
            var skill = await _skillService.GetbyId(skillId);
            if (skill == null)
                return BadRequest("Cannot find Skill");
            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _skillService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }

            var Skill = await _skillService.GetbyId(result);

            return CreatedAtAction(nameof(GetById), new { id = result }, Skill);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SkillUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _skillService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{SkillId}")]
        public async Task<IActionResult> Delete(int SkillId)
        {
            var result = await _skillService.Delete(SkillId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}