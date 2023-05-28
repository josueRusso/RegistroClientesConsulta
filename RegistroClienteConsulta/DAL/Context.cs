using Microsoft.EntityFrameworkCore;
using RegistroClienteConsulta.Model;
using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.DAL
{
    public class Context : DbContext
    {
        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Prioridad> prioridads { get; set; }   

        public Context(DbContextOptions<Context> options) : base(options) { }

    }
}
