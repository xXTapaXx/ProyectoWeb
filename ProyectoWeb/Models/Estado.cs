using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Estado
    {
        [Key]
        [Column(Order = 1)]
        public int num_orden { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ubicacion { get; set; }


    }

   

}

    