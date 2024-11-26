﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class SalesItem
{
    public Guid SalesItemId { get; set; }

    public Guid SalesId { get; set; }

    public Guid ItemId { get; set; }

    public int? Quantity { get; set; }

    public string? BatchNumber { get; set; }

    public decimal? SellingPrice { get; set; }

    public virtual Inventory Item { get; set; } = null!;

    public virtual Sale Sales { get; set; } = null!;
}