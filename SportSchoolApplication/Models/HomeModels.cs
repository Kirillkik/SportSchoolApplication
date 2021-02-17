using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportSchoolApplication.Models
{
    public class Main
    {

    }

    public class AboutCompetition
    {
        public int Id { get; set; }
        [Display(Name = "Аббревиатура")]
        public string Abreviature { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Дата начала")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Дата окончания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateTo { get; set; }
        [Display(Name = "Место")]
        public string Place { get; set; }
        [Display(Name = "Подача заявок")]
        public string Description { get; set; }
        [Display(Name = "Протокол")]
        public string FilePath { get; set; }
    }

    public class FPRInFace
    {

    }

    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
    }

    public class Record
    {

    }
}