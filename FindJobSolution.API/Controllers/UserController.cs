using FindJobSolution.Application.System;
using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.System.Role;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _UserService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _UserService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _UserService.Register(request);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //http://localhost:5000/api/user/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsersPaging([FromQuery] GetUserPagingRequest request)
        {
            var users = await _UserService.GetUsersPaging(request);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _UserService.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _UserService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("{id}/roles")]
        [AllowAnonymous]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _UserService.RoleAssign(id, request);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}