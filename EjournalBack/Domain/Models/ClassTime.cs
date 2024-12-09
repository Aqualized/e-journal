using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class ClassTime
{
    public int Timeid { get; set; }

    public TimeOnly Starttime { get; set; }

    public TimeOnly Endtime { get; set; }

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();
}
