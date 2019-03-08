﻿using System;
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
    public class TrashCollectorCustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectorCustomers
        public ActionResult Index()
        {
            return View(db.TrashCollectorCustomers.ToList());
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,City,ZipCode")] TrashCollectorCustomer trashCollectorCustomer)
        {
            if (ModelState.IsValid)
            {
                db.TrashCollectorCustomers.Add(trashCollectorCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trashCollectorCustomer);
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,City,ZipCode")] TrashCollectorCustomer trashCollectorCustomer)
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