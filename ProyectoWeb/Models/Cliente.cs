using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        
        public int telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

    }

   


}