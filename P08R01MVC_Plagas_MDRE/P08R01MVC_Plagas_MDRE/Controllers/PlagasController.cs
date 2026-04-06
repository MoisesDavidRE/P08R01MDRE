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
    public class PlagasController : Controller
    {
        private ControlPlagasDBEntities db = new ControlPlagasDBEntities();

        // GET: Plagas
        public ActionResult Index()
        {
            return View(db.Plagas.ToList());
        }

        // GET: Plagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaga plaga = db.Plagas.Find(id);
            if (plaga == null)
            {
                return HttpNotFound();
            }
            return View(plaga);
        }

        // GET: Plagas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlaga,NombreComun,NombreCientifico,Categoria,NivelRiesgo,UrlImage")] Plaga plaga)
        {
            if (ModelState.IsValid)
            {
                db.Plagas.Add(plaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plaga);
        }

        // GET: Plagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaga plaga = db.Plagas.Find(id);
            if (plaga == null)
            {
                return HttpNotFound();
            }
            return View(plaga);
        }

        // POST: Plagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlaga,NombreComun,NombreCientifico,Categoria,NivelRiesgo,UrlImage")] Plaga plaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plaga);
        }

        // GET: Plagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaga plaga = db.Plagas.Find(id);
            if (plaga == null)
            {
                return HttpNotFound();
            }
            return View(plaga);
        }

        // POST: Plagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plaga plaga = db.Plagas.Find(id);
            db.Plagas.Remove(plaga);
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
