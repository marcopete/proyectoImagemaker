using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using proyectoImagemaker.API.Data;

namespace proyectoImagemaker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var huesped = CreateHostBuilder(args).Build();
           using (var alcance = huesped.Services.CreateScope())
           {
               var servicios = alcance.ServiceProvider;
               try
               {
                   var contexto = servicios.GetRequiredService<ContextoDatos>();
                   contexto.Database.Migrate();
                   Carga.CargaUsuarios(contexto);
                //    Carga.CargarCiudades(contexto);
                //    Carga.CargarUsuarios(contexto);
               }
               catch (Exception ex)
               {
                   var logger = servicios.GetRequiredService<ILogger<Program>>();
                   logger.LogError(ex, "Error durante la migración");
               }            
            }

            huesped.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
