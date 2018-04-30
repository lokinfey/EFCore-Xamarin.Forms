using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo
{
    public class CourseDbContext : DbContext
    {
        public DbSet<CourseInfo> Courses { get; set; }
        public DbSet<CourseSession> Sessions { get; set; }

        private string DatabasePath { get; set; }

        public CourseDbContext()
        {

        }

        public CourseDbContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSession>()
                        .HasOne(p => p.course)
                        .WithMany(b => b.sessionList)
                        .HasForeignKey("courseID");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
