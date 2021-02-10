using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Controllers
{
    public class HomeController : Controller
    {
        #region Просто отображение
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutCompetition()
        {
            return View();
        }
        public ActionResult FPRInFace()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
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