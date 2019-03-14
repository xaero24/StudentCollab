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

        public ActionResult Signup()
        {
            

            return View();
        }

        public ActionResult SignupCont()
        {

            string username = Request.Form["Username"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string passwordConfirm = Request.Form["passwordConfirm"];
            //if the password not the same return to the sign up form
            if (!password.Equals(passwordConfirm))return RedirectToAction("Signup");
            else
            {
                UserDal dal = new UserDal();
                User tempUsr = new User()
                {
                    UserName = username,
                    Password = password,
                    Email = email,
                    rank = 1
                };

                dal.Users.Add(tempUsr);
                dal.SaveChanges();
            }

            return RedirectToAction("Login");
        }
    }
}