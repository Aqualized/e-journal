using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Classroom
{
    public string Classroomnumber { get; set; } = null!;

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();
}
