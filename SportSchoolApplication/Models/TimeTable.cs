using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class TimeTable
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string CoachId { get; set; }
        [Required]
        public int GymId { get; set; }
        [Required]
        
        public int DayOfWeekId { get; set; }
        [Required]
        [Display (Name = "Время начала")]
        public DateTime Time_From { get; set; }
        [Required]
        [Display(Name = "Продолжительность")]
        public DateTime Duration { get; set; }

        public virtual ApplicationUser Coach { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual DayOfWeek DayOfWeek { get; set; }
    }
}