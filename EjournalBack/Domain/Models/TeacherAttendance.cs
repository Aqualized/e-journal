using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class TeacherAttendance
{
    public int Lessonid { get; set; }

    public int Teacherid { get; set; }

    public short? Attendance { get; set; }

    public string? Reason { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
