using System;
using TrashCollector.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Controllers
{
    public class TrashCollectorController : Controller
    {
        // GET: TrashCollector
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrashCollector/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrashCollector/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrashCollector/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrashCollector/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrashCollector/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrashCollector/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrashCollector/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
