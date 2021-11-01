using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T2008M_WAD.Models;

namespace T2008M_WAD.Controllers
{
    public class ExamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Practicals
        public ActionResult Index()
        {
            return View(db.Practicals.ToList());
        }

        // GET: Practicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicals practicals = db.Practicals.Find(id);
            if (practicals == null)
            {
                return HttpNotFound();
            }
            return View(practicals);
        }

        // GET: Practicals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Practicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subjects,Start,ExamDate,Duration,ClassRoom,Faculty,Status")] Practicals practicals)
        {
            if (ModelState.IsValid)
            {
                db.Practicals.Add(practicals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(practicals);
        }

        // GET: Practicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicals practicals = db.Practicals.Find(id);
            if (practicals == null)
            {
                return HttpNotFound();
            }
            return View(practicals);
        }

        // POST: Practicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subjects,Start,ExamDate,Duration,ClassRoom,Faculty,Status")] Practicals practicals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practicals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practicals);
        }

        // GET: Practicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicals practicals = db.Practicals.Find(id);
            if (practicals == null)
            {
                return HttpNotFound();
            }
            return View(practicals);
        }

        // POST: Practicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Practicals practicals = db.Practicals.Find(id);
            db.Practicals.Remove(practicals);
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
