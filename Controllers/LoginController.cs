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
                if (Users.Any())
                {
                    //Creates the user class as defined by rank
                    switch (Users[0].rank)
                    {
                        case 0:
                            AdminUser admin = new AdminUser(Users[0]);
                            ViewData["CurrentUser"] = admin;
                            break;
                        case 1:
                            ManagerUser manager = new ManagerUser(Users[0]);
                            ViewData["CurrentUser"] = manager;
                            break;
                        case 2:
                            User usr = new User(Users[0]);
                            ViewData["CurrentUser"] = usr;
                            break;
                    }
                    //return RedirectToAction("Contact", Users[0]);
                    return RedirectToAction("MainPage", "MainPage", Users[0]);
                }
                else
                {
                    return RedirectToAction("Contact");
                }

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
            string institution = null;
            if (!(Request.Form["institution"].Equals("")))
            {
                institution = Request.Form["institution"];
            }
            int? year = null;
            try
            {
                 year = Int32.Parse(Request.Form["year"]);
            }
            catch
            {
                year = null;
            }
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
                    rank = 1,
                    institution = institution,
                    year = year

                };


                //Checks if a user with the same user name exists
                List<User> Users =
                (from x in dal.Users
                 where x.UserName == username
                 select x).ToList<User>();
                if(!(Users.Any()))
                {
                    dal.Users.Add(tempUsr);
                    dal.SaveChanges();
                }

            }

            return RedirectToAction("Login");
        }
    }
}