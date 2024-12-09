using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Subject
{
    public string Subjectname { get; set; } = null!;

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
