using System;
using System.Collections.Generic;

namespace CoreERP.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Education { get; set; }

    public string? Position { get; set; }

    public DateOnly? Doj { get; set; }

    public decimal? SalaryPackage { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int StatusCode { get; set; }

    public virtual StatusCode StatusCodeNavigation { get; set; } = null!;
}
