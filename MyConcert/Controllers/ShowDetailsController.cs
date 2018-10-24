using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyConcert.Models;

namespace MyConcert.Views
{
    public class ShowDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShowDetails
        public ActionResult Index()
        {
            return View(db.ShowDetails.ToList());
        }

        // GET: ShowDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDetails showDetails = db.ShowDetails.Find(id);
            if (showDetails == null)
            {
                return HttpNotFound();
            }
            return View(showDetails);
        }

        // GET: ShowDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowDetailsId,Genre,VenueName,VenueId,ShowDate,ShowStartTime,ShowEndTime,Summary,Duration,IsVIPAvailable,IsFrontRowAvailable,IsTieredSeatingAvailable,ArtistName")] ShowDetails showDetails)
        {
            if (ModelState.IsValid)
            {
                db.ShowDetails.Add(showDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showDetails);
        }

        // GET: ShowDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDetails showDetails = db.ShowDetails.Find(id);
            if (showDetails == null)
            {
                return HttpNotFound();
            }
            return View(showDetails);
        }

        // POST: ShowDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowDetailsId,Genre,VenueName,VenueId,ShowDate,ShowStartTime,ShowEndTime,Summary,Duration,IsVIPAvailable,IsFrontRowAvailable,IsTieredSeatingAvailable,ArtistName")] ShowDetails showDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showDetails);
        }

        // GET: ShowDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDetails showDetails = db.ShowDetails.Find(id);
            if (showDetails == null)
            {
                return HttpNotFound();
            }
            return View(showDetails);
        }

        // POST: ShowDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowDetails showDetails = db.ShowDetails.Find(id);
            db.ShowDetails.Remove(showDetails);
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
