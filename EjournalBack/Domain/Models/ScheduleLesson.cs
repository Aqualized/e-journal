using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class ScheduleLesson
{
    public int Scheduleid { get; set; }

    public string Groupnumber { get; set; } = null!;

    public short Weeknumber { get; set; }

    public string Weekday { get; set; } = null!;

    public int Timeid { get; set; }

    public string Classroomnumber { get; set; } = null!;

    public int Teacherid { get; set; }

    public string Subjectname { get; set; } = null!;

    public virtual Classroom ClassroomnumberNavigation { get; set; } = null!;

    public virtual StudentGroup GroupnumberNavigation { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Subject SubjectnameNavigation { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ClassTime Time { get; set; } = null!;

    public virtual ScheduleWeekDay WeekdayNavigation { get; set; } = null!;

    public virtual ScheduleWeek WeeknumberNavigation { get; set; } = null!;
}
