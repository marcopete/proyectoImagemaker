using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoImagemaker.API.Data;
using proyectoImagemaker.API.Dtos;

namespace proyectoImagemaker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ISistemaRepositorio _repositorio;
        private readonly IMapper _mapeador;
        public UsuariosController(ISistemaRepositorio repositorio, IMapper mapeador)
        {
            _mapeador = mapeador;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _repositorio.ObtenerUsuarios();

            var usuariosRetornados = _mapeador.Map<IEnumerable<UsuarioParaListarDto>>(usuarios);

            return Ok(usuariosRetornados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var usuario = await _repositorio.ObtenerUsuario(id);

            var usuarioRetornado = _mapeador.Map<UsuarioParaDetallesDto>(usuario);

            return Ok(usuarioRetornado);
        }
    }
}