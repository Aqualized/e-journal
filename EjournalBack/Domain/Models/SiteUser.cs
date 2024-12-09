using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class SiteUser
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleNumber { get; set; }

    public virtual Role Role { get; set; } = null!;
}
