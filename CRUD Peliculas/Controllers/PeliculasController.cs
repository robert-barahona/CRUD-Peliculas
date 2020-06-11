using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUPelicula;

namespace CRUD_Peliculas.Controllers
{
    public class PeliculasController : Controller
    {
        private Entities db = new Entities();

        // GET: Peliculas
        public ActionResult Index()
        {
            return View(db.tblPelicula.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPelicula tblPelicula = db.tblPelicula.Find(id);
            if (tblPelicula == null)
            {
                return HttpNotFound();
            }
            return View(tblPelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,estreno,categoria,duracion")] tblPelicula tblPelicula)
        {
            if (ModelState.IsValid)
            {
                db.tblPelicula.Add(tblPelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPelicula tblPelicula = db.tblPelicula.Find(id);
            if (tblPelicula == null)
            {
                return HttpNotFound();
            }
            return View(tblPelicula);
        }

        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,estreno,categoria,duracion")] tblPelicula tblPelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPelicula tblPelicula = db.tblPelicula.Find(id);
            if (tblPelicula == null)
            {
                return HttpNotFound();
            }
            return View(tblPelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPelicula tblPelicula = db.tblPelicula.Find(id);
            db.tblPelicula.Remove(tblPelicula);
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
