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
        [Display(Name = "Протокол/Положение")]
        public string FilePath { get; set; }
    }

    public class FPRInFace
    {
        public int Id { get; set; }
        [Display (Name ="ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Биография")]
        public string Biography { get; set; }
        [Display(Name = "Достижения")]
        public string Achivments { get; set; }
        [Display(Name = "Это тренер?")]
        public bool IsCoach { get; set; }
        [Display(Name = "Фотография")]
        public string PhotoPath { get; set; }
    }

    public class Gallery
    {
        public Gallery()
        {
            photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Фотография")]
        public string PhotoPath { get; set; }
        public ICollection<Photo> photos { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        [Display (Name = "Фотография")]
        public string PhotoPath { get; set; }
        public int GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }
    }

    public class Type
    {
        public Type()
        {
            records = new HashSet<Record>();
        }
        public int Id { get; set; }
        [Display(Name = "Вид")]
        public string Name { get; set; }
        public ICollection<Record> records { get; set; }
    }

    public class Category
    {
        public Category()
        {
            records = new HashSet<Record>();
        }
        public int Id { get; set; }
        [Display(Name = "Категория")]
        public string Weight { get; set; }
        public bool IsMan { get; set; }
        public ICollection<Record> records { get; set; }
    }

    public class Sex
    {
        public Sex()
        {
            records = new HashSet<Record>();
        }
        public int Id { get; set; }
        [Display(Name = "Пол")]
        public string Name { get; set; }
        public ICollection<Record> records { get; set; }
    }

    public class Record
    {
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        public int SexId { get; set; }
        [Display(Name = "Город рождения")]
        public string City { get; set; }
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Результат")]
        public float Result { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Место")]
        public string Place { get; set; }
        [Display(Name = "Аббревиатура")]
        public string Abbreviation { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Type Type { get; set; }
    }
}