using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Portal.Core.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Destination { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Cost { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public int? CategoryId { get; set; }

    
    public virtual Lookup? Category { get; set; }
   
    public virtual ICollection<GuidesEvent> GuidesEvents { get; set; } = new List<GuidesEvent>();
    
    public virtual ICollection<MembersEvent> MembersEvents { get; set; } = new List<MembersEvent>();
    
    public virtual User? User { get; set; }
}
