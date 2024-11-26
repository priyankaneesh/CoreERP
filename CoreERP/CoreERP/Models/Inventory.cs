using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class Inventory
{
    public Guid ItemId { get; set; }

    public string ItemCode { get; set; } = null!;

    public string? ItemName { get; set; }

    public int? Quantity { get; set; }

    public string? BatchNumber { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? CostPrice { get; set; }

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    public virtual ICollection<SalesReturn> SalesReturns { get; set; } = new List<SalesReturn>();
}
