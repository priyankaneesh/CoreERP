using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreERP.Models;

public partial class SalesReturn
{
    [Key]
    public Guid ReturnId { get; set; }

    public Guid SalesId { get; set; }

    public Guid ItemId { get; set; }

    public int? Quantity { get; set; }

    public string? ReturnReason { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual Sale Sales { get; set; } = null!;
}
