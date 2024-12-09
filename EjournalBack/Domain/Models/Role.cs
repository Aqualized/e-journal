using System;
using System.Collections.Generic;

namespace EjournalBack.Domain.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SiteUser> SiteUsers { get; set; } = new List<SiteUser>();
}
