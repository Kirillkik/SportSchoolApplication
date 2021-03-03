using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportSchoolApplication.Models
{
    public class Gym
    {
        public Gym()
        {
            timeTables = new HashSet<TimeTable>();
        }

        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display (Name = "Адрес зала")]
        public string Address { get; set; }
        [Required]
        public string Number { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public ICollection<TimeTable> timeTables { get; set; }
    }
}