using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class Parent
{
    public int ParentId { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string Cccd { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<VaccinationConsent> VaccinationConsents { get; set; } = new List<VaccinationConsent>();
}
