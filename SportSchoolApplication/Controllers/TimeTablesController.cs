using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SportSchoolApplication.Models;

namespace SportSchoolApplication.Controllers
{
    public class TimeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeTables
        public ActionResult Index()
        {
            if (User.IsInRole("Coach"))
            {
                var UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var timeTables = db.TimeTables.Include(t => t.Coach).Include(t => t.DayOfWeek).Include(t => t.Gym).Where(x => x.CoachId == UserId);
                return View(timeTables.ToList());
            }
            else
                return View(db.TimeTables.Include(t => t.Coach).Include(t => t.DayOfWeek).Include(t => t.Gym).ToList());
        }

        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: TimeTables/Create
        public ActionResult Create()
        {
            ViewBag.CoachId = new SelectList(db.Users, "Id", "Email");
            ViewBag.DayOfWeekId = new SelectList(db.DaysOfWeek, "Id", "Name");
            ViewBag.GymId = new SelectList(db.Gyms, "Id", "Address");
            return View();
        }

        // POST: TimeTables/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CoachId,GymId,DayOfWeekId,Time_From,Duration")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachId = new SelectList(db.Users, "Id", "Email", timeTable.CoachId);
            ViewBag.DayOfWeekId = new SelectList(db.DaysOfWeek, "Id", "Name", timeTable.DayOfWeekId);
            ViewBag.GymId = new SelectList(db.Gyms, "Id", "Address", timeTable.GymId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.Users, "Id", "Email", timeTable.CoachId);
            ViewBag.DayOfWeekId = new SelectList(db.DaysOfWeek, "Id", "Name", timeTable.DayOfWeekId);
            ViewBag.GymId = new SelectList(db.Gyms, "Id", "Address", timeTable.GymId);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CoachId,GymId,DayOfWeekId,Time_From,Duration")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.Users, "Id", "Email", timeTable.CoachId);
            ViewBag.DayOfWeekId = new SelectList(db.DaysOfWeek, "Id", "Name", timeTable.DayOfWeekId);
            ViewBag.GymId = new SelectList(db.Gyms, "Id", "Address", timeTable.GymId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timeTable);
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
