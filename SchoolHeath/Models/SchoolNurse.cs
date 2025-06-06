using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class SchoolNurse
{
    public int NurseId { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<HealthCheckup> HealthCheckups { get; set; } = new List<HealthCheckup>();

    public virtual ICollection<MedicineInventory> MedicineInventories { get; set; } = new List<MedicineInventory>();

    public virtual ICollection<VaccinationRecord> VaccinationRecords { get; set; } = new List<VaccinationRecord>();
}
