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
    }
}