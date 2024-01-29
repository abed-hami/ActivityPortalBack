using System;
using System.Collections.Generic;

namespace ActivityPortal.API.Models;

public partial class WebsiteInformation
{
    public int Id { get; set; }

    public string? About { get; set; }

    public string? Main { get; set; }

    public string? Service1 { get; set; }

    public string? Service2 { get; set; }

    public string? Service3 { get; set; }

    public string? Service4 { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
