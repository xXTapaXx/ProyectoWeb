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
    public class Informacion
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int num_orden { get; set; }


        public int idcliente { get; set; }

        public int idusuario { get; set; }

        [Required]
        [DataType(DataType.Date)]
        
        public DateTime fecha_ingreso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha_salida { get; set; }

        [Required]
        public string nombre_trabajo { get; set; }

        public string observaciones { get; set; }

       
    }

    
    }