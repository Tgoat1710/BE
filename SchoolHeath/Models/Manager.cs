using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual Account Account { get; set; } = null!;
}
