using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Etapas
    {
        [Key]
        public int id {get;set;}
    public string etapa { get; set; }
    public string ubicacion { get; set; }
    
    }
   

    }