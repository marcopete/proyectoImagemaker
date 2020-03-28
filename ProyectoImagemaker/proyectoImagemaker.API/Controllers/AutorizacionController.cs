using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using proyectoImagemaker.API.Data;
using proyectoImagemaker.API.Dtos;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly IRepositorioAutorizacion _repo;
        private readonly IConfiguration _config;
        public AutorizacionController(IRepositorioAutorizacion repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioParaRegistrarDto usuarioParaRegistrarDto)
        {
            usuarioParaRegistrarDto.NombreUsuario = usuarioParaRegistrarDto.NombreUsuario.ToLower();

            if (await _repo.UsuarioExiste(usuarioParaRegistrarDto.NombreUsuario))
            {
                return BadRequest("Nombre de usuario ya existe");
            }

            var usuarioParaCrear = new Usuario
            {
                NombreUsuario = usuarioParaRegistrarDto.NombreUsuario
            };

            var usuarioCreado = await _repo.Registrar(usuarioParaCrear, usuarioParaRegistrarDto.Password);

            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioParaLoginDto usuarioParaLoginDto)
        {
            var usuarioDesdeRepo = await _repo.Login(usuarioParaLoginDto.NombreUsuario.ToLower(), usuarioParaLoginDto.Password);

            if (usuarioDesdeRepo == null)
            {
                return Unauthorized();
            }

            var reclamos = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioDesdeRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, usuarioDesdeRepo.NombreUsuario)
            };

            // ConfiguracionesApp:Token hace referencia a AppSettings.json
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("ConfiguracionesApp:Token").Value));

            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha512Signature);

            var descripcionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(reclamos),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = credenciales
            };

            var manejadorToken = new JwtSecurityTokenHandler();

            var token = manejadorToken.CreateToken(descripcionToken);

            return Ok(new {
                token = manejadorToken.WriteToken(token)
            });
        }
    }
}