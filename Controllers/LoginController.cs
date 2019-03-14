using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCollab.Models;

namespace StudentCollab.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View(new User());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(User getUsr)
        {
            ViewBag.Message = "Your contact page.";

            return View(getUsr);
        }

        public ActionResult Submit()
        {
            User usr = new User();
            usr.UserName = Request.Form["username"];
            usr.Password = Request.Form["pass"]; //same name

            if (!(usr.UserName == null || usr.Password == null)) return RedirectToAction("Contact", usr);
            else return RedirectToAction("Login");



        }
    }
}