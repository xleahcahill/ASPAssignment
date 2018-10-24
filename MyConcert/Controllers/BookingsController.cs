using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyConcert.Models;
using MyConcert.Helpers;
using MyConcert.ViewModels;
using Microsoft.AspNet.Identity;

namespace MyConcert.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Utility utility = new Utility();

        // GET: Bookings
        public ActionResult Index()
        {
            String userId = User.Identity.GetUserId();
            return View(db.Bookings.Where(b => b.CustomerId == userId).ToList());
        }
    

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? ShowId)
        {
           if (ShowId == null ) //return Error if null
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }

            Show show = db.Shows.Find(ShowId);
            if (show == null)
            {
                return HttpNotFound(); //error if no match found
            }
            BookingViewModel bookingVM = utility.GetBookingViewModel(show);
            return View(bookingVM);
        }


        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "BookingNo, ShowId, CustomerId,Email,BillingAddress,BillingCity,BillingPostcode,PaymentDetails, bookingTicket")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.CustomerId = User.Identity.GetUserId();
                booking.PurchaseDate = DateTime.Now;
                booking.bookingTicket = booking.bookingTicket.Where(s => s.Quantity > 0).ToList();
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Redirect("Create");
        }

        public ActionResult Create()
        {
            return View();
        }
        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingNo,CustomerId,Email,PurchaseDate,BillingAddress,BillingCity,BillingPostcode,PaymentDetails")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
