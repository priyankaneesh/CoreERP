using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class Vendor
{
    public Guid VendorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Gstnumber { get; set; }

    public string? AccountNumber { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public int StatusCode { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual StatusCode StatusCodeNavigation { get; set; } = null!;
}
