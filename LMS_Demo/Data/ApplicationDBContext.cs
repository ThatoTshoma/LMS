using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Models;

namespace LMS_Demo.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
       //public DbSet<User> Users { get; set; }
       public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<AssesmentType> AssesmentTypes { get; set; }
        //public DbSet<Course> Course { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SubmitAssignment> SubmitAssignment { get; set; }
        public DbSet<Teach> Teaches { get; set; }
        public DbSet<Year> Years { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
