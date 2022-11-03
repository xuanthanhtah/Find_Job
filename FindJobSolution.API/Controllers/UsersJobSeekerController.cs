using FindJobSolution.Application.System.UsersJobSeeker;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersJobSeekerController : ControllerBase
    {
        private readonly IUserJobSeekerService _UserJobSeekerService;

        public UsersJobSeekerController(IUserJobSeekerService userJobSeekerService)
        {
            _UserJobSeekerService = userJobSeekerService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _UserJobSeekerService.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _UserJobSeekerService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }
    }
}