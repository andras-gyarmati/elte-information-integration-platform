using ANYU.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ANYU.Api;

public class AnyuDbContext : DbContext
{
    public AnyuDbContext(DbContextOptions<AnyuDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<University> Universities { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<CourseInstance> CourseInstances { get; set; }

    public DbSet<Semester> Semesters { get; set; }

    public DbSet<LectureLab> LectureLabs { get; set; }

    public DbSet<PassingRequirement> PassingRequirements { get; set; }

    public DbSet<UniversityRequirement> UniversityRequirements { get; set; }

    public DbSet<UserCourseData> UserCourseData { get; set; }

    public DbSet<LectureLabPrerequisite> LectureLabPrerequisites { get; set; }

    public DbSet<UniversityRequirementCourse> UniversityRequirementCourses { get; set; }

    public DbSet<UserCompletedRequirement> UserCompletedRequirements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<Course>().HasIndex(c => c.Code).IsUnique();

        modelBuilder.Entity<UserCourseData>().HasOne(ucd => ucd.LectureLab).WithMany(ll => ll.UserCourseData).HasForeignKey(ucd => ucd.LectureLabId).OnDelete(DeleteBehavior.Restrict);

        // Composite keys
        modelBuilder.Entity<LectureLabPrerequisite>().HasKey(llp => new { llp.LectureLabId, llp.PrerequisiteId });
        modelBuilder.Entity<UniversityRequirementCourse>().HasKey(urc => new { urc.RequirementId, urc.CourseId });
        modelBuilder.Entity<UserCompletedRequirement>().HasKey(ucr => new { ucr.UserId, ucr.RequirementId });
        modelBuilder.Entity<UserCourseData>().HasKey(ucd => new { ucd.UserId, ucd.LectureLabId });

        // One-to-many relationships
        modelBuilder.Entity<User>().HasOne(u => u.University).WithMany(uni => uni.Users).HasForeignKey(u => u.UniversityId);
        modelBuilder.Entity<CourseInstance>().HasOne(ci => ci.Course).WithMany(c => c.CourseInstances).HasForeignKey(ci => ci.CourseId);
        modelBuilder.Entity<CourseInstance>().HasOne(ci => ci.Semester).WithMany(s => s.CourseInstances).HasForeignKey(ci => ci.SemesterId);
        modelBuilder.Entity<LectureLab>().HasOne(ll => ll.CourseInstance).WithMany(ci => ci.LectureLabs).HasForeignKey(ll => ll.CourseInstanceId);

        // Many-to-many relationships
        // LectureLab to Prerequisites
        modelBuilder.Entity<LectureLabPrerequisite>().HasOne(llp => llp.LectureLab).WithMany(ll => ll.Prerequisites).HasForeignKey(llp => llp.LectureLabId);
        modelBuilder.Entity<LectureLabPrerequisite>().HasOne(llp => llp.Prerequisite).WithMany().HasForeignKey(llp => llp.PrerequisiteId).OnDelete(DeleteBehavior.Restrict);

        // UniversityRequirement to Courses
        modelBuilder.Entity<UniversityRequirementCourse>().HasOne(urc => urc.UniversityRequirement).WithMany(ur => ur.MandatoryCourses).HasForeignKey(urc => urc.RequirementId);
        modelBuilder.Entity<UniversityRequirementCourse>().HasOne(urc => urc.Course).WithMany().HasForeignKey(urc => urc.CourseId).OnDelete(DeleteBehavior.Restrict);

        // UserCompletedRequirement
        modelBuilder.Entity<UserCompletedRequirement>().HasOne(ucr => ucr.User).WithMany(u => u.CompletedRequirements).HasForeignKey(ucr => ucr.UserId);
        modelBuilder.Entity<UserCompletedRequirement>().HasOne(ucr => ucr.PassingRequirement).WithMany().HasForeignKey(ucr => ucr.RequirementId).OnDelete(DeleteBehavior.Restrict);
    }
}
