﻿// <auto-generated />
using System;
using ANYU.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ANYU.Api.Migrations
{
    [DbContext(typeof(AnyuDbContext))]
    [Migration("20231217085052_RenameUserCourseDataToUserLectureLabData")]
    partial class RenameUserCourseDataToUserLectureLabData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ANYU.Api.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Category")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CourseId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ANYU.Api.Models.CourseInstance", b =>
                {
                    b.Property<int>("CourseInstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseInstanceId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("CourseInstanceId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SemesterId");

                    b.ToTable("CourseInstance");
                });

            modelBuilder.Entity("ANYU.Api.Models.LectureLab", b =>
                {
                    b.Property<int>("LectureLabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureLabId"));

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CourseInstanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LectureLabId");

                    b.HasIndex("CourseInstanceId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LectureLab");
                });

            modelBuilder.Entity("ANYU.Api.Models.LectureLabPrerequisite", b =>
                {
                    b.Property<int>("LectureLabId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("PrerequisiteId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("LectureLabId", "PrerequisiteId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("LectureLabPrerequisite");
                });

            modelBuilder.Entity("ANYU.Api.Models.PassingRequirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("RequirementId");

                    b.ToTable("PassingRequirement");
                });

            modelBuilder.Entity("ANYU.Api.Models.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamPeriodWeeks")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudyPeriodWeeks")
                        .HasColumnType("int");

                    b.HasKey("SemesterId");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("ANYU.Api.Models.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityId"));

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UniversityId");

                    b.ToTable("University");
                });

            modelBuilder.Entity("ANYU.Api.Models.UniversityRequirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CreditsRequired")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("RequirementId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityRequirement");
                });

            modelBuilder.Entity("ANYU.Api.Models.UniversityRequirementCourse", b =>
                {
                    b.Property<int>("RequirementId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("RequirementId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UniversityRequirementCourse");
                });

            modelBuilder.Entity("ANYU.Api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UniversityId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ANYU.Api.Models.UserCompletedRequirement", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("RequirementId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int?>("UserLectureLabDataLectureLabId")
                        .HasColumnType("int");

                    b.Property<int?>("UserLectureLabDataUserId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RequirementId");

                    b.HasIndex("RequirementId");

                    b.HasIndex("UserLectureLabDataUserId", "UserLectureLabDataLectureLabId");

                    b.ToTable("UserCompletedRequirement");
                });

            modelBuilder.Entity("ANYU.Api.Models.UserLectureLabData", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("LectureLabId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Grade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId", "LectureLabId");

                    b.HasIndex("LectureLabId");

                    b.ToTable("UserLectureLabData");
                });

            modelBuilder.Entity("ANYU.Api.Models.CourseInstance", b =>
                {
                    b.HasOne("ANYU.Api.Models.Course", "Course")
                        .WithMany("CourseInstances")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.Semester", "Semester")
                        .WithMany("CourseInstances")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("ANYU.Api.Models.LectureLab", b =>
                {
                    b.HasOne("ANYU.Api.Models.CourseInstance", "CourseInstance")
                        .WithMany("LectureLabs")
                        .HasForeignKey("CourseInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseInstance");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ANYU.Api.Models.LectureLabPrerequisite", b =>
                {
                    b.HasOne("ANYU.Api.Models.LectureLab", "LectureLab")
                        .WithMany("Prerequisites")
                        .HasForeignKey("LectureLabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.LectureLab", "Prerequisite")
                        .WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LectureLab");

                    b.Navigation("Prerequisite");
                });

            modelBuilder.Entity("ANYU.Api.Models.UniversityRequirement", b =>
                {
                    b.HasOne("ANYU.Api.Models.University", "University")
                        .WithMany("UniversityRequirements")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("ANYU.Api.Models.UniversityRequirementCourse", b =>
                {
                    b.HasOne("ANYU.Api.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.UniversityRequirement", "UniversityRequirement")
                        .WithMany("MandatoryCourses")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("UniversityRequirement");
                });

            modelBuilder.Entity("ANYU.Api.Models.User", b =>
                {
                    b.HasOne("ANYU.Api.Models.University", "University")
                        .WithMany("Users")
                        .HasForeignKey("UniversityId");

                    b.Navigation("University");
                });

            modelBuilder.Entity("ANYU.Api.Models.UserCompletedRequirement", b =>
                {
                    b.HasOne("ANYU.Api.Models.PassingRequirement", "PassingRequirement")
                        .WithMany()
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.User", "User")
                        .WithMany("CompletedRequirements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.UserLectureLabData", null)
                        .WithMany("CompletedRequirements")
                        .HasForeignKey("UserLectureLabDataUserId", "UserLectureLabDataLectureLabId");

                    b.Navigation("PassingRequirement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ANYU.Api.Models.UserLectureLabData", b =>
                {
                    b.HasOne("ANYU.Api.Models.LectureLab", "LectureLab")
                        .WithMany("UserCourseData")
                        .HasForeignKey("LectureLabId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ANYU.Api.Models.User", "User")
                        .WithMany("UserCourseData")
                        .HasForeignKey("LectureLabId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LectureLab");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ANYU.Api.Models.Course", b =>
                {
                    b.Navigation("CourseInstances");
                });

            modelBuilder.Entity("ANYU.Api.Models.CourseInstance", b =>
                {
                    b.Navigation("LectureLabs");
                });

            modelBuilder.Entity("ANYU.Api.Models.LectureLab", b =>
                {
                    b.Navigation("Prerequisites");

                    b.Navigation("UserCourseData");
                });

            modelBuilder.Entity("ANYU.Api.Models.Semester", b =>
                {
                    b.Navigation("CourseInstances");
                });

            modelBuilder.Entity("ANYU.Api.Models.University", b =>
                {
                    b.Navigation("UniversityRequirements");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ANYU.Api.Models.UniversityRequirement", b =>
                {
                    b.Navigation("MandatoryCourses");
                });

            modelBuilder.Entity("ANYU.Api.Models.User", b =>
                {
                    b.Navigation("CompletedRequirements");

                    b.Navigation("UserCourseData");
                });

            modelBuilder.Entity("ANYU.Api.Models.UserLectureLabData", b =>
                {
                    b.Navigation("CompletedRequirements");
                });
#pragma warning restore 612, 618
        }
    }
}
