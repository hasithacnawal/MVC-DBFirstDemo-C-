using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Assignment.New.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            var listofEmployee = db.Employees.ToList();
            return View(listofEmployee);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            db.Employees.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            var data = db.Employees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
            if(data != null)
            {
                data.EmployeeName = model.EmployeeName;
                data.EmployeeCity = model.EmployeeCity;
                data.EmployeeSalary = model.EmployeeSalary;
                db.SaveChanges();
                ViewBag.Message = "Record Edited Successfully";
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            db.Employees.Remove(data);
            db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
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
    }
}