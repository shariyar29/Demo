using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DemoEntities4 db = new DemoEntities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee obj)
        {
            if(!db.Employees.Any(x =>x.Username.Equals(obj.Username)))
            { 
            db.Employees.Add(obj);
            db.SaveChanges();
            ViewBag.msg = "Registered Sucessfully";//this will travel to this view 

           
            }
            else
            {
                ViewBag.msg1 = "Already Registered";
            }
            ModelState.Clear();//Clears the data after submit is clicked
            return View();

        }
        public ActionResult Display()
        {
            return View(db.Employees.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int?id)
        {
            Employee emp = db.Employees.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            Employee evalue = db.Employees.Find(e.EID);
            evalue.Ename = e.Ename;
            evalue.Password = e.Password;
            evalue.EDOJ = e.EDOJ;
            evalue.Edesignation = e.Edesignation;
            evalue.Edept = e.Edept;
            evalue.Ecity = e.Ecity;
            db.SaveChanges();
            ViewBag.Success = "Updated Successfull";
            return RedirectToAction("Display","Home");
        }
    }
}