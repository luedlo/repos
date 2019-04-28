using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Systree.Models;

namespace Systree.Controllers
{
    public class PlantController : Controller
    {
        private systreeDBEntities1 db = new systreeDBEntities1();

        // GET: Plant
        public ActionResult Index()
        {
            return View(db.Planta.ToList());
        }

        // GET: Plant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Planta.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Nombre,Longitud_promedio,Temporada,Luz_exposicion,Riego,Tipo_suelo,Otros")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Planta.Add(planta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planta);
        }

        // GET: Plant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Planta.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Nombre,Longitud_promedio,Temporada,Luz_exposicion,Riego,Tipo_suelo,Otros")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planta);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Planta.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planta planta = db.Planta.Find(id);
            db.Planta.Remove(planta);
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
