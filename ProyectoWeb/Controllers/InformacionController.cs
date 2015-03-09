using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using Newtonsoft.Json;

namespace ProyectoWeb.Controllers
{
    public class InformacionController : Controller
    {
        private ImprentaContext db = new ImprentaContext();
        private readonly object lista;

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

        // GET: Informacion
        public ActionResult Index()

        {
            List<Informacion_Cliente> Lista = new List<Informacion_Cliente>();
            Informacion_Cliente info = new Informacion_Cliente();

            //object info = null;
            
            if (session())
            {
                
                var prueba2 = from a in db.Informacion
                              join c in db.Cliente on a.idcliente equals c.id
                              join u in db.Usuario on a.idusuario equals u.id
                              select new { a.nombre_trabajo,a.id,a.num_orden,a.fecha_ingreso,a.fecha_salida,c.nombre,u.user };

               foreach (var v in prueba2)
                {
                    // Informacion info = new Informacion() { id = v.id, idcliente = v.nombre, idusuario = v.user, fecha_ingreso = v.fecha_ingreso, fecha_salida = v.fecha_salida, num_orden = v.num_orden };
                  info = new Informacion_Cliente() { id = v.id, cliente = v.nombre, usuario = v.user, fecha_ingreso = v.fecha_ingreso, fecha_salida = v.fecha_salida, num_orden = v.num_orden, nombre_trabajo = v.nombre_trabajo};

                    Lista.Add(info);

                }

                ViewBag.retorno = Lista;
                // ViewBag.retorno = lista;
                //  var buscar = db.SqlQuery("SELECT * FROM estado INNER JOIN etapas ON estado.ubicacion = etapas.ubicacion INNER JOIN informacion ON estado.num_orden = informacion.num_orden WHERE estado.num_orden = '" + num_orden + "' order By estado.ubicacion DESC limit 1").ToList();
                //  var prueba = db.Informacion.SqlQuery("SELECT * FROM informacion INNER JOIN Cliente ON informacion.idcliente = cliente.id INNER JOIN Usuario ON informacion.idusuario = Usuario.id").ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Informacion/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                List<Informacion_Cliente> Lista = new List<Informacion_Cliente>();
                Informacion_Cliente info = new Informacion_Cliente();

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                var informacion = from a in db.Informacion
                                                  join c in db.Cliente on a.idcliente equals c.id
                                                  join u in db.Usuario on a.idusuario equals u.id
                                                  select new { a.nombre_trabajo, a.id, a.num_orden, a.fecha_ingreso, a.fecha_salida, c.nombre, u.user };

                foreach (var v in informacion)
                {
                    // Informacion info = new Informacion() { id = v.id, idcliente = v.nombre, idusuario = v.user, fecha_ingreso = v.fecha_ingreso, fecha_salida = v.fecha_salida, num_orden = v.num_orden };
                    info = new Informacion_Cliente() { id = v.id, cliente = v.nombre, usuario = v.user, fecha_ingreso = v.fecha_ingreso, fecha_salida = v.fecha_salida, num_orden = v.num_orden, nombre_trabajo = v.nombre_trabajo };

                    Lista.Add(info);

                }
                if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(info);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Informacion/Create/{id:int}/{nombre}")]
        // GET: Informacion/Create
        public ActionResult Create(int id, string nombre)
        {
            if (session())
            {

                ViewBag.Id = id;
            ViewBag.Nombre = nombre;
            return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        // POST: Informacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Informacion/Create/{id:int}/{nombre}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,num_orden,idcliente,idusuario,fecha_ingreso,fecha_salida,nombre_trabajo,observaciones")] Informacion informacion)
        {
            if (session())
            {

                if (ModelState.IsValid)
            {
                    
                    var user = db.Usuario.SqlQuery("SELECT * from usuario where user = '" + Request.Cookies["userName"].Value + "'").ToList();
                    informacion.idusuario = user[0].id;
                db.Informacion.Add(informacion);
                db.SaveChanges();   

                var crearEstado = db.Estado.Create();
                crearEstado.num_orden = informacion.num_orden;
                crearEstado.ubicacion = 1;
                    db.Estado.Add(crearEstado);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informacion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Informacion/Edit/{id:int}/{idcliente:int}/{nombre}")]
        // GET: Informacion/Edit/5
        public ActionResult Edit(int id, int idcliente,string nombre)
        {
            if (session())
            {

                ViewBag.Id = id;
                ViewBag.Nombre = nombre;

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Informacion informacion = db.Informacion.Find(id);
                ViewBag.fecha_ingreso = informacion.fecha_ingreso;
                ViewBag.fecha_salida = informacion.fecha_salida;
                if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(informacion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Informacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Informacion/Edit/{id:int}/{nombre}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,num_orden,idcliente,idusuario,fecha_ingreso,fecha_salida,nombre_trabajo,observaciones")] Informacion informacion)
        {
            if (session())
            {

                if (ModelState.IsValid)
            {
                    var user = db.Usuario.SqlQuery("SELECT * from usuario where user = '" + Request.Cookies["userName"].Value + "'").ToList();
                    informacion.idusuario = user[0].id;
                    db.Entry(informacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informacion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Informacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Informacion informacion = db.Informacion.Find(id);
            if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(informacion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Informacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (session())
            {

                Informacion informacion = db.Informacion.Find(id);
            db.Informacion.Remove(informacion);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
