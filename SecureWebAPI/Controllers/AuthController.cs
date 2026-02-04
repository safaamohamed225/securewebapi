using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureWebAPI.Models;
using SecureWebAPI.Services;

namespace SecureWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _authServices.RegisterAsync(model);
            if (!result.IsAuthantecated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
