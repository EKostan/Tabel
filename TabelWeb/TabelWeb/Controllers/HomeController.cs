using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using TabelWeb.Dal;
using TabelWeb.Models;

namespace TabelWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employees()
        {
            return View(new MyDbContext().Employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            //if (emp == null)
            //    return 

            var db = new MyDbContext();
            db.Employees.Add(emp);
            db.SaveChanges();

            return RedirectToAction("Employees");
        }

    }
}