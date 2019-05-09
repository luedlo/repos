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
    public class HomeController : Controller
    {
        private systreeDBEntities1 db = new systreeDBEntities1();

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "UserId,UserName,Password")] UserProfile user)
        {
            if (ModelState.IsValid)
            {
                db.UserProfile.Add(user);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                {
                    var obj = db.UserProfile.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            ViewBag.Message = "El usuario o contraseña son incorrectos!";
            return View();
        }

        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("Dashboard");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Design()
        {
            return View();
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