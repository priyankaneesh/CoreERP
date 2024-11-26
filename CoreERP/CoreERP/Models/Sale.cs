using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class Sale
{
    public Guid SalesId { get; set; }

    public string? CustomerName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateOnly? BillDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    public virtual ICollection<SalesReturn> SalesReturns { get; set; } = new List<SalesReturn>();
}
