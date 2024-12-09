using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class StudentAttendance
{
    public int Lessonid { get; set; }

    public int Studentid { get; set; }

    public short? Attendance { get; set; }

    public string? Reason { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
