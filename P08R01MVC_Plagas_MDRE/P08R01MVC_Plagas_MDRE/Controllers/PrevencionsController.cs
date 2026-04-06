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
    public class PrevencionsController : Controller
    {
        private ControlPlagasDBEntities db = new ControlPlagasDBEntities();

        // GET: Prevencions
        public ActionResult Index()
        {
            var prevencions = db.Prevencions.Include(p => p.Plaga);
            return View(prevencions.ToList());
        }

        // GET: Prevencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevencion prevencion = db.Prevencions.Find(id);
            if (prevencion == null)
            {
                return HttpNotFound();
            }
            return View(prevencion);
        }

        // GET: Prevencions/Create
        public ActionResult Create()
        {
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun");
            return View();
        }

        // POST: Prevencions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPrevencion,IdPlaga,Titulo,Descripcion")] Prevencion prevencion)
        {
            if (ModelState.IsValid)
            {
                db.Prevencions.Add(prevencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", prevencion.IdPlaga);
            return View(prevencion);
        }

        // GET: Prevencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevencion prevencion = db.Prevencions.Find(id);
            if (prevencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", prevencion.IdPlaga);
            return View(prevencion);
        }

        // POST: Prevencions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPrevencion,IdPlaga,Titulo,Descripcion")] Prevencion prevencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prevencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlaga = new SelectList(db.Plagas, "IdPlaga", "NombreComun", prevencion.IdPlaga);
            return View(prevencion);
        }

        // GET: Prevencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevencion prevencion = db.Prevencions.Find(id);
            if (prevencion == null)
            {
                return HttpNotFound();
            }
            return View(prevencion);
        }

        // POST: Prevencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prevencion prevencion = db.Prevencions.Find(id);
            db.Prevencions.Remove(prevencion);
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
