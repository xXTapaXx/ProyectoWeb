using System.Data.Entity;
using ProyectoWeb.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProyectoWeb.Models
{
    public class ImprentaContext : DbContext
    {
        public ImprentaContext()
            : base("TConexcion")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Etapas> Etapas { get; set; }
        public DbSet<Informacion> Informacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}