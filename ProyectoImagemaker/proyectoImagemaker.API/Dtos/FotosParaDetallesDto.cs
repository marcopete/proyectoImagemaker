using System;

namespace proyectoImagemaker.API.Dtos
{
    public class FotosParaDetallesDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCarga { get; set; }
        public bool FotoPrincipal { get; set; }
    }
}