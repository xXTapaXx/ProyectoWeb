using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Etapas
    {
        public int id {get;set;}
    public string etapa { get; set; }
    public string ubicacion { get; set; }
    
    }
    public class EtapasDbContext : DbContext
    {
        public EtapasDbContext() : base("TConexcion")
        {


        }

        public DbSet<Etapas> Etapas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    }