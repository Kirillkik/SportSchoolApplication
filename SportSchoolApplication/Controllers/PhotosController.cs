﻿using System;
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
    public class PhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photos
        public ActionResult Index()
        {
            var photos = db.Photos.Include(p => p.Gallery);
            return View(photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name");
            return View();
        }

        // POST: Photos/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GalleryId")] HttpPostedFileBase PhotoPath, Photo photo)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null)
                {
                    string filename = PhotoPath.FileName;
                    PhotoPath.SaveAs(Server.MapPath("/Images/Photos/" + filename));
                    photo.PhotoPath = "/Images/Photos/" + filename;
                }
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", photo.GalleryId);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", photo.GalleryId);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GalleryId")] HttpPostedFileBase PhotoPath, Photo photo, string oldPhotoPath)
        {
            if (ModelState.IsValid)
            {
                if(PhotoPath != null)
                {
                    string filename = PhotoPath.FileName;
                    PhotoPath.SaveAs(Server.MapPath("/Images/Photos/" + filename));
                    photo.PhotoPath = "/Images/Photos/" + filename;
                }
                else photo.PhotoPath = oldPhotoPath;

                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", photo.GalleryId);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
