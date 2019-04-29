using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class TrashCollectorCustomersController : Controller
    {        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectorCustomers
        public ActionResult Index()
        {
            var loggedInUser = User.Identity.GetUserId();
            var loggedCustomer = db.TrashCollectorCustomers.Where(l => l.AspUserId == loggedInUser).FirstOrDefault();
            //var customer = db.TrashCollectorCustomers.FirstOrDefault();
            return View(loggedCustomer);
        }

        // GET: TrashCollectorCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollectorCustomer trashCollectorCustomer = db.TrashCollectorCustomers.Find(id);
            if (trashCollectorCustomer == null)
            {
                return HttpNotFound();
            }
            return View(trashCollectorCustomer);
        }

        // GET: TrashCollectorCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrashCollectorCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrashCollectorCustomer trashCollectorCustomer)
        {
            trashCollectorCustomer.AspUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var getAspUser = User.Identity.GetUserId();
                trashCollectorCustomer.AspUserId = getAspUser;
                db.TrashCollectorCustomers.Add(trashCollectorCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(trashCollectorCustomer);
            }

        }



        // GET: TrashCollectorCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollectorCustomer trashCollectorCustomer = db.TrashCollectorCustomers.Find(id);
            if (trashCollectorCustomer == null)
            {
                return HttpNotFound();
            }
            return View(trashCollectorCustomer);
        }

        // POST: TrashCollectorCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrashCollectorCustomer trashCollectorCustomer)
        {
            var customer = db.TrashCollectorCustomers.Single(m => m.Id == trashCollectorCustomer.Id);
            customer.FirstName = trashCollectorCustomer.FirstName;
            customer.LastName = trashCollectorCustomer.LastName;
            customer.ZipCode = trashCollectorCustomer.ZipCode;
            customer.PickupDay = trashCollectorCustomer.PickupDay;
            customer.BackupPickupDay = trashCollectorCustomer.BackupPickupDay;
            customer.StartPickupSuspension = trashCollectorCustomer.StartPickupSuspension;
            customer.EndPickupSuspension = trashCollectorCustomer.EndPickupSuspension;
            customer.PickupStatus = trashCollectorCustomer.PickupStatus;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TrashCollectorCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollectorCustomer trashCollectorCustomer = db.TrashCollectorCustomers.Find(id);
            if (trashCollectorCustomer == null)
            {
                return HttpNotFound();
            }
            return View(trashCollectorCustomer);
        }

        // POST: TrashCollectorCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrashCollectorCustomer trashCollectorCustomer = db.TrashCollectorCustomers.Find(id);
            db.TrashCollectorCustomers.Remove(trashCollectorCustomer);
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
    }
}
