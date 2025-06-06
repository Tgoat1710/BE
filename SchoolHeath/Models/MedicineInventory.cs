using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class MedicineInventory
{
    public int MedicineId { get; set; }

    public int? NurseId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public virtual ICollection<MedicationRequest> MedicationRequests { get; set; } = new List<MedicationRequest>();

    public virtual SchoolNurse? Nurse { get; set; }
}
