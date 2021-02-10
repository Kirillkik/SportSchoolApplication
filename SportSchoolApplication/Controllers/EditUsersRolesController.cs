using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportSchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EditUserRolesController : Controller
    {
        public List<RolesUsers> _rolesUsers = new List<RolesUsers>();
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private string PastRole = "";


        public ActionResult Index()
        {
            foreach (var Model in dbContext.Users.ToList())
            {
                var _RolesUsers = Model.Roles.FirstOrDefault();
                if (_RolesUsers != null)
                {
                    _rolesUsers.Add(new RolesUsers(_RolesUsers.UserId, _RolesUsers.RoleId));
                    PastRole = _rolesUsers.Last().UserRole;
                }
                else break;
            }
            return View(_rolesUsers);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesUsers rolesUsers;
            var _RolesUsers = dbContext.Users.Find(id).Roles.FirstOrDefault();
            if (_RolesUsers != null)
            {
                rolesUsers = new RolesUsers(_RolesUsers.UserId, _RolesUsers.RoleId);
            }
            else return HttpNotFound();

            return View(rolesUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,UserRole,UserId,RoleId")] RolesUsers rolesUsers)
        {
            if (ModelState.IsValid)
            {
                var _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
                var result =  _userManager.AddToRole(rolesUsers.UserId, rolesUsers.UserRole);
                if (result.Succeeded) _userManager.RemoveFromRole(rolesUsers.UserId, dbContext.Roles.Find(rolesUsers.RoleId).Name);
               
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolesUsers);
        }


    }


}