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
    public class FPRInFacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FPRInFaces
        public ActionResult Index()
        {
            return View(db.FPRInFaces.ToList());
        }

        // GET: FPRInFaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPRInFace fPRInFace = db.FPRInFaces.Find(id);
            if (fPRInFace == null)
            {
                return HttpNotFound();
            }
            return View(fPRInFace);
        }

        // GET: FPRInFaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FPRInFaces/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIO,Biography,Achivments")] HttpPostedFileBase PhotoPath, FPRInFace fPRInFace)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null)
                {
                    string filename = PhotoPath.FileName;
                    PhotoPath.SaveAs(Server.MapPath("/Images/FPRInFace/" + filename));
                    fPRInFace.PhotoPath = "/Images/FPRInFace/" + filename;
                }
                db.FPRInFaces.Add(fPRInFace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fPRInFace);
        }

        // GET: FPRInFaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPRInFace fPRInFace = db.FPRInFaces.Find(id);
            if (fPRInFace == null)
            {
                return HttpNotFound();
            }
            return View(fPRInFace);
        }

        // POST: FPRInFaces/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIO,Biography,Achivments")] HttpPostedFileBase PhotoPath, FPRInFace fPRInFace, string oldPhotoPath)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null)
                {
                    string filename = PhotoPath.FileName;
                    PhotoPath.SaveAs(Server.MapPath("/Images/FPRInFace/" + filename));
                    fPRInFace.PhotoPath = "/Images/FPRInFace/" + filename;
                }
                else fPRInFace.PhotoPath = oldPhotoPath;

                db.Entry(fPRInFace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fPRInFace);
        }

        // GET: FPRInFaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPRInFace fPRInFace = db.FPRInFaces.Find(id);
            if (fPRInFace == null)
            {
                return HttpNotFound();
            }
            return View(fPRInFace);
        }

        // POST: FPRInFaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FPRInFace fPRInFace = db.FPRInFaces.Find(id);
            db.FPRInFaces.Remove(fPRInFace);
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
