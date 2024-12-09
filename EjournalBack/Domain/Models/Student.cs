using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Groupnumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual StudentGroup GroupnumberNavigation { get; set; } = null!;

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();
}
