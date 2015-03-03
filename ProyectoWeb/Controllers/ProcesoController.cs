using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Controllers
{
    public class ProcesoController : Controller
    {
        private EstadoDbContext estado = new EstadoDbContext();
        private EtapasDbContext etapas = new EtapasDbContext();
        private InformacionDbContext informacion = new InformacionDbContext();
        // GET: Proceso
        public ActionResult Index()
        {
            return View();
        }

        [Route("Proceso/Buscar/{num_orden:int}")]
        public Object buscarOrden(int num_orden)
        {
           
            var buscar = estado.Estado.SqlQuery("SELECT * FROM estado INNER JOIN etapas ON estado.ubicacion = etapas.ubicacion INNER JOIN informacion ON estado.num_orden = informacion.num_orden WHERE estado.num_orden = '" + num_orden + "' order By estado.ubicacion DESC limit 1").ToList();
          
            var retorno = JsonConvert.SerializeObject(buscar);

            return retorno;
        }

        [Route("Proceso/Asignar/{num_orden:int}/{ubicacion:int}")]
        public Int32 PruebaORden(int num_orden, int ubicacion)
        {

            // var insertar = estado.Estado.SqlQuery("INSERT INTO estado(num_orden, ubicacion) VALUES ('" + num_orden + "','" + ubicacion + "')");
            var buscar = estado.Estado.SqlQuery("SELECT * FROM estado where num_orden='" + num_orden + "' and ubicacion = '" + ubicacion + "'").ToList();
            if (buscar.Count == 0)
            {
                var asignar = estado.Estado.Create();
                asignar.num_orden = num_orden;
                asignar.ubicacion = ubicacion;

                estado.Estado.Add(asignar);
                estado.SaveChanges();
            }
               return ubicacion;

            
           
            }
        }
}