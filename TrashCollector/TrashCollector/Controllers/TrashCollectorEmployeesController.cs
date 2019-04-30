using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class TrashCollectorEmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectorEmployees
        public ActionResult Index()
        {
            //RouteZipCodes routeZipCodes = new RouteZipCodes();
            
            var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var customersFromZip = db.TrashCollectorCustomers.Where(c => c.ZipCode == employee.RouteZipCode).ToList();
            EmployeeLandingPage landingPage = new EmployeeLandingPage();
            landingPage.TrashCollectorEmployee = employee;
            landingPage.CustomersByZip = customersFromZip;

            return View(landingPage);
        } 
        

        // GET: TrashCollectorEmployees/Details/5
        public ActionResult Details()
        {
            var loggedInUser = User.Identity.GetUserId();
            var trashCollectorEmployee = db.TrashCollectorEmployees.Where(t => t.AspUserId == loggedInUser).First();
            
            return View(trashCollectorEmployee);

        }

        // GET: TrashCollectorEmployees/Create
        public ActionResult Create()
        {
            var selectedZip = db.TrashCollectorCustomers.Select(c => c.ZipCode).ToList();
            TrashCollectorEmployee Employee = new TrashCollectorEmployee();

            Employee.ZipCodeSelected = selectedZip;
            return View(Employee);

        }

        // POST: TrashCollectorEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrashCollectorEmployee trashCollectorEmployee)
        {
            trashCollectorEmployee.AspUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var getAspUser = User.Identity.GetUserId();
                trashCollectorEmployee.AspUserId = getAspUser;
                db.TrashCollectorEmployees.Add(trashCollectorEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(trashCollectorEmployee);
            }

        }


        
        // GET: TrashCollectorEmployees/Edit/5
        public ActionResult Edit(int? Id)
        {
            var loggedInUser = User.Identity.GetUserId();
            //if (Id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            TrashCollectorEmployee trashCollectorEmployee = db.TrashCollectorEmployees.Find(Id);
            //if (trashCollectorEmployee == null)
            //{
            //    return HttpNotFound();
            //}
            return View(trashCollectorEmployee);
        }
    

        // POST: TrashCollectorEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrashCollectorEmployee trashCollectorEmployee)
        {
            var loggedInUser = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Single(m => m.Id == trashCollectorEmployee.Id);
            //employee.FirstName = trashCollectorEmployee.FirstName;
            //employee.LastName = trashCollectorEmployee.LastName;
            //employee.RouteZipCode = trashCollectorEmployee.RouteZipCode;
            //employee.RouteDay = trashCollectorEmployee.RouteDay;
            //employee.PickupStatus = trashCollectorEmployee.PickupStatus;
            db.SaveChanges();

            return RedirectToAction("Index");


            //if (ModelState.IsValid)
            //{
            //    TrashCollectorEmployee trashCollectorEmployee = db.TrashCollectorEmployees.Where(t => t.Id == Id).FirstOrDefault();
            //    //db.Entry(trashCollectorEmployee).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View();
        }


        // GET: TrashCollectorEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollectorEmployee trashCollectorEmployee = db.TrashCollectorEmployees.Find(id);
            if (trashCollectorEmployee == null)
            {
                return HttpNotFound();
            }
            return View(trashCollectorEmployee);
        }

        // POST: TrashCollectorEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrashCollectorEmployee trashCollectorEmployee = db.TrashCollectorEmployees.Find(id);
            db.TrashCollectorEmployees.Remove(trashCollectorEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult CustomersByDayIndex()
        {

            //var userLoggedIn = User.Identity.GetUserId();
            //var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            //var customersToday = db.TrashCollectorCustomers.Where(c => c.PickupDay == employee.RouteDay).ToList();
            //EmployeeLandingPage landingPage = new EmployeeLandingPage();
            //landingPage.TrashCollectorEmployee = employee;
            //landingPage.CustomersByZip = customersToday;
            //return View(customersToday);


            var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var customersByDay = db.TrashCollectorCustomers.Where(c => c.PickupDay == employee.RouteDay).ToList();

            return View(customersByDay);
        }

        public ActionResult CustomersByDayEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollectorCustomer employeeByDay = db.TrashCollectorCustomers.Find(id);
            if (employeeByDay == null)
            {
                return HttpNotFound();
            }
            return View(employeeByDay);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomersByDay(TrashCollectorCustomer customerDay)
        {
            var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var customersToday = db.TrashCollectorCustomers.Where(c => c.PickupDay == employee.RouteDay).ToList();
            EmployeeLandingPage landingPage = new EmployeeLandingPage();
            landingPage.TrashCollectorEmployee = employee;
            landingPage.CustomersByZip = customersToday;
            return View(customerDay);
        }

        public ActionResult RouteCustomerEdit(int? id)
        {
            var routeCustomer = db.TrashCollectorCustomers.Find(id);
            return View(routeCustomer);
        }

        [HttpPost]
        public ActionResult RouteCustomerEdit(TrashCollectorCustomer editedCustomer)
        {
            try
            {
                //db.Entry(editedCustomer).State = EntityState.Modified;
                var customer = db.TrashCollectorCustomers.Single(m => m.Id == editedCustomer.Id);
                customer.PickupStatus = editedCustomer.PickupStatus;
                customer.Bill = editedCustomer.Bill;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editedCustomer);
            }
        }


    }
}
