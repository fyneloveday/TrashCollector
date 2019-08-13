using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        public async Task <ActionResult> Create(TrashCollectorCustomer trashCollectorCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trashCollectorCustomer.AspUserId = User.Identity.GetUserId();
                    db.TrashCollectorCustomers.Add(trashCollectorCustomer);
                    if (trashCollectorCustomer.Lat == 0)
                    {
                        trashCollectorCustomer = await SetLatLong(trashCollectorCustomer);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(trashCollectorCustomer);
            }
            catch
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
        public async Task<ActionResult> Edit(TrashCollectorCustomer trashCollectorCustomer)
        {
            var userId = User.Identity.GetUserId();
            var customer = db.TrashCollectorCustomers.Where(m => m.AspUserId == userId).Single();
            customer.FirstName = trashCollectorCustomer.FirstName;
            customer.LastName = trashCollectorCustomer.LastName;
            customer.Street = trashCollectorCustomer.Street;
            customer.City = trashCollectorCustomer.City;
            customer.State = trashCollectorCustomer.State;
            customer.ZipCode = trashCollectorCustomer.ZipCode;
            customer.PickupDay = trashCollectorCustomer.PickupDay;
            customer.BackupPickupDay = trashCollectorCustomer.BackupPickupDay;
            customer.StartPickupSuspension = trashCollectorCustomer.StartPickupSuspension;
            customer.EndPickupSuspension = trashCollectorCustomer.EndPickupSuspension;
            customer.PickupStatus = trashCollectorCustomer.PickupStatus;
            if (customer.Lat == 0)
            {
                customer = await SetLatLong(customer);
            }
            db.SaveChanges();

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


            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            System.IO.Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string responseFromServer = reader.ReadToEnd();
            response.Close();

            var root = JsonConvert.DeserializeObject<ParishMapAPIData>(responseFromServer);
            var location = root.results[0].geometry.location;
            
            customer.Lat = location.lat;
            customer.Long = location.lng;
            return customer;
        }

        [HttpGet]
        public ActionResult PayFee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayFee(string stripeToken)
        {
            try
            {
                StripeConfiguration.SetApiKey("sk_test_fILcvWEnilxMKhCgvbnUnCaP00zUfb2TwZ");
                var options = new ChargeCreateOptions
                {
                    Amount = 200,
                    Currency = "usd",
                    Description = "Your Charge",
                    Source = stripeToken // obtained with Stripe.js,

                };
                var service = new ChargeService();
                Charge charge = service.Create(options);
                var model = new ChargeViewModel();
                model.ChargeId = charge.Id;
                return View("PayStatus", model);
            }
            catch
            {
                return View();
            }
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
            public float lat { get; set; }
            public float lng { get; set; }
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
    }
}
