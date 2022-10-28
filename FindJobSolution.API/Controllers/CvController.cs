using FindJobSolution.Application.Catalog.Cvs;
using FindJobSolution.ViewModels.Catalog.Cvs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
