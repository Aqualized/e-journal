using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Lesson
{
    public int Lessonid { get; set; }

    public int Scheduleid { get; set; }

    public DateOnly Date { get; set; }

    public virtual ScheduleLesson Schedule { get; set; } = null!;

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();
}
