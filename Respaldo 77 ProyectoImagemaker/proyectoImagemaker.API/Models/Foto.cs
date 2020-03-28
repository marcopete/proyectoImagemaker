using System;

namespace proyectoImagemaker.API.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCarga { get; set; }
        public bool FotoPrincipal { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}