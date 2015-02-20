using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class InformacionController : Controller
    {
        private InformacionDbContext db = new InformacionDbContext();

        // GET: Informacion
        public ActionResult Index()
        {
            return View(db.Informacion.ToList());
        }

        // GET: Informacion/Details/5
        public ActionResult Details(int? id)
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

        // GET: Informacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Informacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,num_orden,idcliente,idusuario,fecha_ingreso,fecha_salida,nombre_trabajo,observaciones")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                db.Informacion.Add(informacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informacion);
        }

        // GET: Informacion/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Informacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,num_orden,idcliente,idusuario,fecha_ingreso,fecha_salida,nombre_trabajo,observaciones")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informacion);
        }

        // GET: Informacion/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Informacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informacion informacion = db.Informacion.Find(id);
            db.Informacion.Remove(informacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
