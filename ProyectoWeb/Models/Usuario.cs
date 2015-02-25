using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Usuario
    {
        public int id { get; set; }
        
        [StringLength(100)]

        public string nombre { get; set; }

        
        [StringLength(100)]
        public string apellidos { get; set; }

        
        
        public departamentos departamento { get; set; }

       
        [StringLength(100)]
        public string user { get; set; }

        
        [StringLength(200,MinimumLength = 6)]
        [DataType(DataType.Password)]
        
        public string contrasena { get; set; }



        public enum departamentos
        {
            Administrador,
            Oficina,
            Taller
        }
    }


    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext() : base("TConexcion")
        {


        }

        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    
}
}