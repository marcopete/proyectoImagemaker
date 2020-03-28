using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoImagemaker.API.Data;

namespace proyectoImagemaker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ISistemaRepositorio _repositorio;
        public UsuariosController(ISistemaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _repositorio.ObtenerUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var usuario = await _repositorio.ObtenerUsuario(id);

            return Ok(usuario);
        }        
    }
}