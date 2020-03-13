using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoImagemaker.API.Data;

namespace DatingApp.API.Controllers
{
    // [Authorize] permite que todo dentro de este controlador (ValuesController) debe ser una solicitud autorizada
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ContextoDatos _contexto;
        public ValuesController(ContextoDatos contexto)
        {
            _contexto = contexto;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> ObtenerValores()
        {
            var valores = await _contexto.Values.ToListAsync();

            return Ok(valores);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerValor(int id)
        {
            var valor = await _contexto.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(valor);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}