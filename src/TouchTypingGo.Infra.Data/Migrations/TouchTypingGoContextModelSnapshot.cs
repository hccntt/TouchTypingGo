﻿// <auto-generated />
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TouchTypingGo.Infra.Data.Context;

namespace TouchTypingGo.Infra.Data.Migrations
{
    [DbContext(typeof(TouchTypingGoContext))]
    partial class TouchTypingGoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TouchTypingGo.Domain.Course.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("LimitDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("TeacherId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.CourseLessonPresentation", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("LessonPresentationId");

                    b.HasKey("CourseId", "LessonPresentationId");

                    b.HasIndex("LessonPresentationId");

                    b.ToTable("CourseLessonPresentations");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.Keyboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("KeyboardContent");

                    b.Property<int>("Lcid");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("ValHtml")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Keyboard");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.LessonPresentation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("FontSize");

                    b.Property<string>("Name");

                    b.Property<int>("PrecisionReference");

                    b.Property<int>("SpeedReference");

                    b.Property<string>("Text");

                    b.Property<int>("TimeReference");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("LessonPresentation");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.LessonResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("EhAuthenticated");

                    b.Property<string>("ErrorKey")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<int?>("Errors");

                    b.Property<Guid>("LessonPresentationId");

                    b.Property<int?>("Time");

                    b.Property<int>("Try");

                    b.Property<Guid?>("UserId");

                    b.Property<int>("Wpm");

                    b.HasKey("Id");

                    b.HasIndex("LessonPresentationId");

                    b.ToTable("LessonResult");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Institution.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CascadeMode");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Street");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Institution.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<int>("CascadeMode");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.Course", b =>
                {
                    b.HasOne("TouchTypingGo.Domain.Course.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.CourseLessonPresentation", b =>
                {
                    b.HasOne("TouchTypingGo.Domain.Course.Course", "Course")
                        .WithMany("CourseLessonPresentations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TouchTypingGo.Domain.Course.LessonPresentation", "LessonPresentation")
                        .WithMany("CourseLessonPresentations")
                        .HasForeignKey("LessonPresentationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Course.LessonResult", b =>
                {
                    b.HasOne("TouchTypingGo.Domain.Course.LessonPresentation", "LessonPresentation")
                        .WithMany("LessonResults")
                        .HasForeignKey("LessonPresentationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TouchTypingGo.Domain.Institution.Institution", b =>
                {
                    b.HasOne("TouchTypingGo.Domain.Institution.Address", "Address")
                        .WithOne("Institution")
                        .HasForeignKey("TouchTypingGo.Domain.Institution.Institution", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
