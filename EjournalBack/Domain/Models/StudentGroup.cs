using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class StudentGroup
{
    public string Groupnumber { get; set; } = null!;

    public int? Studentcount { get; set; }

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
