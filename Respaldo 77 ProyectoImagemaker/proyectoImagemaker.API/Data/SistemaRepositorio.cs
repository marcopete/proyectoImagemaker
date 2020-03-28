using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public class SistemaRepositorio : ISistemaRepositorio
    {
        private readonly ContextoDatos _contexto;
        public SistemaRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }
        public void Agregar<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Eliminar<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public async Task<bool> GuardarTodo()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> ObtenerUsuario(int id)
        {
            var usuario = await _contexto.Usuarios.Include(f => f.Fotos).FirstOrDefaultAsync(u => u.Id == id);

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            var usuarios = await _contexto.Usuarios.Include(f => f.Fotos).ToListAsync();

            return usuarios;
        }
    }
}