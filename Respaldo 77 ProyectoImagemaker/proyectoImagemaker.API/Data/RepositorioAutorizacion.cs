using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public class RepositorioAutorizacion : IRepositorioAutorizacion
    {
        private readonly ContextoDatos _contexto;
        public RepositorioAutorizacion(ContextoDatos contexto)
        {
            _contexto = contexto;

        }
        public async Task<Usuario> Login(string nombreUsuario, string password)
        {
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                return null;
            }

            if (!VerificaHashDePassword(password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return null;
            }

            return usuario;
        }

        private bool VerificaHashDePassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashCalculado.Length; i++)
                {
                    if (hashCalculado[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<Usuario> Registrar(Usuario usuario, string password)
        {
            byte[] passwordHash, passwordSalt;
            CrearHashDePassword(password, out passwordHash, out passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return usuario;
        }

        private void CrearHashDePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UsuarioExiste(string nombreUsuario)
        {
            if (await _contexto.Usuarios.AnyAsync(x => x.NombreUsuario == nombreUsuario))
            {
                return true;
            }

            return false;
        }
    }
}