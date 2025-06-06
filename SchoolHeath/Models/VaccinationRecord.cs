using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class VaccinationRecord
{
    public int VaccinationId { get; set; }

    public int StudentId { get; set; }

    public string VaccineName { get; set; } = null!;

    public DateOnly DateOfVaccination { get; set; }

    public int AdministeredBy { get; set; }

    public DateOnly? FollowUpReminder { get; set; }

    public virtual SchoolNurse AdministeredByNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
