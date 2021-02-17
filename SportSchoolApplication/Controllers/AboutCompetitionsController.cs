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
    public class AboutCompetitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AboutCompetitions
        public ActionResult Index()
        {
            return View(db.AboutCompetitions.ToList());
        }

        // GET: AboutCompetitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCompetition aboutCompetition = db.AboutCompetitions.Find(id);
            if (aboutCompetition == null)
            {
                return HttpNotFound();
            }
            return View(aboutCompetition);
        }

        // GET: AboutCompetitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutCompetitions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Abreviature,Name,DateFrom,DateTo,Place,Description")]  HttpPostedFileBase FilePath, AboutCompetition aboutCompetition)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null)
                {
                    string filename = FilePath.FileName;
                    FilePath.SaveAs(Server.MapPath("/Files/" + filename));
                    aboutCompetition.FilePath = "/Files/" + filename;
                }
                db.AboutCompetitions.Add(aboutCompetition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutCompetition);
        }

        // GET: AboutCompetitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCompetition aboutCompetition = db.AboutCompetitions.Find(id);
            if (aboutCompetition == null)
            {
                return HttpNotFound();
            }
            return View(aboutCompetition);
        }

        // POST: AboutCompetitions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Abreviature,Name,DateFrom,DateTo,Place,Description")] HttpPostedFileBase FilePath, AboutCompetition aboutCompetition, string oldFilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null)
                {
                    string filename = FilePath.FileName;
                    FilePath.SaveAs(Server.MapPath("/Files/" + filename));
                    aboutCompetition.FilePath = "/Files/" + filename;
                }
                else aboutCompetition.FilePath = oldFilePath;

                db.Entry(aboutCompetition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutCompetition);
        }

        // GET: AboutCompetitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCompetition aboutCompetition = db.AboutCompetitions.Find(id);
            if (aboutCompetition == null)
            {
                return HttpNotFound();
            }
            return View(aboutCompetition);
        }

        // POST: AboutCompetitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutCompetition aboutCompetition = db.AboutCompetitions.Find(id);
            db.AboutCompetitions.Remove(aboutCompetition);
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
