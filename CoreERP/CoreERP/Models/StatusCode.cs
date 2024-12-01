using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreERP.Models;

public partial class StatusCode
{
    [Key]
    public int StatusCode1 { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
