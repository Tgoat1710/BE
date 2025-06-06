using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class MedicalEvent
{
    public int EventId { get; set; }

    public int StudentId { get; set; }

    public string EventType { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public string? Description { get; set; }

    public int? HandledBy { get; set; }

    public string? Outcome { get; set; }

    public string? Notes { get; set; }

    public virtual Account? HandledByNavigation { get; set; }

    public virtual Student Student { get; set; } = null!;
}
