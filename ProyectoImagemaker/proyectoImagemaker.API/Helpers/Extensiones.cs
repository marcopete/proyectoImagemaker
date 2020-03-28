using System;
using Microsoft.AspNetCore.Http;

namespace proyectoImagemaker.API.Helpers
{
    public static class Extensiones
    {
        public static void AgregarErrorDeAplicacion(this HttpResponse respuesta, string mensaje)
        {
            respuesta.Headers.Add("Application-Error", mensaje);
            respuesta.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            respuesta.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculoEdad(this DateTime laFecha)
        {
            var edad = DateTime.Today.Year - laFecha.Year;
            if (laFecha.AddYears(edad) > DateTime.Today)
                edad--;

            return edad;    
        }
    }
}