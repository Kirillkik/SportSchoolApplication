using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportSchoolApplication.Models;

namespace SportSchoolApplication.Controllers
{
    public class RecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Records
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Category).Include(r => r.Type);
            return View(records.ToList());
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            ViewBag.SexList = db.Sexes.ToList();
            return View();
        }

        // POST: Records/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,FIO,SexId,City,Birthday,Result,Date,Place,Abbreviation,TypeId")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = db.Categories.ToList();
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            ViewBag.SexList = db.Sexes.ToList();
            //ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Id", record.CategoryId);
            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", record.TypeId);
            //ViewBag.SexList = new SelectList(db.Sexes, "Id", "Name", record.SexId);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryList = db.Categories.ToList();
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            ViewBag.SexList = db.Sexes.ToList();
            return View(record);
        }

        // POST: Records/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,FIO,SexId,City,Birthday,Result,Date,Place,Abbreviation,TypeId")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Id", record.CategoryId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", record.TypeId);
            ViewBag.SexList = new SelectList(db.Sexes, "Id", "Name", record.SexId);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
