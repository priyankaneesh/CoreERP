using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models;

public partial class Company
{
    [Key]
    public Guid CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Gstnumber { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public decimal? Capital { get; set; }

    public decimal? Income { get; set; }
    [ForeignKey("Login")]
    public int LoginId { get; set; }

    // Navigation property for Login
    public virtual Login Login { get; set; } = null!;
}
