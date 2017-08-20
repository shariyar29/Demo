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
        DemoEntities1 db = new DemoEntities1();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee obj)
        {
            var ob = db.Employees.Where(a => a.Username.Equals(obj.Username) && a.Password.Equals(obj.Password)).FirstOrDefault();
            if(ob !=null)
            {
                return RedirectToAction("Display", "Home");
            }
            ViewBag.msg = "Invalied username or password";
            return View();
        }
    }
}