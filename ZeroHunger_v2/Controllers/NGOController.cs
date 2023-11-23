using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_v2.Models;


namespace ZeroHunger_v2.Controllers
{
    public class NGOController : Controller
    {
        // GET: Admin
        [Log]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Log]
        public ActionResult ShowAllRequest()
        {
            var db = new ZeroHungerContainer();
            ViewBag.Employees = (from us in db.Users
                                 where us.Role == "employee"
                                 select us).ToList();
            var data = (from cr in db.Requests
                        where cr.Status == "Requested"
                        select cr).ToList();
            return View(data);
        }
        [Log]
        [HttpGet]
        public ActionResult AssignEmployee(int id)
        {
            var db = new ZeroHungerContainer();
            ViewBag.Employees = (from us in db.Users
                                 where us.Role == "employee" && us.Status == "Available"
                                 select us).ToList();
            var data = db.Requests.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult AssignEmployee(Assignment a)
        {
            var db = new ZeroHungerContainer();

            db.Assignments.Add(a);
            db.SaveChanges();
            var data = db.Requests.Find(a.RequestID);
            data.Status = "Accepted";
            db.SaveChanges();
            var emp = db.Users.Find(a.EmployeeID);
            emp.Status = "Assigned";
            db.SaveChanges();
            return RedirectToAction("ShowAllAssignments");
        }
        [Log]
        public ActionResult ShowAllAssignments()
        {
            var db = new ZeroHungerContainer();
            var data = (from a in db.Assignments
                        where a.Status == "Assigned"
                        select a).ToList();

            return View(data);
        }
        [Log]
        public ActionResult DistibutionRecord()
        {
            var db = new ZeroHungerContainer();
            var data = db.DistributionRecords.ToList();

            return View(data);
        }
        [Log]
        public ActionResult RecordDetails(int id)
        {
            var db = new ZeroHungerContainer();
            var data = db.DistributionRecords.Find(id);
            return View(data);
        }

        [Log]

        public ActionResult ShowAllRestaurants()
        {
            var db = new ZeroHungerContainer();
            var data = db.Restaurants.ToList();

            return View(data);
        }

        public ActionResult ShowAllEmployees()
        {
            var db = new ZeroHungerContainer();
            var data = (from us in db.Users
                        where us.Role == "employee"
                        select us).ToList();
            return View(data);
        }


    }
}