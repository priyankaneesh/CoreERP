using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreERP.Models;

public partial class PurchaseItem
{
    [Key]
    public Guid PurchaseItemId { get; set; }

    public Guid PurchaseId { get; set; }

    public Guid ItemId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Mrp { get; set; }

    public string? BatchNumber { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public decimal? SellingCost { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
