using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Web.Helpers;
using System.Configuration;
using Stripe;

namespace TrashCollector.Controllers
{
    public class TrashCollectorEmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectorEmployees
        public ActionResult Index()
        {
            
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
            TrashCollectorEmployee trashCollectorEmployee = db.TrashCollectorEmployees.Find(Id);
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
            employee.FirstName = trashCollectorEmployee.FirstName;
            employee.LastName = trashCollectorEmployee.LastName;
            employee.RouteZipCode = trashCollectorEmployee.RouteZipCode;
            employee.RouteDay = trashCollectorEmployee.RouteDay;
            employee.PickupStatus = trashCollectorEmployee.PickupStatus;
            db.SaveChanges();

            return RedirectToAction("Index");
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
            var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var customersToday = db.TrashCollectorCustomers.Where(c => c.PickupDay == employee.RouteDay).ToList();
           
            EmployeeLandingPage landingPage = new EmployeeLandingPage();
            landingPage.TrashCollectorEmployee = employee;
            landingPage.CustomersByZip = customersToday;
            return View(customersToday);
        }

        public JsonResult CustomerByDayOnMap()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var employee = db.TrashCollectorEmployees.Where(t => t.AspUserId == userLoggedIn).FirstOrDefault();
            var data = db.TrashCollectorCustomers.Where(c => c.PickupDay == employee.RouteDay).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
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

        public ActionResult RouteCustomerDetails(int id)
        {
            var routeCustomer = db.TrashCollectorCustomers.Find(id);
            return View(routeCustomer);
        }

        public JsonResult RouteCustomerOnMap(int id)
        {
            var data = db.TrashCollectorCustomers.Where(t => t.Id == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RouteCustomerEdit(int? id)
        {
            var routeCustomer = db.TrashCollectorCustomers.Find(id);
            return View(routeCustomer);
        }

        [HttpPost]
        public async Task<ActionResult> RouteCustomerEdit(TrashCollectorCustomer editedCustomer)
        {
            try
            {
                //db.Entry(editedCustomer).State = EntityState.Modified;
                var customer = db.TrashCollectorCustomers.Single(t => t.Id == editedCustomer.Id);
                customer.PickupStatus = editedCustomer.PickupStatus;
                customer.Bill = editedCustomer.Bill;
                if (customer.Lat == 0)
                {
                    customer = await SetLatLong(customer);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editedCustomer);
            }
        }

        public async Task<TrashCollectorCustomer> SetLatLong(TrashCollectorCustomer customer)
        {
            // This is the geoDecoderRing 

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(customer.Street.Replace(" ", "+"));
            stringBuilder.Append(";");
            stringBuilder.Append(customer.City.Replace(" ", "+"));
            stringBuilder.Append(";");
            stringBuilder.Append(customer.State.Replace(" ", "+"));
            string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" +
                    stringBuilder.ToString() + "&key=" + Models.Access.apiKey;

            // httpclient

            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            System.IO.Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string responseFromServer = reader.ReadToEnd();
            response.Close();

            var root = JsonConvert.DeserializeObject<ParishMapAPIData>(responseFromServer);
            var location = root.results[0].geometry.location;
          
            customer.Lat = location.Lat;
            customer.Long = location.Long;
            return customer;


        }

        public class ParishMapAPIData
        {
            public Result[] results { get; set; }
            public string status { get; set; }
        }

        public class Result
        {
            public Address_Components[] address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public string[] types { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Location
        {
            public float Lat { get; set; }
            public float Long { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Northeast
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Southwest
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Address_Components
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }

        public ActionResult GetAllPickups()
        {
            var pickups = db.TrashCollectorCustomers.ToList();
            return Json(pickups, JsonRequestBehavior.AllowGet);
        }
    }
}
