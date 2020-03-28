using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public class Carga
    {
        public static void CargaUsuarios(ContextoDatos contexto) 
        {
            if (!contexto.Usuarios.Any())
            {
                var dataUsuarios = System.IO.File.ReadAllText("Data/CargaUsuarios.json");
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(dataUsuarios);
                foreach (var usuario in usuarios)
                {
                    byte [] passwordHash, passwordSalt;
                    CrearHashDePassword("password", out passwordHash, out passwordSalt);

                    usuario.PasswordHash = passwordHash;
                    usuario.PasswordSalt = passwordSalt;
                    usuario.NombreUsuario = usuario.NombreUsuario.ToLower();
                    contexto.Usuarios.Add(usuario);
                }

                contexto.SaveChanges();
            }
        }

        private static void CrearHashDePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}