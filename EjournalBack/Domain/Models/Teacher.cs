using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Teacher
{
    public int Teacherid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();

    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    public virtual ICollection<Subject> Subjectnames { get; set; } = new List<Subject>();
}
