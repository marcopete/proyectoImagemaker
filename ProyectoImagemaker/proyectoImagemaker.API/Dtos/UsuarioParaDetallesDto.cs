using System;
using System.Collections.Generic;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Dtos
{
    public class UsuarioParaDetallesDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string KnownAs { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaVezActivo { get; set; }
        public string Introduccion { get; set; }
        public string Buscando { get; set; }
        public string Intereses { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string UrlFoto { get; set; }
        public ICollection<FotosParaDetallesDto> Fotos { get; set; }
    }
}