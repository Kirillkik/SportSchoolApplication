using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class Application
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string CoachId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Dicription { get; set; }
        [Required]
        public string Contacts { get; set; }
        public virtual ApplicationUser Coach { get; set; }

    }
}