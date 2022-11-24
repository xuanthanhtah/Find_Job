using FindJobSolution.Application.Catalog;
using FindJobSolution.ViewModels.Catalog.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetbyUserId(Guid userId)
        {
            var message = await _messageService.GetbyUserId(userId);
            if (message == null) return BadRequest("Cannot find message");
            return Ok(message);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(Guid userId, [FromBody] MessageCreateRequest request)
        {
            var result = await _messageService.Create(userId, request);
            if (result == false) return BadRequest("Cannot create message");
            return Ok();
        }
    }
}