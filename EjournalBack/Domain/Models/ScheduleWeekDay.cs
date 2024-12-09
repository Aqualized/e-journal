using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class ScheduleWeekDay
{
    public string Weekday { get; set; } = null!;

    public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } = new List<ScheduleLesson>();
}
