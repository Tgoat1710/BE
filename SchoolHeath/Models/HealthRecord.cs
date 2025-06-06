using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class HealthRecord
{
    public int RecordId { get; set; }

    public int StudentId { get; set; }

    public string? Allergies { get; set; }

    public string? ChronicDiseases { get; set; }

    public string? VisionStatus { get; set; }

    public string? MedicalHistory { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Student Student { get; set; } = null!;
}
