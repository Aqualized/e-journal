using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class ScheduleWeek
{
    public short Weeknumber { get; set; }

    public string? Weektype { get; set; }

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();
}
