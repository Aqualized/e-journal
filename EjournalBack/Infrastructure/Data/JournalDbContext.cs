using System;
using System.Collections.Generic;
using EjournalBack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EjournalBack.Infrastructure.Data;

public partial class JournalDbContext : DbContext
{

    public virtual DbSet<ClassTime> ClassTimes { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }
    
    public virtual DbSet<SiteUser> SiteUsers { get; set; }

    public virtual DbSet<ScheduleLesson> ScheduleLessons { get; set; }

    public virtual DbSet<ScheduleWeek> ScheduleWeeks { get; set; }

    public virtual DbSet<ScheduleWeekDay> ScheduleWeekDays { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    public JournalDbContext(DbContextOptions<JournalDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<ClassTime>(entity =>
        {
            entity.HasKey(e => e.Timeid).HasName("class_time_pkey");

            entity.ToTable("class_time", "istucontroldb");

            entity.HasIndex(e => new { e.Starttime, e.Endtime }, "uniquetime").IsUnique();

            entity.Property(e => e.Timeid).HasColumnName("timeid");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Classroomnumber).HasName("classroom_pkey");

            entity.ToTable("classroom", "istucontroldb");

            entity.Property(e => e.Classroomnumber)
                .HasMaxLength(20)
                .HasColumnName("classroomnumber");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Lessonid).HasName("lesson_pkey");

            entity.ToTable("lesson", "istucontroldb");

            entity.Property(e => e.Lessonid).HasColumnName("lessonid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Scheduleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lesson_scheduleid_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");

            entity.ToTable("role", "istucontroldb");

            entity.HasIndex(e => e.Name, "role_name_key").IsUnique();

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ScheduleLesson>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("schedule_lesson_pkey");

            entity.ToTable("schedule_lesson", "istucontroldb");

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Classroomnumber)
                .HasMaxLength(20)
                .HasColumnName("classroomnumber");
            entity.Property(e => e.Groupnumber)
                .HasMaxLength(20)
                .HasColumnName("groupnumber");
            entity.Property(e => e.Subjectname)
                .HasMaxLength(100)
                .HasColumnName("subjectname");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Timeid).HasColumnName("timeid");
            entity.Property(e => e.Weekday)
                .HasMaxLength(20)
                .HasColumnName("weekday");
            entity.Property(e => e.Weeknumber).HasColumnName("weeknumber");

            entity.HasOne(d => d.ClassroomnumberNavigation).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Classroomnumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_classroomnumber_fkey");

            entity.HasOne(d => d.GroupnumberNavigation).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Groupnumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_groupnumber_fkey");

            entity.HasOne(d => d.SubjectnameNavigation).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Subjectname)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_subjectname_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Teacherid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_teacherid_fkey");

            entity.HasOne(d => d.Time).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Timeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_timeid_fkey");

            entity.HasOne(d => d.WeekdayNavigation).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Weekday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_weekday_fkey");

            entity.HasOne(d => d.WeeknumberNavigation).WithMany(p => p.ScheduleLessons)
                .HasForeignKey(d => d.Weeknumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_lesson_weeknumber_fkey");
        });

        modelBuilder.Entity<ScheduleWeek>(entity =>
        {
            entity.HasKey(e => e.Weeknumber).HasName("schedule_week_pkey");

            entity.ToTable("schedule_week", "istucontroldb");

            entity.Property(e => e.Weeknumber)
                .ValueGeneratedNever()
                .HasColumnName("weeknumber");
            entity.Property(e => e.Weektype).HasColumnName("weektype");
        });

        modelBuilder.Entity<ScheduleWeekDay>(entity =>
        {
            entity.HasKey(e => e.Weekday).HasName("schedule_week_day_pkey");

            entity.ToTable("schedule_week_day", "istucontroldb");

            entity.Property(e => e.Weekday)
                .HasMaxLength(20)
                .HasColumnName("weekday");
        });

        modelBuilder.Entity<SiteUser>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("site_user_pkey");

            entity.ToTable("site_user", "istucontroldb");

            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RoleNumber)
                .ValueGeneratedOnAdd()
                .HasColumnName("role");

            entity.HasOne(d => d.Role).WithMany(p => p.SiteUsers)
                .HasForeignKey(d => d.RoleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("site_user_role_fkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("student_pkey");

            entity.ToTable("student", "istucontroldb");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(70)
                .HasColumnName("firstname");
            entity.Property(e => e.Groupnumber)
                .HasMaxLength(20)
                .HasColumnName("groupnumber");
            entity.Property(e => e.Lastname)
                .HasMaxLength(70)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(70)
                .HasColumnName("middlename");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasOne(d => d.GroupnumberNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Groupnumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_groupnumber_fkey");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => new { e.Lessonid, e.Studentid }).HasName("student_attendance_pkey");

            entity.ToTable("student_attendance", "istucontroldb");

            entity.Property(e => e.Lessonid).HasColumnName("lessonid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Attendance).HasColumnName("attendance");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");

            entity.HasOne(d => d.Lesson).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.Lessonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_attendance_lessonid_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_attendance_studentid_fkey");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.Groupnumber).HasName("student_group_pkey");

            entity.ToTable("student_group", "istucontroldb");

            entity.Property(e => e.Groupnumber)
                .HasMaxLength(20)
                .HasColumnName("groupnumber");
            entity.Property(e => e.Studentcount).HasColumnName("studentcount");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Subjectname).HasName("subject_pkey");

            entity.ToTable("subject", "istucontroldb");

            entity.Property(e => e.Subjectname)
                .HasMaxLength(100)
                .HasColumnName("subjectname");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("teacher_pkey");

            entity.ToTable("teacher", "istucontroldb");

            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(70)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(70)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(70)
                .HasColumnName("middlename");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasMany(d => d.Subjectnames).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("Subjectname")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teacher_subject_subjectname_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("Teacherid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teacher_subject_teacherid_fkey"),
                    j =>
                    {
                        j.HasKey("Teacherid", "Subjectname").HasName("teacher_subject_pkey");
                        j.ToTable("teacher_subject", "istucontroldb");
                        j.IndexerProperty<int>("Teacherid").HasColumnName("teacherid");
                        j.IndexerProperty<string>("Subjectname")
                            .HasMaxLength(100)
                            .HasColumnName("subjectname");
                    });
        });

        modelBuilder.Entity<TeacherAttendance>(entity =>
        {
            entity.HasKey(e => new { e.Lessonid, e.Teacherid }).HasName("teacher_attendance_pkey");

            entity.ToTable("teacher_attendance", "istucontroldb");

            entity.Property(e => e.Lessonid).HasColumnName("lessonid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Attendance).HasColumnName("attendance");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");

            entity.HasOne(d => d.Lesson).WithMany(p => p.TeacherAttendances)
                .HasForeignKey(d => d.Lessonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_attendance_lessonid_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAttendances)
                .HasForeignKey(d => d.Teacherid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_attendance_teacherid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}