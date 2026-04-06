using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P08R01MVC_Plagas_MDRE.Models;

namespace P08R01MVC_Plagas_MDRE.Controllers
{
    public class TratamientoesController : Controller
    {
        private ControlPlagasDBEntities db = new ControlPlagasDBEntities();

        // GET: Tratamientoes
        public ActionResult Index()
        {
            var tratamientos = db.Tratamientos.Include(t => t.Plaga);
            return View(tratamientos.ToList());
        }

        // GET: Tratamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientos.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // GET: Tratamientoes/Create
        public ActionResult Create()
        {
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun");
            return View();
        }

        // POST: Tratamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTratamiento,IdPlaga,Tipo,NombreProducto,Instrucciones")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamientos.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", tratamiento.IdPlaga);
            return View(tratamiento);
        }

        // GET: Tratamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientos.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", tratamiento.IdPlaga);
            return View(tratamiento);
        }

        // POST: Tratamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTratamiento,IdPlaga,Tipo,NombreProducto,Instrucciones")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", tratamiento.IdPlaga);
            return View(tratamiento);
        }

        // GET: Tratamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientos.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento tratamiento = db.Tratamientos.Find(id);
            db.Tratamientos.Remove(tratamiento);
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
