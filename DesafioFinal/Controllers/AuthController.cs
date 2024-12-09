using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using DesafioFinal.Data;
using DesafioFinal.DTOs;
using DesafioFinal.Helpers;
using System.Linq;

namespace DesafioFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == dto.UserName && u.Password == dto.Password);
            if (user == null) return Unauthorized("Usuario ou senha invalidos");

            JwtHelper jwtHelper = new();

            var token = jwtHelper.GenerateJwtToken(user);
            return Ok(new TokenResponseDto { Token = token });
        }
     
        
    }
}
