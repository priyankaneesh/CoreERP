using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models;

public partial class Vendor
{

    [Key]
    public Guid VendorId { get; set; } = Guid.NewGuid();  // Automatically generates a new GUID for VendorId

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Gstnumber { get; set; }

    public string? AccountNumber { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }
    [ForeignKey(nameof(StatusCodeNavigation))]
    public int StatusCode { get; set; }  // Foreign key reference to StatusCode table

    public decimal? OutstandingAmount { get; set; } = 0;  // Default value for OutstandingAmount

    // Navigation property
    public virtual StatusCode? StatusCodeNavigation { get; set; }

    // Optional: You can include Purchases or other collections if necessary
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

