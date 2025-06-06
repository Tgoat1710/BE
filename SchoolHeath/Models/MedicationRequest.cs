using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class MedicationRequest
{
    public int RequestId { get; set; }

    public int StudentId { get; set; }

    public int MedicineId { get; set; }

    public int RequestedBy { get; set; }

    public DateOnly RequestDate { get; set; }

    public string Dosage { get; set; } = null!;

    public string? Frequency { get; set; }

    public string? Duration { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual MedicineInventory Medicine { get; set; } = null!;

    public virtual Account RequestedByNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
