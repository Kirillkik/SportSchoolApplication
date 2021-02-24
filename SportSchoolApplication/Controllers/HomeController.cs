using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportSchoolApplication.Models;

namespace SportSchoolApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        #region Просто отображение
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutCompetition()
        {
            return View(db.AboutCompetitions.OrderBy(x => x.DateFrom));
        }
        public ActionResult FPRInFaces(int Id)
        {
            if (Id < 1) return View(db.FPRInFaces.ToList().Where(x => x.IsCoach).ToList());
            else return View(db.FPRInFaces.ToList().Where(x => !x.IsCoach).ToList());
        }
        public ActionResult FPRInFace(int Id)
        {
            return View(db.FPRInFaces.ToList().FirstOrDefault(x => x.Id == Id));
        }
        public ActionResult Gallery()
        {
            return View(db.Galleries.OrderBy(x => x.Name));
        }

        public ActionResult Photos(int id)
        {
            var PhotoFromGallery = db.Photos.ToList().Where(x => x.GalleryId == db.Galleries.ToArray()[id].Id).ToList();
            return View(PhotoFromGallery);
        }

        public ActionResult Photo (int Id)
        {
            return View(db.Photos.ToList().FirstOrDefault(x => x.Id == Id));
        }


        public ActionResult Records()
        {
            ViewBag.SexList = db.Sexes.ToList();
            ViewBag.CategoryList = db.Categories.ToList();
            var records = db.Records.OrderBy(x => x.CategoryId).Include(r => r.Category).Include(r => r.Type);
            return View(records.ToList());
        }
        #endregion

        [Authorize(Roles ="Coach")]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult TimeTable()
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            string roleName = "Coach";
            var role =  roleManager.Roles.Single(r => r.Name == roleName);

            ViewBag.CoachList = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList();
            return View(db.TimeTables.ToList());
        }
    }
}