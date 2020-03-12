using Microsoft.EntityFrameworkCore;
using proyectoImagemaker.API.Models;

namespace proyectoImagemaker.API.Data
{
    public class ContextoDatos : DbContext
    {
        public ContextoDatos(DbContextOptions<ContextoDatos> options) :  base(options){}

        public DbSet<Value> Values { get; set; }
    }
}