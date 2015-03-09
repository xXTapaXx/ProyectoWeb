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
        private ImprentaContext db = new ImprentaContext();

        public Boolean session()
        {
            if (Request.Cookies["userName"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: BuscarOrden
        public ActionResult Index()
        {
            if (session())
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("BuscarOrden/Buscar/{tipo}/{buscar}")]
        public Object buscarOrden(string tipo , string buscar)
        {
            if (session())
            {

                List<Informacion> buscarOrden = new List<Informacion>();
            List<Etapas> buscarProceso = new List<Etapas>() ;
            List<Object> listEtapa = new List<Object>();

                if (tipo == "num_orden")
                {
                    buscarOrden = db.Informacion.SqlQuery("SELECT * FROM informacion where num_orden like '%" + buscar + "%'").ToList();
                }
                else if (tipo == "vendedora")
                {
                    buscarOrden = db.Informacion.SqlQuery("SELECT * FROM informacion INNER JOIN usuario ON informacion.idusuario = usuario.id where usuario.nombre like '%" + buscar + "%'").ToList();
                }
                else if (tipo == "cliente")
                {
                    buscarOrden = db.Informacion.SqlQuery("SELECT * FROM informacion INNER JOIN cliente ON informacion.idcliente = cliente.id where cliente.nombre like '%" + buscar + "%'").ToList();
                }
                else if (tipo == "trabajo")
                {
                    buscarOrden = db.Informacion.SqlQuery("SELECT * FROM informacion where nombre_trabajo like '%" + buscar + "%'").ToList();
                }

            for (int i = 0; i < buscarOrden.Count; i++)
            {
                var buscarEstado = db.Estado.SqlQuery("SELECT * FROM estado where num_orden ='" + buscarOrden[i].num_orden + "'").ToList();
                if (buscarEstado != null)
                {
                    var prueba = buscarOrden[i].num_orden;
                    buscarProceso = db.Etapas.SqlQuery("SELECT * FROM etapas INNER JOIN estado ON estado.ubicacion = etapas.ubicacion WHERE estado.num_orden = '" + buscarOrden[i].num_orden + "' order By estado.ubicacion DESC limit 1").ToList();
                }
                else {
                    buscarProceso = db.Etapas.SqlQuery("SELECT etapa FROM etapas where num_orden ='" + buscarOrden[i].num_orden + "'").ToList();
                }
                
                listEtapa.Add(buscarProceso);
            }

              

            var JsonOrden = JsonConvert.SerializeObject(buscarOrden);
            var JsonProceso = JsonConvert.SerializeObject(listEtapa);

            var retorno = new {orden = JsonOrden, etapa = JsonProceso};

            return JsonConvert.SerializeObject(retorno);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}