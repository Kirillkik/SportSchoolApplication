using SportSchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult FPRInFace()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View(db.Galleries.OrderBy(x => x.Name));
        }
        public ActionResult Records()
        {
            return View();
        }
        #endregion

        [Authorize(Roles ="Coach")]
        public ActionResult Contact()
        {
            return View();
        }

    }
}