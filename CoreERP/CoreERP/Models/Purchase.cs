using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class Purchase
{
    public Guid PurchaseId { get; set; }

    public Guid VendorId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    public virtual Vendor Vendor { get; set; } = null!;
}
