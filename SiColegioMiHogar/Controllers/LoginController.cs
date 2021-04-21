using BackEnd;
using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;
using BackEnd.Usuario.Aplicacion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : Controller
    {
        private readonly MiHogarContext _context;
        private readonly IConfiguration _configuration;
        private UnitOfWork _unitOfWork;
        private LoginService _service;
        public LoginController(MiHogarContext context, IConfiguration configuration)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _configuration = configuration;

        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest user)
        {

            _service = new LoginService(_unitOfWork);
            var rta = _service.Login(user);
            if (!rta.isOk())
            {
                return BadRequest(rta.Message);
            }

            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
                new Claim("UserData", JsonConvert.SerializeObject(rta))
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            rta.Token = tokenHandler.WriteToken(createdToken);
            return Ok(rta.Message);
        }
    }
}
