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
            //var loggedInUser = User.Identity.GetUserId();
            //var loggedCustomer = db.TrashCollectorCustomers.Where(l => l.AspUserId == loggedInUser).First();
            var customer = db.TrashCollectorCustomers.FirstOrDefault();
            return View(customer);
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
            ViewBag.PickupDay = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="Monday", Text = "Monday"},
                new SelectListItem(){ Value="Tuesday", Text = "Tuesday"},
                new SelectListItem(){ Value="Wednesday", Text = "Wednesday"},
                new SelectListItem(){ Value="Thursday", Text = "Thursday"},
                new SelectListItem(){ Value="Friday", Text = "Friday"}
            };
            return RedirectToAction("Create");
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
            {
                {
                    string getAspUser = User.Identity.GetUserId();
                    trashCollectorCustomer.AspUserId = getAspUser;
                    db.TrashCollectorCustomers.Add(trashCollectorCustomer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "TrashCollectorCustomers");
            }
        }

        [HttpGet]
        public ActionResult CreatePickup()
        {
            return View();
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
            if (ModelState.IsValid)
            {
                db.Entry(trashCollectorCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trashCollectorCustomer);
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
