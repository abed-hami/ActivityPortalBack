using System;
using System.Collections.Generic;

namespace Portal.Core.Models;

public partial class Lookup
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Orders { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual User? User { get; set; }
}
