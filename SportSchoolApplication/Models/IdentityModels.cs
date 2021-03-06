﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SportSchoolApplication.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string FIO { get; set; }
        public string Phone { get; set; }

        public ApplicationUser()
        {
            timeTables = new HashSet<TimeTable>();
            applications = new HashSet<Application>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
        public virtual ICollection<Gym> Gyms { get; set; }
        public virtual ICollection<TimeTable> timeTables { get; set; }
        public virtual ICollection<Application> applications { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<AboutCompetition> AboutCompetitions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<FPRInFace> FPRInFaces { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Record> Records { get; set; }

        public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}