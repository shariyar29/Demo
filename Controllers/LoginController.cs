using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DemoEntities4 db = new DemoEntities4();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee obj)
        {
            if(ModelState.IsValid)
            {
                var ob = db.Employees.Where(a => a.Username.Equals(obj.Username) && a.Password.Equals(obj.Password)).FirstOrDefault();
                if(ob !=null)
                {
                    Session["EID"] = ob.EID.ToString();
                    Session["Username"] = ob.Username.ToString();
                    ViewBag.succ = "Logged In";
                    return RedirectToAction("Display", "Home");
                }
                ViewBag.msg = "Invalied username or password";
                
            }
            return View(obj);
        }
        public ActionResult Dashboard()
        {
            if (Session["Eid"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}