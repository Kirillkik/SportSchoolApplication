using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class DayOfWeek
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}