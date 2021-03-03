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
        public DayOfWeek()
        {
            timeTables = new HashSet<TimeTable>();
        }

        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display (Name = "День недели")]
        public string Name { get; set; }

        public ICollection<TimeTable> timeTables { get; set; }
    }
}