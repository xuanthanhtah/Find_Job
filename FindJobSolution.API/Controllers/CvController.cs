using FindJobSolution.Application.Catalog.Cvs;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvService _ICvService;
        public CvController(ICvService ICvService)
        {
            _ICvService = ICvService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile files)
        {
            return Ok();
        }
    }
}
