using System;
using System.Collections.Generic;

namespace Portal.Core.Models;

public partial class GuidesEvent
{
    public int? GuideId { get; set; }

    public int? EventId { get; set; }

    public int Id { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Guide? Guide { get; set; }
}
