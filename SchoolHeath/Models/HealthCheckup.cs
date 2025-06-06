using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class HealthCheckup
{
    public int CheckupId { get; set; }

    public int StudentId { get; set; }

    public int? NurseId { get; set; }

    public DateOnly CheckupDate { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? Vision { get; set; }

    public string? BloodPressure { get; set; }

    public string? Notes { get; set; }

    public virtual SchoolNurse? Nurse { get; set; }

    public virtual Student Student { get; set; } = null!;
}
