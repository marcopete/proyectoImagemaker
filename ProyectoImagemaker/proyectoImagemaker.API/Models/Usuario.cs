using System;
using System.Collections.Generic;

namespace proyectoImagemaker.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string KnownAs { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaVezActivo { get; set; }
        public string Introduccion { get; set; }
        public string Buscando { get; set; }
        public string Intereses { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public ICollection<Foto> Fotos { get; set; }
    }
}