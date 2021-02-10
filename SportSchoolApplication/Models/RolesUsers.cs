using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class RolesUsers
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        [HiddenInput]
        public string UserId { get; set; }
        [Required]
        [HiddenInput]
        public string RoleId { get; set; }

        public RolesUsers()
        {
        }
        public RolesUsers(string uesrId, string roleId)
        {
            UserId = uesrId;
            RoleId = roleId;
            using (var dbcontext = new ApplicationDbContext())
            {
                UserName = dbcontext.Users.Find(UserId).UserName;
                UserRole = dbcontext.Roles.Find(RoleId).Name;
            }
        }
    }
}