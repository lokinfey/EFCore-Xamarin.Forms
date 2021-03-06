﻿// <auto-generated />
using EfCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace EFCoreMigration.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    partial class CourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("EfCoreDemo.CourseInfo", b =>
                {
                    b.Property<int>("courseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("courseName");

                    b.HasKey("courseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EfCoreDemo.CourseSession", b =>
                {
                    b.Property<int>("sessionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("courseID");

                    b.Property<string>("sessionName");

                    b.HasKey("sessionID");

                    b.HasIndex("courseID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("EfCoreDemo.CourseSession", b =>
                {
                    b.HasOne("EfCoreDemo.CourseInfo", "course")
                        .WithMany("sessionList")
                        .HasForeignKey("courseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
