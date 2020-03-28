using System.Threading.Tasks;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public interface IRepositorioAutorizacion
    {
         Task<Usuario> Registrar(Usuario usuario, string password);
         Task<Usuario> Login(string nombreUsuario, string password);
         Task<bool> UsuarioExiste(string nombreUsuario);
    }
}