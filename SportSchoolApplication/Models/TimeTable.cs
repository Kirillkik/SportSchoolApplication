using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class TimeTable
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public int Id_Coach { get; set; }
        [Required]
        public int Id_Gym { get; set; }
        [Required]
        public int Id_DayOfWeek { get; set; }
        [Required]
        public DateTime Time_From { get; set; }
        [Required]
        public DateTime Duration { get; set; }
    }
}