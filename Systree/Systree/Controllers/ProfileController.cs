using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Systree.Models;

namespace Systree.Controllers
{
    public class ProfileController : Controller
    {

        private systreeDBEntities1 db = new systreeDBEntities1();

        // GET: Profile
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userobj = db.UserProfile.Find(id);
            if (userobj == null)
            {
                return HttpNotFound();
            }
            return View(userobj);
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userobj = db.UserProfile.Find(id);
            db.UserProfile.Remove(userobj);
            db.SaveChanges();
            Session["UserName"] = null;
            return RedirectToAction("../Home/Dashboard");
        }

        // GET: user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userobj = db.UserProfile.Find(id);
            if (userobj == null)
            {
                return HttpNotFound();
            }
            return View(userobj);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,IsActive")] UserProfile userobj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userobj).State = EntityState.Modified;
                db.SaveChanges();
                string route = "Details/" + Session["UserId"];
                return RedirectToAction(route);
            }
            return View(userobj);
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
