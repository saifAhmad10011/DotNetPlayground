using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthTestController : ControllerBase
    {
        private readonly Services.IAuthTestService _service;

        public AuthTestController(Services.IAuthTestService service)
        {
            _service = service;
        }

        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(_service.GetPublicMessage());
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok(_service.GetProtectedMessage());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok(_service.GetAdminMessage());
        }
    }
}
