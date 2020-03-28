using System.Collections.Generic;
using System.Threading.Tasks;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public interface ISistemaRepositorio
    {
         void Agregar<T>(T entity) where T: class;
         void Eliminar<T>(T entity) where T: class;
         Task<bool> GuardarTodo();
         Task<IEnumerable<Usuario>> ObtenerUsuarios();
         Task<Usuario> ObtenerUsuario(int id);
    }
}