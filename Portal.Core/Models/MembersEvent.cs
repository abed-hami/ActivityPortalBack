using System;
using System.Collections.Generic;

namespace Portal.Core.Models;

public partial class MembersEvent
{
    public int? MemberId { get; set; }

    public int? EventsId { get; set; }

    public int Id { get; set; }

    public virtual Event? Events { get; set; }

    public virtual Member? Member { get; set; }
}
