using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class VaccinationConsent
{
    public int ConsentId { get; set; }

    public int StudentId { get; set; }

    public string ParentCccd { get; set; } = null!;

    public string VaccineName { get; set; } = null!;

    public bool ConsentStatus { get; set; }

    public DateOnly ConsentDate { get; set; }

    public string? Notes { get; set; }

    public virtual Parent ParentCccdNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
