using Newtonsoft.Json;
using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class BuscarOrdenController : Controller
    {
        private InformacionDbContext informacion = new  InformacionDbContext();
        // GET: BuscarOrden
        public ActionResult Index()
        {
            return View();
        }

        [Route("BuscarOrden/Buscar/{tipo}/{buscar}")]
        public Object buscarOrden(string tipo , string buscar)
        {
            Object buscarOrden = null;
            if (tipo == "num_orden")
            {
                 buscarOrden = informacion.Informacion.SqlQuery("SELECT * FROM informacion where num_orden like '%" + buscar + "%'").ToList();
            }
            else if (tipo == "trabajo")
            {
                 buscarOrden = informacion.Informacion.SqlQuery("SELECT * FROM informacion where nombre_trabajo like '%" + buscar + "%'").ToList();
            }
              

            var retorno = JsonConvert.SerializeObject(buscarOrden);

            return retorno;
        }
    }
}