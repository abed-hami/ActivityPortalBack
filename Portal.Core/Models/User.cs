using System;
using System.Collections.Generic;

namespace Portal.Core.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FisrtName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Lookup> Lookups { get; set; } = new List<Lookup>();

    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
