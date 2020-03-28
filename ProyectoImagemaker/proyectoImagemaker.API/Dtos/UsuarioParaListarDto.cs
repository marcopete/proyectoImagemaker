using System;

namespace proyectoImagemaker.API.Dtos
{
    public class UsuarioParaListarDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string KnownAs { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaVezActivo { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string UrlFoto { get; set; }
    }
}