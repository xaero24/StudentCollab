using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCollab.Models;
using StudentCollab.Dal;

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
            string username = Request.Form["username"];
            string password = Request.Form["pass"]; //same name

            if (!(username == null || password == null))
            {
                UserDal dal = new UserDal();
                List<User> Users =
                (from x in dal.Users
                 where x.UserName == username && x.Password == password
                 select x).ToList<User>();
                if(Users.Any()) return RedirectToAction("Contact", Users[0]);
                else return RedirectToAction("Login");

            }
            
            else return RedirectToAction("Login");



        }
    }
}