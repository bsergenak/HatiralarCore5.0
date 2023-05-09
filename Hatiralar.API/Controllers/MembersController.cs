using Hatiralar.Businees.Abstract;
using Hatiralar.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hatiralar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public MembersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            string token = await _authService.SignIn(loginDto);
            if (token == "")
                return NotFound("Kullanıcı adı veya parola hatalı");
            else
                return Ok(token);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            IdentityResult result = await _authService.UserRegister(registerDto);
            if (result.Succeeded)
                return Ok(200);
            else
                return NotFound(result.Errors);
        }

        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        { 

        }
    }
}
