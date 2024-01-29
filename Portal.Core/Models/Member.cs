using System;
using System.Collections.Generic;

namespace Portal.Core.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? MobileNumber { get; set; }

    public string? Photo { get; set; }

    public string? Profession { get; set; }

    public string? Nationality { get; set; }

    public string? EmergencyNumber { get; set; }

    public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();

    public virtual ICollection<MembersEvent> MembersEvents { get; set; } = new List<MembersEvent>();
}
