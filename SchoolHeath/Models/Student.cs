using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentCode { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string? School { get; set; }

    public string? Address { get; set; }

    public string ParentCccd { get; set; } = null!;

    public string? BloodType { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<HealthCheckup> HealthCheckups { get; set; } = new List<HealthCheckup>();

    public virtual HealthRecord? HealthRecord { get; set; }

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();

    public virtual ICollection<MedicationRequest> MedicationRequests { get; set; } = new List<MedicationRequest>();

    public virtual Parent ParentCccdNavigation { get; set; } = null!;

    public virtual ICollection<VaccinationConsent> VaccinationConsents { get; set; } = new List<VaccinationConsent>();

    public virtual ICollection<VaccinationRecord> VaccinationRecords { get; set; } = new List<VaccinationRecord>();
}
