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
            RouteZipCodes routeZipCodes = new RouteZipCodes();
            
                 var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var customersFromZip = db.TrashCollectorCustomers.Where(c => c.ZipCode == employee.RouteZipCode).ToList();
            return View(customersFromZip);
        }
            
        

        // GET: TrashCollectorEmployees/Details/5
        public ActionResult Details(int? id)
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
           
                string getAspUser = User.Identity.GetUserId();
                trashCollectorEmployee.AspUserId = getAspUser;
                db.TrashCollectorEmployees.Add(trashCollectorEmployee);
                db.SaveChanges();

                return RedirectToAction("Index");
        
        }


        
        // GET: TrashCollectorEmployees/Edit/5
        public ActionResult Edit(int? id)
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
    

        // POST: TrashCollectorEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrashCollectorEmployee trashCollectorEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trashCollectorEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trashCollectorEmployee);
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

        public ActionResult GetMyPickupList()
        {
            return View();
        }

    }
}
